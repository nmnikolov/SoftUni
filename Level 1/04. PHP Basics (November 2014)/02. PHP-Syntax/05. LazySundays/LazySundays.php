<?php

date_default_timezone_set('Europe/Sofia');

function getSundays($y, $m)
{
    return new DatePeriod(
        new DateTime("first sunday of $y-$m"),
        DateInterval::createFromDateString('next sunday'),
        new DateTime("next month $y-$m-01")
    );
}

foreach (getSundays(date("Y"), date("M")) as $wednesday) {
    echo $wednesday->format("jS F, Y\n");
}