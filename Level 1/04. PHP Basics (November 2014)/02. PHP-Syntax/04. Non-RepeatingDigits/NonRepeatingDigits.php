<?php

function compare($var) {
    $numbers = array();
    for ($i = 100; $i <= 1000; $i++) {
        $number = (string)$i;
        if($i <= $var && $number[0] != $number[1] && $number[1] != $number[2] && $number[0] != $number[2]) {
            array_push($numbers, $i);
        }
    }

    return $numbers;
};

$input = array(
    1234,
    145,
    15,
    247
);

for ($i = 0; $i < count($input); $i++) {
    $numbers = compare($input[$i]);
    if (count($numbers)) {
        echo implode(", ", $numbers) . "\n";
    } else {
        echo "no\n";
    }
}