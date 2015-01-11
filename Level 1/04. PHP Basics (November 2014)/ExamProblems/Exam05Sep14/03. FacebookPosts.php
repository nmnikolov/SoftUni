<!DOCTYPE html>
<html>
<head>
    <title>Facebook Posts</title>
    <style>
        label, textarea {
            display: block;
        }
        textarea {
            width: 450px;
            height: 150px;
        }
        form {
            margin-bottom: 30px;
        }
        input[type="submit"] {
            margin: 5px;
        }
        h2 {
            margin: 0;
        }
    </style>
<body>
<h2>Zero Test #1</h2>
<form action="" method="get">
    <label for="text">Text:</label>
    <textarea name="text">Pesho Meshev;2-9-2014;    Sometimes I post very deep messages on facebook that have nothing to do with who I am or what I do, but I like people to think that I'm very, very deep.    ;160;Confession of the century/hahaha this is so NOT funny</textarea>
    <input type="submit" value="SUBMIT"/>
</form>

<h2>Zero Test #2</h2>
<form action="" method="get">
    <label for="text">Text:</label>
    <textarea name="text">Pesho Meshev;2-9-2014;Sometimes I post very deep messages on facebook that have nothing to do with who I am or what I do, but I like people to think that I'm very, very deep; 160;  Confession of the century/hahaha this is so NOT funny

Chico Tashko;06-06-2014;Zasqh piperite i jinite, vreme e za rakiq;2345;</textarea>
    <input type="submit" value="SUBMIT"/>
</form>
</body>
</html>

<?php
date_default_timezone_set('Europe/Sofia');
$text = $_GET['text'];
//$text = '%3Cp%3E%26alt%3C%2Fp%3E%3B15-6-2000%3BDadadadaadaad+++++++++++++%3B++++++++15++++++++++++%3B+++dawdawdwa+%2F+dlkajdkwlj+%2F+uu53092u5%2F+4uoidafjea%0D%0A%0D%0A';
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