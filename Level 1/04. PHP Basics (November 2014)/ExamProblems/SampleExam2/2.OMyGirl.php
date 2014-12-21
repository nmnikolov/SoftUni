<?php

$key = $_GET['key'];
$text = $_GET['text'];

//$key = 'a7#F5';
//$text = "a-.885O,a745#F5Sofa7#FFF5a1#D5ia, a000#FFF5a88887#F532 a123457#F5a7   #FGDGSDG5G.S.a#5 ma-5.55gghja-.885y8hgja#F5Rakoa#F5a5#F5vsa9#F5ghhjkuu867885a7#FYIYUHUI5ki a7#FUIO5 a9997#F5Stra#5gia-5.558dft.8.8.a60-6.05hu-h-0yuua-.885rla-5.55yuti-..uioa-.885!a-5.55";

if (strlen($key) === 2) {
    $pattern = "/$key/";
} else {
    $pattern = "/$key[0]";
    $isActive = false;

    for ($i = 1; $i < strlen($key) - 1; $i++) {
        if (preg_match("/[^a-zA-Z\d]/", $key[$i])) {
            $pattern = $pattern . $key[$i];
            $isActive = false;
            continue;
        }

        if (! $isActive) {
            if (preg_match("/[A-Z]/", $key[$i])) {
                $pattern = $pattern . "[A-Z]*";
                $isActive = true;
                continue;
            }
        }

        if (! $isActive) {
            if (preg_match("/[a-z]/", $key[$i])) {
                $pattern = $pattern . "[a-z]*";
                $isActive = true;
                continue;
            }
        }

        if (! $isActive) {
            if (preg_match("/[\d]/", $key[$i])) {
                $pattern = $pattern . "\d*";
                $isActive = true;
                continue;
            }
        }
    }

    $pattern = $pattern . $key[strlen($key) - 1] . "/";

    preg_match_all($pattern, $text, $keys);


    foreach ($keys[0] as $key => $value) {
        if (strlen($value) > 10) {
            unset($keys[0][$key]);
        }
    }

}

$output = '';


for ($i = 0; $i < count($keys[0]); $i += 2) {
    $pos = strpos($text, $keys[0][$i]) + strlen($keys[0][$i]);

    $text = substr($text, $pos);
    $pos = strpos($text, $keys[0][$i + 1]);
    $output = $output . substr($text, 0, $pos);

    $pos = strpos($text, $keys[0][$i + 1]) + strlen($keys[0][$i + 1]);

    $text = substr($text, $pos);

}

echo $output;


