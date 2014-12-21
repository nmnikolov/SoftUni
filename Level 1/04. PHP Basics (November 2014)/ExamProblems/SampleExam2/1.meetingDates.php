<?php

date_default_timezone_set('Europe/Sofia');
$dateOne = new DateTime( $_GET['dateOne'] );
$dateTwo = new DateTime( $_GET['dateTwo'] );
$interval = new DateInterval('P1D');

$begin = $dateOne <= $dateTwo ? $dateOne : $dateTwo;
$end = $dateOne > $dateTwo ? $dateOne : $dateTwo;
$end = $end->modify( '+1 day' );

$dateRange = new DatePeriod($begin, $interval ,$end);
$result = [];

foreach ($dateRange as $date) {
    $date = date_format($date, 'd-m-Y');
    if (isThursdays($date)) {
        $result[] = $date;
    }
}

if (! empty ($result) ) {

    echo "<ol>";

    foreach ($result as $date) {
        echo "<li>$date</li>";
    }

    echo "</ol>";

} else {
    echo "<h2>No Thursdays</h2>";
}

function isThursdays($date) {
    return (date('N', strtotime($date)) == 4);
}