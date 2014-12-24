<?php
$luggageRows = preg_split('/C\|_\|/', $_GET['luggage'], -1, PREG_SPLIT_NO_EMPTY);
$type = $_GET['typeLuggage'];
$room = $_GET['room'];
$min = $_GET['minWeight'];
$max = $_GET['maxWeight'];
$pack = [];

for ($i = 0; $i < count($luggageRows); $i++) {
    preg_match("/(?<type>[^;]+);(?<room>[^;]+);(?<luggage>[^;]+);(?<kg>.*)kg/", $luggageRows[$i], $row);
    if($room === $row['room'] && in_array($row['type'], $type)) {
        $pack[$row['type']][$row['room']]['luggage'][] = $row['luggage'];
        if (isset($pack[$row['type']][$row['room']]['kg'])) {
            $pack[$row['type']][$row['room']]['kg'] += intval($row['kg']);
        } else {
            $pack[$row['type']][$row['room']]['kg'] = intval($row['kg']);
        }
    }
}

ksort($pack);
echo "<ul>";

foreach ($pack as $luggageType => $roomType) {
    $sum = $roomType[$room]['kg'];
    $print = true;
    if($sum >= $min && $sum <=$max) {
        if ($print) {
            echo "<li><p>" . htmlspecialchars($luggageType)  . "</p><ul>";
            $print = false;
        }
        sort($roomType[$room]['luggage']);
        $row = implode(', ', $roomType[$room]['luggage']) . ' - ' . $sum . 'kg';

        echo "<li><p>" . htmlspecialchars($room)  . "</p><ul>";
        echo "<li><p>" . htmlspecialchars($row)  . "</p></li></ul></li></ul></li>";
    }
}

echo "</ul>";