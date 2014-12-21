<?php
$text = $_GET['text'];
$minFontSize = $_GET['minFontSize'];
$maxFontSize = $_GET['maxFontSize'];
$step = $_GET['step'];

$multiplier = 1;
$fontSize = $minFontSize;

for ($i = 0; $i < strlen($text); $i++) {
    $textDecoration = ord($text[$i]) % 2 === 0 ? "text-decoration:line-through;" : "";
    echo "<span style='font-size:$fontSize;$textDecoration'>" . htmlspecialchars($text[$i]) . "</span>";
    $fontSize = ctype_alpha($text[$i]) ? $fontSize + $multiplier * $step : $fontSize;

    if (($fontSize >= $maxFontSize || $fontSize == $minFontSize) && ctype_alpha($text[$i])) {
        $multiplier *= -1;
    }
}