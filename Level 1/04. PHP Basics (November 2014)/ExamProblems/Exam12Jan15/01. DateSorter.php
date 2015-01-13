<?php
date_default_timezone_set('Europe/Sofia');
$list = $_GET['list'];
$currDate = new DateTime($_GET['currDate']);
$rowsData = preg_split('/\r?\n/', $list, -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($rowsData); $i++) {
    try {
        $date = new DateTime(trim($rowsData[$i]));
        $dates[] = $date;
    } catch (Exception $e) {
        continue;
    }
}

if (isset($dates)) {
    sort($dates);
    echo "<ul>";
    for ($i = 0; $i < count($dates); $i++) {
        $dateString = $dates[$i]->format('d/m/Y');
        if ($dates[$i] < $currDate) {
            echo "<li><em>$dateString</em></li>";
        } else {
            echo "<li>$dateString</li>";
        }
    }
    echo "</ul>";
}