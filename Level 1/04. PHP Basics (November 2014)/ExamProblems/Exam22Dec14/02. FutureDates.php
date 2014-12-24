<?php
date_default_timezone_set('Europe/Sofia');

preg_match_all("/(?<=[^a-zA-Z\d]){1}\d+\.*\d*(?=[^a-zA-Z\d]){1}/", $_GET['numbersString'], $numbers);
preg_match_all("/\d{4}-\d{2}-\d{2}/", $_GET['dateString'], $dates);
$sum = '' . array_sum($numbers[0]);
$sum = strrev($sum);
$found = false;

if  (! empty ($dates[0])) {
    $print = true;
    foreach ($dates[0] as $date) {
        if (validateDate($date)) {
            if ($print) {
                echo "<ul>";
                $print = false;
            }
            $found = true;
            $date = new DateTime($date);
            $date->add(new DateInterval("P{$sum}D"));
            echo "<li>" . htmlspecialchars($date->format('Y-m-d')) . "</li>";
        }
    }

    if($print === false) {
        echo "</ul>";
    }

    if($found) {
        return;
    }
}

echo "<p>No dates</p>";

function validateDate($date)
{
    $d = DateTime::createFromFormat('Y-m-d', $date);
    return $d && $d->format('Y-m-d') === $date;
}