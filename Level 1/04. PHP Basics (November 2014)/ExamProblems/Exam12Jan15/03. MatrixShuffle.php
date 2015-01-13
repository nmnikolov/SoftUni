<?php
$text = trim($_GET['text']);
$length = intval($_GET['size']);
$rows = intval(strlen($text) / $length) + (strlen($text) % $length !== 0 ? 1 : 0);

$direction = 1; // 1 => fill down then left    -1 => fill up then right
$x = 0;
$y = $length - 1;
$xCount = $rows - 1;
$yCount = $length - 1;
$char = 0;

for ($row = 0; $row < $rows; $row++) {
    $string = str_pad('', $length , "*");
    $temp[] = $string;
}

for ($row = 0; $row < $rows; $row++) {
    for ($col = 0; $col < $length; $col++) {
        if ($row == 0) {
            $temp[$row][$col] = $text[$char];
            $char++;
            continue;
        }

        for ($i = 0; $i < $xCount; $i++) {
            $x = $x + 1 * $direction;
            $temp[$x][$y] = $char < strlen($text) ? $text[$char] : ' ';
            $char++;
        }
        for ($i = 0; $i < $yCount; $i++) {
            $y = $y - 1 * $direction;
            $temp[$x][$y] = $char < strlen($text) ? $text[$char] : ' ';
            $char++;
        }
        $direction *= -1;
        $xCount--;
        $yCount--;
    }
}

$first = '';
$second = '';

for ($row = 0; $row < count($temp); $row++) {
    for ($col = 0; $col < $length; $col += 2) {
        if ($row % 2 === 0) {
            $first = $first . $temp[$row][$col];
            if ($col + 1 < strlen($temp[$row])) {
                $second = $second . $temp[$row][($col + 1)];
            }
        } else {
            $second = $second . $temp[$row][$col];
            if ($col + 1 < strlen($temp[$row])) {
                $first = $first . $temp[$row][$col + 1];
            }
        }
    }
}

$outputString = $first . $second;
$pol = preg_replace('/[^a-zA-Z]/', '', $outputString);
$color = strtolower(strrev($pol)) === strtolower($pol) ? '#4FE000' : '#E0000F';

echo "<div style='background-color:" . $color . "'>$outputString</div>";