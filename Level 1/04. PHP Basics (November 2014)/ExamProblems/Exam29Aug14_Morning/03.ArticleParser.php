<?php
date_default_timezone_set('Europe/Sofia');
$pattern = '/\s*([a-zA-Z\- ]+)\s*%\s*([a-zA-Z\-\. ]+)\s*;\s*(\d{2}-\d{2}-\d{4})\s*-\s*(.{0,100})/';
preg_match_all($pattern, $_GET['text'], $articles);
for ($i = 0; $i < count($articles[0]); $i++) {
    if (strtotime($articles[3][$i])) {
        $date = strtotime($articles[3][$i]);

        echo "<div>", "\n";
        echo "<b>Topic:</b> <span>" . htmlentities(trim($articles[1][$i])) . "</span>", "\n";
        echo "<b>Author:</b> <span>" . htmlentities(trim($articles[2][$i])) . "</span>", "\n";
        echo "<b>When:</b> <span>" . htmlentities(date("F", strtotime($articles[3][$i]))) . "</span>", "\n";
        echo "<b>Summary:</b> <span>" . htmlentities(trim($articles[4][$i])) . "...</span>", "\n";
        echo "</div>", "\n";
    }
}