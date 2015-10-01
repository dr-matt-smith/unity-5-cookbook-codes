<?php

// out includes
include_once 'scoreFunctions.php';
include_once 'dbFunctions.php';

/**
 * if we cannot find a GET 'action'
 * set it to 'defaultIndexPage'
 * otherwise extra the action
 */
if(!isset($_GET["action"])){
    $action = 'defaultIndexPage';
} else {
    $action = $_GET["action"];
}

/**
 * call function corresponding to value in $action
 */
switch ($action) {
    case 'get':
        getPlayer();
        break;
    case 'set':
        setPlayer();
        break;
    case 'html':
        toHTML();
        break;
    case 'xml':
        toXML();
        break;
    case 'reset':
        resetDatabase();
        break;

    case 'defaultIndexPage':
        include_once 'htmlDefault.php';
        print $htmlDefaultPage;
        break;

    default:
        print 'Error - unknown value for "action" parameter';
}

// add link back to index at bottom of whatever page was displayed
print '<br>';
print '<a href="index.php">index</a>';
