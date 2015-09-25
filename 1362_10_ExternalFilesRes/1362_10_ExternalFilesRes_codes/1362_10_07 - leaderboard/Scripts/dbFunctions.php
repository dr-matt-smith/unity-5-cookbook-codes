<?php
function open_database_connection() {
    // DB connection details
    $username = 'cookbook';
    $password = 'cookbook';
    $host = 'localhost';
    $db = 'cookbook_highscores';

    // try to connect to DB
    $connection = mysqli_connect($host, $username, $password, $db);

    // check connection successful
    // redirect with message to error page
    if (mysqli_connect_errno()) {
        $errorMessage = 'DB connection failed: '.mysqli_connect_error();
        die($errorMessage);
    }

    return $connection;
}

function close_database_connection($connection)
{
    mysqli_close($connection);
}

function getScoreByPlayerName($playerName){
    $connection=open_database_connection();
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
    if($result = mysqli_query($connection,$query)){
        if($row = mysqli_fetch_assoc($result)){
            $score = $row['score'];
        }
    } else {
        $errorMessage = 'Query failed:'.$query;
        die($errorMessage);
    }
    close_database_connection($connection);
    return $score;
}

function getIdByPlayerName($playerName){
    $id = null;

    $connection=open_database_connection();
    $query = "select * from cookbook_highscores WHERE player='$playerName'";
    if($result = mysqli_query($connection,$query)){
        if($row = mysqli_fetch_assoc($result)){
            $id = $row['id'];
        }
    } else {
        $errorMessage = 'Query failed:'.$query;
        die($errorMessage);
    }
    return $id;
}

function setScoreByPlayerName($playerName, $newScore){
    $connection = open_database_connection();

    $oldScore = getScoreByPlayerName($playerName);
    $playerId = getIdByPlayerName($playerName);

    $shouldUpdate = $newScore > $oldScore;

    if($shouldUpdate){
        //---------
        // update score //
        $query = "UPDATE cookbook_highscores SET score=$newScore WHERE id=$playerId";

        mysqli_query($connection, $query);
        $numAffectedRows = mysqli_affected_rows($connection);
        close_database_connection($connection);
        return ($numAffectedRows > 0);
    } else {
        close_database_connection($connection);
        return false;
    }
}

function deleteAllRecords()
{
    $connection = open_database_connection();

    $query = "DELETE FROM cookbook_highscores";
    mysqli_query($connection, $query);
    close_database_connection($connection);
}


function insertNewRecord($playerName, $score)
{
    $connection = open_database_connection();

    $query = "INSERT INTO cookbook_highscores(player, score) VALUES ('$playerName', $score)";
    print '<br>';
    print($query);
    mysqli_query($connection, $query);
    close_database_connection($connection);
}



