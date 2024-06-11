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
    
    function currentDateTime() {
        return date('Y-m-d H:i:s');
    }
    
    function learnFieldNames($line)
    {
        global $fieldNames;
        $fieldNames = array();
        if (strlen(trim($line)) > 0) {
            $aryNames = str_getcsv($line);
            for ($i = 0; $i < count($aryNames); $i++) {
                $nameTrimmed = trim($aryNames[$i]);
                //echo "Field $i: $nameTrimmed\n";
                $fieldNames[$nameTrimmed] = $i;
            }
        }
        // echo "End of processing field names\n";
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

    function parseCallNumber($fld)
    {
        // The Call Number field in the CSV file has various formats, such as:
        // Children's Area - Beginner Readers - Fiction HOURAN
        // Children's Area - Boardbooks BB
        // Biography Collection BIOGRAPHY WILLIAMS, T.
        // Mystery Collection MYSTERY CHILD, L.
        // Nonfiction Books 153.35 RUBIN
        // Fiction Books HUANG, L.
        // DVD Collection WHITE SEASON 1
        // Playaway PLAYAWAY PENNY, L.
        $location = "";
        $callNum = "";

        if(startsWith($fld, "Children's Area - ")) { 
            $location = "Children";
            $rest = substr($fld, strlen("Children's Area - "));
            $childparts = explode(" - ", $rest, 2);
            if(count($childparts) >= 2) {
                $location = $location . " " . $childparts[0];
                $callNum = $childparts[1];
            } else {
                // I need to see more examples to know what to do here.
                // For now, just use the text after "Children's Area - "
                // as both the location and call number.
                $location = $location . " " . $childparts[0];
                $callNum = $childparts[0];
            }
        } else {
            $words = explode(" ", $fld);
            if(count($words) > 1) {
                if($words[1]=="Collection" || $words[1]=="Books" || $words[1]=="Area" || $words[1] == "Cart") {
                    $location = $words[0];
                    $callNum = implode(" ", array_slice($words, 2));
                } else {
                    $location = $words[0];
                    $callNum = implode(" ", array_slice($words, 1));
                }
            } else {
                $callNum = $fld;
            }
        }
        return array($location, $callNum);
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
        list($location, $callNum) = parseCallNumber($callNumRaw);
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

        $collection = getFieldByName($fields, "Collection");
        // echo "Collection: $collection\n";

        $stmt = $connection->prepare("INSERT INTO items (dateloaded, stampupdated, callnum, callnumraw" .
            ", copynum, title, titleraw, barcode, barcoderaw, collection, itemtype, location)" .
            " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
        $currentDateAndTime = currentDateTime();
        $stmt->bind_param("ssssssssssss", $currentDate, $currentDateAndTime, $callNum, $callNumRaw,
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
        for($i=1; $i<count($lines); $i++) {
            $fields = str_getcsv($lines[$i]);
            // echo "\n";
            // echo "Processing record $i\n";
            processItem($connection, $fields);
            //if($i>4) break; // For testing, only process a few items.
        }
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