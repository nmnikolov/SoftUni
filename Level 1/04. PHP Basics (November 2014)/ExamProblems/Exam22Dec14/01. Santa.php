<?php
$name = preg_replace('/\s/', '-', $_GET['childName']);
$present = $_GET['wantedPresent'];
$riddles = preg_split('/;/',$_GET['riddles'], -1, PREG_SPLIT_NO_EMPTY);

$pickedRiddle = strlen($name) % count($riddles);
$pickedRiddle = $pickedRiddle - 1 < 0 ? count($riddles) - 1 : $pickedRiddle - 1;

echo "\$giftOf" . htmlspecialchars($name) . " = " .
    "\$[wasChildGood] ? '" . htmlspecialchars($present) . "' : '" .
    htmlspecialchars($riddles[$pickedRiddle]) . "';";
;