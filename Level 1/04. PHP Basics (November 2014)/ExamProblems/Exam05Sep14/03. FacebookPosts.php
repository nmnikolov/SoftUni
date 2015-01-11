<?php
date_default_timezone_set('Europe/Sofia');
$text = $_GET['text'];
$rows = preg_split("/\n/", $text, -1, PREG_SPLIT_NO_EMPTY);

for ($row = 0; $row < count($rows); $row++) {
    if (trim($rows[$row]) !== '') {
        $pattern = "/(.*?);\s*(\d{1,2}-\d{1,2}-\d{4})\s*;(.*?);\s*(\d+)\s*;(.*)?/";
        preg_match($pattern, trim($rows[$row]), $posts);
        $date = $posts[2];

        if (validateDate($date)) {
            $date = new DateTime($date);
            $comments = preg_split('/\//', trim($posts[5]), -1, PREG_SPLIT_NO_EMPTY);

            $facebook[] = [
                'name' => trim($posts[1]),
                'date' => $date,
                'text' => trim($posts[3]),
                'likes' => $posts[4],
                'comments' => $comments
            ];
        }
    }
}

usort($facebook, function($a, $b) {
    return $b['date'] > $a['date'];
});

for ($i = 0; $i < count($facebook); $i++) {
    $name = htmlspecialchars($facebook[$i]['name']);
    $date = $facebook[$i]['date'];
    $postText = htmlspecialchars($facebook[$i]['text']);
    $likes = $facebook[$i]['likes'];

    echo "<article><header><span>$name</span><time>{$date->format('j F Y')}</time></header><main><p>$postText</p></main><footer><div class=\"likes\">$likes people like this</div>";

    if (!empty($facebook[$i]['comments'])) {
        echo "<div class=\"comments\">";

        for ($j = 0; $j <count($facebook[$i]['comments']); $j++) {
            echo "<p>" . htmlspecialchars(trim($facebook[$i]['comments'][$j])) . "</p>";
        }

        echo "</div>";
    }
    
    echo "</footer></article>";
}

function validateDate($date)
{
    $d = DateTime::createFromFormat('d-m-Y', $date);
    return $d && ($d->format('d-m-Y') === $date || $d->format('j-n-Y') === $date);
}