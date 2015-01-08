<?php
$inputs = json_decode($_GET['jsonTable']);
$columns = $inputs[0];
$string = '';

for ($i = 1; $i < count($inputs[1]); $i++) {
    preg_match("/time=(\d+)/", $inputs[1][$i], $time);
    $string .= chr($time[1]);
}

$words = preg_split('/[*]/', $string, -1, PREG_SPLIT_NO_EMPTY);

echo "<table border='1' cellpadding='5'>";

for ($i = 0; $i < count($words); $i++ ) {
    $rows = ceil(strlen($words[$i]) / $columns);
    $words[$i] = str_pad($words[$i], $columns * $rows);
    for ($row = 0; $row < $rows; $row++ ) {
        echo "<tr>";
        for ($column = 0; $column < $columns ; $column++ ) {
            $char = $words[$i][$row * $columns + $column];
            if (trim($char) != ''){
                echo "<td style='background:#CAF'>" . htmlspecialchars($char) . "</td>";
            } else {
                echo "<td></td>";
            }
        }
        echo "</tr>";
    }
}

echo "</table>";