<?php

date_default_timezone_set('Europe/Sofia');
preg_match_all('/[^\n]+/', $_GET['messages'], $rows);
$messages = [];

foreach ($rows[0] as $row) {
    preg_match("/(.+)\/(.*)/", $row , $message);
    $messages[] = [
        'text' => trim($message[1]),
        'date' =>   new DateTime( $message[2] )
    ];
}

usort($messages, function($a, $b) {
    return $b['date'] < $a['date'];
});

foreach ($messages as $message) {
    echo "<div>" . htmlentities($message['text']) . "</div>", "\n";
}

$currentDate = new \DateTime($_GET['currentDate']);
$messageDate = $messages[count($messages) - 1]['date'];

if($messageDate->format('d-m-Y') === $currentDate->format('d-m-Y') ) {
    $diff = $currentDate->diff($messages[count($messages) - 1]['date']);

    $minutes = $diff->days * 24 * 60;
    $minutes += $diff->h * 60;
    $minutes += $diff->i;

    if ($minutes === 0) {
        $last = "a few moments ago";
    } else if ($minutes < 60) {
        $last = $minutes . " minute(s) ago";
    } else {
        $last = intval($minutes / 60) . " hour(s) ago";
    }
} else {
    $yesterday = new \DateTime($_GET['currentDate']);
    $yesterday->sub(new DateInterval('P1D'));
    $date = $messages[count($messages) - 1]['date']->format('d-m-Y');

    if ($date === $yesterday->format('d-m-Y')) {
        $last = "yesterday";
    } else {
        $last = $date;
    }
}

echo "<p>Last active: <time>" . $last . "</time></p>";