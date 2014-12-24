<?php
date_default_timezone_set('Europe/Sofia');

preg_match_all("/(.*)\/(.*)\/(.*)\/(.*)\/(.*)\/([^\n]+)/", $_GET['text'], $info);
$min = $_GET['min-price'];
$max = $_GET['max-price'];
$results = [];

for ($i = 0; $i < count($info[0]); $i++) {
    $price = $info[4][$i];

    if ($price >= $min && $price <= $max && validateDate($info[5][$i])) {
        $results[] = [
            'name' => $info[2][$i],
            'author' => $info[1][$i],
            'genre' => $info[3][$i],
            'price' => $price,
            'publish-date' => date_create_from_format('Y-m-d', $info[5][$i]),
            'info' => trim($info[6][$i])
        ];
    }
}

usort($results, function($a, $b) {
    $sort = $_GET['sort'];
    if ($b[$sort] !== $a[$sort]) {
        return $_GET['order'] === 'ascending' ? $b[$sort] < $a[$sort] : $a[$sort] < $b[$sort];
    }
    return $b['publish-date'] < $a['publish-date'];
});

foreach ($results as $result) {
    echo "<div>";
    echo "<p>" . htmlspecialchars($result['name']) . "</p>";
    echo "<ul>";
    echo "<li>" . htmlspecialchars($result['author']) . "</li>";
    echo "<li>" . htmlspecialchars($result['genre']) . "</li>";
    echo "<li>" . htmlspecialchars($result['price']) . "</li>";
    echo "<li>" . htmlspecialchars($result['publish-date']->format('Y-m-d')) . "</li>";
    echo "<li>" . htmlspecialchars($result['info']) . "</li>";
    echo "</ul>";
    echo "</div>";

}

function validateDate($date) {
    $d = DateTime::createFromFormat('Y-m-d', $date);
    return $d && $d->format('Y-m-d') === $date;
}