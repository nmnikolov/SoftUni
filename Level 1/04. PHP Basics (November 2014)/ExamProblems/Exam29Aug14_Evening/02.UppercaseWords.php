<?php
$text = $_GET['text'];
preg_match_all("/(?<![a-zA-Z])[A-Z]+(?![A-Za-z])/", $text, $words, PREG_OFFSET_CAPTURE);

if (!empty($words[0])) {

    $output = substr($text, 0, $words[0][0][1]);

    for ($i = 0; $i < count($words[0]); $i++) {
        $word = $words[0][$i];
        $replacement = strrev($word[0]);

        if ($word[0] === $replacement) {
            $replacement = '';
            for ($j = 0; $j < strlen($word[0]); $j++) {
                $replacement .= $word[0][$j];

                if (ctype_alpha($word[0][$j])) {
                    $replacement .= $word[0][$j];
                }
            }
        }

        $output .= $replacement;

        if ($i < count($words[0]) - 1) {
            $len = $words[0][$i + 1][1] - $word[1] - strlen($word[0]);
            $output .= substr($text, $word[1] + strlen($word[0]), $len);
        }

        if ($i == count($words[0]) - 1) {
            $output .= substr($text, $word[1] + strlen($word[0]));
        }
    }
    echo "<p>" . htmlentities($output) . "</p>";
} else {
    echo "<p>" . htmlentities($text) . "</p>";
}
