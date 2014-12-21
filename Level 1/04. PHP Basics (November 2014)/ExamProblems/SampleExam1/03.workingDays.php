<?php

date_default_timezone_set('Europe/Sofia');
$_GET['dateOne'] = "17-12-2014";
$_GET['dateTwo'] = "31-12-2014";
$_GET['holidays'] = "31-12-2014\n24-12-2014\n08-12-2014";

$begin = new DateTime( $_GET['dateOne'] );
$end = new DateTime( $_GET['dateTwo']);
$end = $end->modify( '+1 day' );
$interval = new DateInterval('P1D');
$holidays = preg_split("/\n/", $_GET['holidays']);
$dateRange = new DatePeriod($begin, $interval ,$end);

for ($i = 0; $i < count($holidays); $i++) {
    $holidays[$i] = trim($holidays[$i]);
}


$result = [];

foreach ($dateRange as $date) {
    $date = date_format($date, 'd-m-Y');
    if (!isWeekend($date) && !in_array($date, $holidays)) {
        $result[] = $date;
    }
}

if(! empty($result)) {
    echo "<ol>";
    foreach ($result as $date) {
        echo "<li>$date</li>";
    }
    echo "</ol>";


} else {
    echo "<h2>No workdays</h2>";
}

function isWeekend($date) {
    return (date('N', strtotime($date)) >= 6);
}