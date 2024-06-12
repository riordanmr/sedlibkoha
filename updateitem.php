<?php
// This script is called by the client-side JavaScript in holds.php
// to update the status of an item that was on hold.
// This is part of the Holds app for Sedona Public Library;
// this version is for the the Koha ILS.
// Mark Riordan   2024-06-11

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

function currentDateTime() {
    return date('Y-m-d H:i:s');
}

class ItemCounts {
    public $looking = 0;
    public $found = 0;
    public $cantfind = 0;
    public $problem = 0;
}

function processRequest($connection) {
    // Obtain the raw data from the request
    $json = file_get_contents('php://input');
    // Convert it into a PHP object
    $data = json_decode($json);

    // Hack to pause to simulate timeouts due to network problems. 
    if($data->notes == "zzz") {
        sleep(12);
    } else if($data->notes == "zzz500") {
        http_response_code(500);
        exit;
    }
    // Update the item's record.
    $stmt = $connection->prepare("UPDATE items SET stampupdated=?, status=?, notes=? WHERE barcode=?;");
    $currentStamp = currentDateTime();
    $stmt->bind_param("ssss", $currentStamp, $data->status, $data->notes, $data->itemId);

    if ($stmt->execute() === TRUE) {
        // SQL executed successfully.
    } else {
        echo "Error: " . "<br>" . $stmt->error;
    }
    $stmt->close();

    // Now that the DB has been updated, get the new counts of items with
    // various statuses.
    $resp = new ItemCounts();
    $sql = "SELECT status, COUNT(*) AS count FROM items GROUP BY status;";
    $result = $connection->query($sql);
    if ($result->num_rows > 0) {
        // Loop through each row of the result set
        while ($row = $result->fetch_assoc()) {
            $status = $row["status"];
            $count = 0 + $row["count"];
            if($status == "") {
                $resp->looking = $count;
            } else if($status == "found") {
                $resp->found = $count;
            } else if($status == "cantfind") {
                $resp->cantfind = $count;
            } else if($status == "problem") {
                $resp->problem = $count;
            }
        }
    }
    // Return the counts in JSON form.
    echo json_encode($resp);
}

function postItemMain() {
    header('Content-Type: application/json');
    date_default_timezone_set('America/Phoenix');
    $connection = connectToDb();
    processRequest($connection);
    $connection->close();
}

postItemMain();
?>