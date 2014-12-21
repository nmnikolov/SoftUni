<?php

$text = $_GET['text'];
$blacklist = explode("\n", $_GET['blacklist']);

$pattern = '/[a-zA-Z\d\-+_]+@[a-zA-Z\d-]+.[a-zA-Z\d-.]+[a-zA-Z\d]/';

preg_match_all($pattern, $text, $emails);

foreach ($blacklist as $pattern) {
    $pattern = trim($pattern);
    $pattern = str_replace('.', '\.', $pattern);
    $pattern = str_replace('*', '.+', $pattern);
    $pattern = "/" . $pattern . "$/";

    foreach ($emails[0] as $email) {

        if (preg_match($pattern, $email)) {
            $replacement = str_repeat('*', strlen($email));
            $text = str_replace($email, $replacement, $text);
        }
    }
}

    foreach ($emails[0] as $email) {
        $pos = strpos($text, $email);

        if ($pos !== false) {
            $replacement = '<a href="mailto:' . $email . '">' . $email . '</a>';
            $text = str_replace($email, $replacement, $text);
        }

    }

$text = "<p>" . $text . "</p>";
echo $text;