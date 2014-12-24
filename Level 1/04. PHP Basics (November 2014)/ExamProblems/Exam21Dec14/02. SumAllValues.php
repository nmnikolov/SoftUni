<?php
preg_match("/^([a-zA-Z_]+)\d+(?:.*\d)*([a-zA-Z_]+)$/", $_GET['keys'], $keys);

if (isset($keys[1], $keys[2])) {
    $pattern = "/" . $keys[1] . "(.+?)" . $keys[2] . "/";
    preg_match_all($pattern, $_GET['text'], $numbers);
    $sum = array_sum($numbers[1]);
    $sum = $sum !== 0 ? $sum : "nothing";
    echo "<p>The total value is: <em>" . $sum . "</em></p>";
} else {
    echo "<p>A key is missing</p>";
}