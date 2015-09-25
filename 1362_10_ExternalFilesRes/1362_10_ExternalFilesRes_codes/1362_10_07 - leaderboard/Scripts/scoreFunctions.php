<?php
function getPlayer() {
    $playerName = $_GET["player"];
    $score = getScoreByPlayerName($playerName);

    print $score;

}

function setPlayer()
{
    $playerName = $_GET["player"];
    $newScore = $_GET["score"];

    $feedback = ACTION_FAILED;

    $success = setScoreByPlayerName($playerName, $newScore);

    if ($success) {
        $feedback = $newScore;
    }

    print $feedback;
}


function toHTML() {
    $connection=open_database_connection();
    $query = "SELECT * FROM cookbook_highscores order by score desc";

    $html_output = "<!DOCTYPE HTML><html><head><title>Cookbook highscores</title></head><body><ol>";
    if($result = mysqli_query($connection,$query)) {
        while ($row = mysqli_fetch_assoc($result)) {
            $player = $row['player'];
            $score = $row['score'];
            $html_output .= "<li>$player = $score</li>";
        }
    }

    $html_output .= "</ol></body></html>";
    print $html_output;
}

function toXML() {
    $connection=open_database_connection();
    $query = "SELECT * FROM cookbook_highscores order by score desc";

    $xml_output = "<?xml><playerScoreList>";
    if($result = mysqli_query($connection,$query)) {
        while ($row = mysqli_fetch_assoc($result)) {
            $player = $row['player'];
            $score = $row['score'];
            $xml_output .= "<player>";
            $xml_output .= "<playerName>$player</playerName>";
            $xml_output .= "<score>$score</score>";
            $xml_output .= "</player>";
        }
    }

    $xml_output .= "</playerScoreList>";
    print $xml_output;
}

function resetDatabase()
{
    print('resetting database');

    deleteAllRecords();
    insertNewRecord('matt', 500);
    insertNewRecord('jane', 101);
    insertNewRecord('jim', 99);
    insertNewRecord('amy-jane', 88);
    insertNewRecord('ray', 77);
}