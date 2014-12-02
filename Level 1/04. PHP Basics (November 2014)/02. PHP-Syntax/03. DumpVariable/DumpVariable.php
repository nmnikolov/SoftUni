<?php

function dump($var) {
    if (is_numeric($var)) {
        var_dump($var);
    } else {
        echo gettype($var), "\n";
    }
};

$input = array(
    "hello",
    15,
    1.234,
    array(1,2,3),
    (object)[2,34]
);

for ($i = 0; $i < count($input); $i++) {
    dump($input[$i]);
}