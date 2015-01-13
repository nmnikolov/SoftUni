<?php
$pattern = '/([A-Z][A-Za-z]*)[^+a-zA-Z]*?(\+?\d[\d()\/\.\-\s]+)/';
preg_match_all($pattern, $_GET['numbersString'], $rowsData);

for ($i = 0; $i < count($rowsData[0]); $i++) {
    $rowsData[2][$i] = preg_replace('/[()\/\.\-\s]/', '', $rowsData[2][$i]);
    if(preg_match('/\d{2,}/', $rowsData[2][$i], $output_array)) {
        $numbers[] = [$rowsData[1][$i], $rowsData[2][$i]];
    }
}

if (isset($numbers)) {
    echo "<ol>";
    for ($i = 0; $i < count($numbers); $i++) {
        $name = $numbers[$i][0];
        $phone = $numbers[$i][1];
        echo "<li><b>{$name}:</b> $phone</li>";
    }
    echo "</ol>";
} else {
    echo "<p>No matches!</p>";
}