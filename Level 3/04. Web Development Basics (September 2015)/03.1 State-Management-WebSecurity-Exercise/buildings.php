<?php

require_once 'index.php';

if (!$app->isLogged()){
    header("Location: login.php");
    exit;
}

$buildings = $app->createBuildings();

if(isset($_GET['id'])){
    $buildings->evolve($_GET['id']);
    header("Location: buildings.php");
    exit;
}

loadTemplate('buildings', $buildings);