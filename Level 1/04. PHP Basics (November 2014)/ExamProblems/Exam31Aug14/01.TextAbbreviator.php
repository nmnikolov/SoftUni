<?php
$rows = preg_split("/\n/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
$rows = array_filter($rows, 'trim');

if (!empty ($rows)) {
    echo "<ul>";

    foreach ($rows as $row) {
        $row = trim($row);
        $row = strlen($row) > intval($_GET['maxSize']) ? substr($row, 0, $_GET['maxSize']) . "..." : $row;
        echo "<li>" . htmlspecialchars($row) . "</li>";
    }
    echo "</ul>";
}