<?php

require_once 'index.php';

if (isset($_POST['username'], $_POST['password'])) {
    try {
        $user = $_POST['username'];
        $pass = $_POST['password'];
        $app->register($user, $pass);
        $app->login($user, $pass);
        header("Location: profile.php");
        exit;
    } catch (Exception $e) {
        echo $e->getMessage();
    }
}

loadTemplate('register');