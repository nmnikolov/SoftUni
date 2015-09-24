<?php
const MIN_RANDOM_NUMBER = 1;
const MAX_RANDOM_NUMBER = 100;

if(isset($_POST['user'])){
    if(trim($_POST['user']) == ""){
        header("Location: " . 'index.php');
        exit;
    }
    $_SESSION['user'] = $_POST['user'];
    $_SESSION['number'] = rand(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
    $_SESSION['sendNumbers'] = [];
    $requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
    header("Location: " . $requestPath);
    exit;
}

if(isset($_POST['guess'])){
    $guess = (int)$_POST['guess'];
    $result = null;
    if(!preg_match('/^\d+$/',$_POST['guess']) || $guess < MIN_RANDOM_NUMBER || $guess > MAX_RANDOM_NUMBER){
        $result = 'Invalid number';
    } elseif($guess === $_SESSION['number']){
        $result = 'Correct number';
        $_SESSION['gameOver'] = true;
    } else {
        $result = $guess < $_SESSION['number'] ? 'UP' : 'DOWN';
    }

    $_SESSION['sendNumbers'][] = [
        'number' => $_POST['guess'],
        'result' => $result
    ];

    $requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
    header("Location: " . 'play.php');
    exit;
}

function __reset(){
    unset($_SESSION['user']);
    unset($_SESSION['number']);
    unset($_SESSION['sendNumbers']);
    unset($_SESSION['gameOver']);
    header("Location: " . 'index.php');
    exit;
}