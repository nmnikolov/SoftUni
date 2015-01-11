<?php
$red = str_pad(dechex($_GET['red']), 2, '0', STR_PAD_LEFT);
$blue = str_pad(dechex($_GET['blue']), 2, '0', STR_PAD_LEFT);
$green = str_pad(dechex($_GET['green']), 2, '0', STR_PAD_LEFT);
$rgb = '#' . $red . $green . $blue;
$nth = intval($_GET['nth']);
$text = $_GET['text'];

echo '<p>';

for ($i = 0; $i < strlen($text); $i++) {
    if (($i + 1) % $nth == 0) {
        echo '<span style="color: ' . $rgb . '">' . htmlspecialchars($text[$i]) . '</span>';
    } else {
        echo htmlspecialchars($text[$i]);
    }
}

echo '</p>';