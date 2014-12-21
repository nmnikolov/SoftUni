<?php
$text = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize= $_GET['fontSize'];
$fontStyle = $_GET['fontStyle'];

for ($i = 0; $i < strlen($text); $i++) {
    $char = ord($text[$i]);
    $text[$i] = $i % 2 == 0 ? chr($char + $hashValue) : chr($char - $hashValue);
}

switch ($fontStyle) {
    case 'normal' :
        $fontStyle = "font-style:{$fontStyle};";
        break;
    case 'italic' :
        $fontStyle = "font-style:{$fontStyle};";
        break;
    default:
        $fontStyle = "font-weight:{$fontStyle};";
        break;
}

echo "<p style=\"font-size:" . $fontSize . ";" . $fontStyle . "\">" . $text . "</p>";