<?php

/*-------------------------------------------
 * open connection to DB and return
 */
function open_database_connection()
{
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

/*-------------------------------------------
 * close provided DB connection
 */
function close_database_connection($connection)
{
    mysqli_close($connection);
}

/**
 * given a player name, return score for that player
 * (retrieved from DB)
 *
 * @param $playerName
 * @return mixed
 */
function getScoreByPlayerName($playerName)
{
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

/**
 * given a player name, return the ID corresponding
 * (retrieved from DB)
 *
 * @param $playerName
 * @return null
 */
function getIdByPlayerName($playerName)
{
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

/**
 * given a player name and score, try to store score in the DB
 * only store this new score if it is more than current score for player in DB
 *
 * @param $playerName
 * @param $newScore
 * @return bool true/false as to success of update
 */
function setScoreByPlayerName($playerName, $newScore)
{
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

/**
 * delete all player records from the DB
 */
function deleteAllRecords()
{
    $connection = open_database_connection();

    $query = "DELETE FROM cookbook_highscores";
    mysqli_query($connection, $query);
    close_database_connection($connection);
}

/**
 * given a player name and score, insert a new record with these details into the DB
 *
 * @param $playerName
 * @param $score
 */
function insertNewRecord($playerName, $score)
{
    $connection = open_database_connection();

    $query = "INSERT INTO cookbook_highscores(player, score) VALUES ('$playerName', $score)";
    print '<br>';
    print($query);
    mysqli_query($connection, $query);
    close_database_connection($connection);
}



