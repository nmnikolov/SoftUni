<?php
$input = json_decode($_GET['jsonTable']);
$k = $input[1][0];
$s = $input[1][1];
$m = 26;
$columns = max(array_map('strlen', $input[0]));

echo "<table border='1' cellpadding='5'>";

foreach ($input[0] as $word) {
    echo "<tr>";

    if( $columns === 0) {
        echo "<td></td>";
    }

    for ($i = 0; $i < $columns; $i++) {
        if ($word[$i] !== "") {
            $e = ctype_alpha($word[$i]) ? findLetter(($k * findX($word[$i]) + $s) % $m) : $word[$i];
            echo "<td style='background:#CCC'>" . $e . "</td>";
        } else {
            echo "<td></td>";
        }
    }
    echo "</tr>";
}
echo "</table>";

function findX($char) {
    return ord(strtoupper($char)) - ord('A');
}

function findLetter($number) {
    return chr($number + ord('A'));
}