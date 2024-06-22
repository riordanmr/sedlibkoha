<!DOCTYPE html>
<html>
<head>
    <!-- Web page to accept HTML of items on hold.  We parse the HTML and
     insert rows into the database used by holds.php.
     This version is for the Koha system and accepts CSV exports from that application.
     Mark Riordan 2024-06-10, based on postallitems.php of 2023-05-24
    -->
    <title>Load hold items</title>
    <style>
        body {font-family: Verdana; }
        h1 {font-size: 120%;}
        input {font-size: 100%;}
        pre, tt {font-family: Menlo, Lucida Console, Consolas, Courier New;}
    </style>
</head>
<body>
    <h1>Load hold items</h1>
    <p>This web page can be used to load the current day's held items into
        the database for the <a href="holds.php">Holds</a> web application.
    </p>
    <ul>
        <li>On the Koha website, click on Circulation.</li>
        <li>Click on Holds queue.</li>
        <li>Click on Columns and deselect Patron. (This is technically not necessary, because any patron information 
            provided will be immediately discarded anyway. But it's slightly better for patron privacy.)</li>
        <li>Click on Export and choose CSV.  This will cause a file to be downloaded to your Downloads directory.</li>
        <li>Locate the file in your Downloads directory. It will have a name something like <tt>Holds queue › Circulation › Koha (1).csv</tt>.</li>
        <li>Open the file in Notepad.</li>
        <li>Select all text in Notepad and do a copy.</li>
        <li>Paste into the textarea below.</li>
        <li>Enter the password.</li>
        <li>Click on Submit.</li>
    </ul>
    <!-- This form posts to itself, hence the empty action attribute. -->
    <form method="post" action="">
        <table>
            <tr>
                <td>Password:</td>
                <td><input type="text" name="password"></input>
            </tr>
            <tr>
                <td>Paste here:</td>
                <td><textarea id="items" name="items" cols="72" rows="15"></textarea></td>
            </tr>
            <tr>
                <td></td>
                <td><input type="submit" value="Submit"></td>
            </tr>
        </table>
    </form>
    <!-- The response from the server will be displayed here in a preformatted block. -->
    <pre><?php

    global $fieldNames;
    global $currentDate;

    function init()
    {
        date_default_timezone_set('America/Phoenix');
        global $currentDate;
        $currentDate = date('Y-m-d');
        //echo "currentDate: $currentDate\n";
        //echo "currentDateTime: " . currentDateTime() . "\n";
    }

    // This defines the DB_* constants used below.
    require_once '../../holdskoha.config.php';
    function connectToDb() {
        // Create a new MySQLi object
        $connection = new mysqli(DB_HOST, DB_USERNAME, DB_PASSWORD, DB_NAME);
    
        // Check the connection
        if ($connection->connect_error) {
            die("Connection failed: " . $connection->connect_error);
        }
        return $connection;
    }

    function clearExistingItems($connection) {
        global $currentDate;
        $sql = "DELETE FROM items WHERE dateloaded >= '" . $currentDate . "';";
        if($connection->query($sql) === false) {
            echo "Error deleting records: " . $connection->error;
            return false;
        }
        return true;
    }

    function getNextCharacterIndex($content, $searchString, $start) {
        $position = strpos($content, $searchString, $start);
    
        if ($position !== false) {
            $nextCharacterIndex = $position + strlen($searchString);
            return $nextCharacterIndex;
        }
    
        return -1; // If the search string is not found
    }

    function startsWith($haystack, $needle)
    {
        return substr_compare($haystack, $needle, 0, strlen($needle)) === 0;
    }

    function containsSubstring($strToSearch, $substring) {
        return strpos($strToSearch, $substring) !== false;
    }
    
    function currentDateTime() {
        return date('Y-m-d H:i:s');
    }
    
    function learnFieldNames($line)
    {
        global $fieldNames;
        $fieldNames = array();
        if (strlen(trim($line)) > 0) {
            $aryNames = str_getcsv($line);
            for($i=0; $i<count($aryNames); $i++) {
                $nameTrimmed = trim($aryNames[$i]);
                //echo "Field $i: $nameTrimmed\n";
                $fieldNames[$nameTrimmed] = $i;
            }
        }
        // echo "End of processing field names\n";
    }

    function ensureRequiredFieldsPresent()
    {
        global $fieldNames;
        $requiredFields = array("Title", "Call number", "Barcode", "Copy number", "Item type");
        foreach ($requiredFields as $name) {
            if (!array_key_exists($name, $fieldNames)) {
                echo "Required field $name not found in CSV file.\n";
                return false;
            }
        }
        return true;
    }

    function getFieldByName($fields, $name)
    {
        global $fieldNames;
        $idx = $fieldNames[$name];
        return $fields[$idx];
    }

    function parseTitle($fld)
    {
        $posSlash = strpos($fld, '/');
        $posSpaces = strpos($fld, '     ');
    
        if ($posSlash === false && $posSpaces === false) {
            // Neither "/" nor "     " found, return the whole string
            return $fld;
        } elseif ($posSlash === false) {
            // Only "     " found
            return substr($fld, 0, $posSpaces);
        } elseif ($posSpaces === false) {
            // Only "/" found
            return substr($fld, 0, $posSlash);
        } else {
            // Both found, return the part of the string before the first one
            return substr($fld, 0, min($posSlash, $posSpaces));
        }        
    }

    function parseBarcode($fld)
    {
        // The Barcode field in the CSV file can look like one of these:
        // 32789000112714 or any item from item group V.1 NO.4
        // 32789000112714 or any available
        // Only item: 32789000112714
        // 978-1-57965-695-9 or any available

        // Use a regular expression to match a sequence of digits or "-".
        if (preg_match('/\d\d[0123456789-]+/', $fld, $matches)) {
            // If a match is found, return the first match
            return $matches[0];
        } else {
            // If no match is found, return an empty string
            return '';
        }
    }

    function isAllUppercaseAlphabetic($word) {
        // Check if the word is composed only of uppercase letters A-Z.
        return preg_match('/^[A-Z]+$/', $word) === 1;
    }

    // Parse a call number into these fields:
    // area - A for adult, C for children
    // location - the location of the book
    // callNum - the call number of the book
    function parseCallNumber($callNumRaw)
    {
        // The Call Number field in the CSV file has various formats, such as:
        // BIO - Biography Collection BIOGRAPHY BRODEUR, A.
        // Children's Area - Beginner Readers - Fiction HOURAN
        // Children's Area - Boardbooks BB
        // Children's Area - Easy Books - Nonfiction 590 MONTGOMERY
        // DVD Collection 780.966 THEY
        // DVD Collection BIOGRAPHY HUBERMAN, B.
        // DVD Collection FARGO SEASON 2
        // FIC - Fiction Books HOLM, C.
        // JBGNF - Children's Area - Beginner Readers - Nonfiction BIOGRAPHY WASHINGTON, G.
        // JDVD - Children's Area - DVDs 591.9 WILD
        // JFIC - Children's Area - Fiction HINOJOSA, S. #1
        // JNF - Children's Area - Nonfiction 736.982 GEORGE
        // Mystery Collection MYSTERY KING, L.
        // NBFIC - New Books - Fiction MEDINA, N.
        // NF - Nonfiction Books 516.1 DU SAUTOY
        // Shelving Cart SINNER SEASON 2
        // YAFIC - Young Adult Area - Fiction WESTERFELD, S. UGLIES #2
        // 
        // Parsing this is quite ad hoc.
        // As you can see, often the first word is the old code for the location, but 
        // not always. For that reason, I will ignore the first word if it appears to be
        // an old location code (only uppercase letters followed by -), and try to 
        // contruct a location from the rest of the call number. 
        $area = "A"; // Default to "Adult"
        $location = "";
        $callNum = "";

        $fld = $callNumRaw;

        // Check for whether it starts with an old location code.
        $words = explode(" ", $fld);
        if(count($words)>1 && isAllUppercaseAlphabetic($words[0]) && $words[1]=="-") {
            // Ignore the first word and "-".
            $fld = implode(" ", array_slice($words, 2));
        }

        // By now, if the field contains "Children's Area -" at all, it should be at the start.
        if(startsWith($fld, "Children's Area -")) {
            $area = "C";
            $location = "Children";
            // Strip off "Children's Area - " from the start of the string.
            $rest = substr($fld, strlen("Children's Area - "));
            // print "Rest: $rest\n";
            // Now $rest should be something like "Beginner Readers - Nonfiction BIOGRAPHY WASHINGTON, G.";
            // namely, the location is the text up to and including the first " - ", plus the next word.
            $childparts = explode(" ", $rest);
            $idxStartCallNum = 1;
            for($idx=0; $idx<count($childparts); $idx++) {
                if($childparts[$idx]=="-") {
                    if($idx+2 <= count($childparts)) {
                        $idxStartCallNum = $idx + 2;
                        break;
                    }
                }
            }
            
            // Handle JCDBK - Children's Area - CD Books CDBOOK PENNYPACKER, S.
            if($childparts[0] == "CD" && $childparts[1] == "Books") {
                $idxStartCallNum++;
            }

            $location = "J " . implode(" ", array_slice($childparts, 0, $idxStartCallNum));
            $callNum = implode(" ", array_slice($childparts, $idxStartCallNum));
        } else {
            $words = explode(" ", $fld);
            // Look for a word that indicates the end of the name of the location.
            for($idx=0; $idx<count($words); $idx++) {
                if($words[$idx]=="Collection" || $words[$idx]=="Books" || $words[$idx]=="Area" || $words[$idx] == "Cart") {
                    if(count($words)>$idx+1 && $words[$idx+1] == "-") {
                        // We have something like Young Adult Area - Fiction BLUME, J.
                        $location = implode(" ", array_slice($words, 0, $idx)) . " " . $words[$idx+2];
                        $callNum = implode(" ", array_slice($words, $idx+3));
                    } else {
                        $location = implode(" ", array_slice($words, 0, $idx));
                        $callNum = implode(" ", array_slice($words, $idx+1));
                    }
                    break;
                }
            } 
            if($location == "" && $callNum == "") {
                // If we get here, it's probably bad input or a bug.
                $location = $words[0]; 
                $callNum = implode(" ", array_slice($words, 1));
            }
        }
        //print "$callNumRaw\t$area\t$location\t$callNum\n";
        return array($area, $location, $callNum);
    }

    function processItem($connection, $fields)
    {
        // Parse a line from the CSV file. 
        // Because Koha inexplicably crams a lot of different data into the same 
        // field, further parse certain CSV columns into distinct database fields.

        // Sample call number field:
        // Children's Area - Beginner Readers - Fiction HOURAN
        // Sample barcode field:
        // 32789000112714 or any item from item group V.1 NO.4
        global $currentDate;

        $titleRaw = getFieldByName($fields, "Title");
        $title = parseTitle($titleRaw);
        // echo "Title raw: $titleRaw\n";
        // echo "Title: $title\n";

        $callNumRaw = getFieldByName($fields, "Call number");
        list($area, $location, $callNum) = parseCallNumber($callNumRaw);
        // echo "Call number raw: $callNumRaw\n";
        // echo "Location: $location\nCall number: $callNum\n";

        $barcodeRaw = getFieldByName($fields, "Barcode");
        $barcode = parseBarcode($barcodeRaw);
        // echo "Barcode raw: $barcodeRaw\n";
        // echo "Barcode: $barcode\n";

        $copyNum = getFieldByName($fields, "Copy number");
        // echo "Copy number: $copyNum\n";

        $itemType = getFieldByName($fields, "Item type");
        // echo "Item type: $itemType\n";

        $collection = "";
        if(array_key_exists("Collection", $fields)) {
            $collection = getFieldByName($fields, "Collection");
        }
        // echo "Collection: $collection\n";

        $stmt = $connection->prepare("INSERT INTO items (dateloaded, stampupdated, area, callnum, callnumraw" .
            ", copynum, title, titleraw, barcode, barcoderaw, collection, itemtype, location)" .
            " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
        $currentDateAndTime = currentDateTime();
        $stmt->bind_param("sssssssssssss", $currentDate, $currentDateAndTime, $area, $callNum, $callNumRaw,
            $copyNum, $title, $titleRaw, $barcode, $barcodeRaw, $collection, $itemType, $location);

        if ($stmt->execute()  === TRUE) {
            // echo "New record $callNum inserted successfully";
        } else {
            echo "Error: " . $stmt->error;
        }
        $stmt->close();
    }

    function processItems($connection, $content)
    {
        $lines = preg_split("/\r\n|\n/", $content);
        echo "Processing " . count($lines)-1 . " items.\n";
        learnFieldNames($lines[0]);
        if(!ensureRequiredFieldsPresent()) {
            return;
        }
        $nItems = 0;
        for($i=1; $i<count($lines); $i++) {
            $fields = str_getcsv($lines[$i]);
            // echo "\n";
            // echo "Processing record $i\n";
            processItem($connection, $fields);
            //if($i>4) break; // For testing, only process a few items.
            $nItems += 1;
        }
        echo "Loaded $nItems items.\n";
    }
    
    function main() {
        init();
        if ($_SERVER["REQUEST_METHOD"] == "POST") {
            $password = $_POST['password'];
            $content = $_POST['items'];
            if($password == 'se') {
                echo "Received " . strlen($content) . " characters.\n";
                $connection = connectToDb();
                if($connection) {
                    if(clearExistingItems($connection)) {
                        processItems($connection, $content);
                    }
                    $connection->close();
                }
            } else {
                echo "Invalid password.";
            }
        }
    }
    main();
    ?>
    </pre>
</body>
</html>