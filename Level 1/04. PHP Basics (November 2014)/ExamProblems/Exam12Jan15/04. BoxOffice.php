<?php
$list = $_GET['list'];
$minSeats = intval($_GET['minSeats']);
$maxSeats = intval($_GET['maxSeats']);
$filter = $_GET['filter'];

$rows = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);

for ($row = 0; $row < count($rows); $row++) {
    $rowData = preg_split('/\-|\//', $rows[$row], -1, PREG_SPLIT_NO_EMPTY);
    $nameData = preg_split('/\(|\)/', $rowData[0], -1, PREG_SPLIT_NO_EMPTY);
    $name = trim($nameData[0]);
    $type = trim($nameData[1]);
    $actors = preg_split('/, /', $rowData[1], -1, PREG_SPLIT_NO_EMPTY);
    $seats = intval($rowData[2]);
    if (($filter === $type || $filter === 'all') && $seats >= $minSeats && $seats <= $maxSeats) {
        $movies[] = [
            'name' => $name,
            'type' => $type,
            'actors' => $actors,
            'seats' => $seats
        ];
    }
}

if (isset($movies)) {
    usort($movies, function($a, $b) {
        $order = $_GET['order'];
        if ($a['name'] !== $b['name']) {
            return $order == 'ascending' ? $a['name'] > $b['name'] : $b['name'] > $a['name'];
        }
        return $a['seats'] - $b['seats'];
    });
}

for ($i = 0; $i < count($movies); $i++) {
    $name = trim(htmlspecialchars($movies[$i]['name']));
    $seats = $movies[$i]['seats'];
    $actors = $movies[$i]['actors'];
    echo "<div class=\"screening\"><h2>$name</h2><ul>";
    for ($j = 0; $j < count($actors); $j++) {
        $actor = htmlspecialchars(trim($actors[$j]));
        echo "<li class=\"star\">$actor</li>";
    }
    echo "</ul><span class=\"seatsFilled\">$seats seats filled</span></div>";
}