<?php

date_default_timezone_set('Europe/Sofia');
//$now = new DateTime('12-08-2014 13:07:09');
$now = new DateTime();
$newYear = new DateTime();
$newYear->setDate(date("Y"), 12, 31);
$newYear->setTime(23, 59, 59);

$days = $newYear->diff($now)->days;
$hours = $newYear->diff($now)->h;
$minutes = $newYear->diff($now)->i;
$seconds = $newYear->diff($now)->s;

echo "Hours until new year : " . ($days * 24 + $hours), "\n";
echo "Minutes until new year : " . number_format((($days * 24 + $hours) * 60 + $minutes), 0,',', ' '), "\n";
echo "Seconds until new year : " . number_format(((($days * 24 + $hours) * 60 + $minutes) * 60 + $seconds), 0,',', ' '), "\n";
echo "Days:Hours:Minutes:Seconds $days:$hours:$minutes:$seconds";