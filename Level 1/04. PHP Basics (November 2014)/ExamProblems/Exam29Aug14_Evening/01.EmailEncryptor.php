<?php
$key = $_GET['key'];
$text =
    "<p class='recipient'>" . htmlspecialchars($_GET['recipient']) . "</p>" .
    "<p class='subject'>" . htmlspecialchars($_GET['subject']) . "</p>" .
    "<p class='message'>" . htmlspecialchars($_GET['body']) . "</p>";

echo '|';
for ($i = 0; $i < strlen($text); $i++) {
    $number = ord($text[$i]) * ord($key[$i % strlen($key)]);
    echo dechex($number) . "|";
}