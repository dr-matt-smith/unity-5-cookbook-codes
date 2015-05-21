<?php
include_once 'scoreFunctions.php';

$action = $_GET["action"];
if( !isset($action)){
    print $html_string;
    exit;
}

define("ACTION_FAILED", -1);
define("UNKNOWN_ACTION", -2);

$connection = mysql_connect("localhost", "cookbook", "cookbook")  or die (mysql_error());
mysql_select_db('cookbook_highscores');

switch ($action) {
    case 'get': getPlayer(); break;
    case 'set': setPlayer(); break;
    case 'xml': toXML(); break;
    case 'html': toHTML(); break;
    case 'reset': resetDatabase(); break;
    default: print UNKNOWN_ACTION;
}

mysql_close($connection);