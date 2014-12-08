<?php

function validateInput($start, $end) {
    $pattern = '/^\-?[\d]+$/';

    if (!preg_match($pattern, $start) || !preg_match($pattern, $end)) {
        echo "<p>'Start' and 'End' must be integer numbers.</p>";
        exit;
    }

    if ((int)$start >= (int)$end) {
        echo "<p>'Start' must be lower than 'End'.</p>";
        exit;
    }
}

function isPrime($number) {
    if ($number < 2) {
        return false;
    }

    for ($i = 2; $i < sqrt($number); $i++) {
        if ($number % $i == 0) {
            return false;
        }
    }

    return true;
}

if (isset($_GET['start'], $_GET['end'])) :
    $start = $_GET['start'];
    $end = $_GET['end'];
    $numbers = array();

    validateInput($start, $end);

    for ($i = (int)$start; $i <= (int)$end; $i++) {
        $numbers[] = isPrime($i) ? "<strong>$i</strong>" : $i;
    } ?>

<p> <?= implode(', ', $numbers) ?> </p>

<?php endif; ?>