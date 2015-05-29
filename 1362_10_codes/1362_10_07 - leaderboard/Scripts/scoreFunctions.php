<?php
function getPlayer() {
    $player = $_GET["player"];

    $sql = sprintf("SELECT * FROM score_list WHERE player='%s'", mysql_real_escape_string($player));
    $result_set = mysql_query($sql);
    if( $row = mysql_fetch_assoc($result_set) )
        print( $row['score'] );
    else
        print ACTION_FAILED;
}


function setPlayer() {
    $player = $_GET["player"];
    $new_score = $_GET["score"];

    $feedback = ACTION_FAILED;

    $sql = sprintf("SELECT * FROM score_list WHERE player='%s'", mysql_real_escape_string($player));
    
    $result_set = mysql_query($sql);
    if( $row = mysql_fetch_assoc($result_set) )
    {
        $id = $row['id'];
        $old_score = $row['score'];

        if( $new_score > $old_score )
        {
            //        $sql = "UPDATE score_list SET score=$new_score WHERE id=$id";
            $sql = sprintf("UPDATE score_list SET score=%s WHERE id=%s",
                mysql_real_escape_string($new_score),
                mysql_real_escape_string($id));
            mysql_query($sql);
            $feedback = $new_score; // indicate score updated
        }       
    }
    print $feedback;
}

function resetDatabase() {
print('reset');
    $sql = "DELETE from score_list"; mysql_query($sql);
    $sql = "INSERT INTO `score_list` VALUES(1, 'matt', 500)"; mysql_query($sql);
    $sql = "INSERT INTO `score_list` VALUES(2, 'jane', 101)"; mysql_query($sql);
    $sql = "INSERT INTO `score_list` VALUES(3, 'jim', 99)"; mysql_query($sql);
    $sql = "INSERT INTO `score_list` VALUES(4, 'amy-jane', 88)"; mysql_query($sql);
    $sql = "INSERT INTO `score_list` VALUES(5, 'ray', 77)"; mysql_query($sql);    
}

function toHTML() {
    $sql = "SELECT * FROM score_list order by score desc";
    $result_set = mysql_query($sql);

    $html_output = "<!DOCTYPE HTML><html><head><title>Cookbook highscores</title></head><body><ol>";
    while( $row = mysql_fetch_assoc($result_set) )
    {
            $player = $row['player'];
            $score = $row['score'];
            $html_output .= "<li>$player = $score</li>";
    }

    $html_output .= "</ol></body></html>";
    print $html_output;    
}

function toXML() {
    $sql = "SELECT * FROM score_list order by score desc";
    $result_set = mysql_query($sql);

    $xml_output = "<?xml><playerScoreList>";
    while( $row = mysql_fetch_assoc($result_set) )
    {
        $player = $row['player'];
        $score = $row['score'];
        $xml_output .= "<player>";
        $xml_output .= "<playerName>$player</playerName>";
        $xml_output .= "<score>$score</score>";
        $xml_output .= "</player>";
    }

    $xml_output .= "</playerScoreList>";
    print $xml_output;
}

?>
