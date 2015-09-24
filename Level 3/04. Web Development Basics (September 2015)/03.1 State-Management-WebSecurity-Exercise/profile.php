<?php

require_once 'index.php';

if (!$app->isLogged()){
    header("Location: login.php");
    exit;
}

loadTemplate('profile', $app->getUser());

if (isset($_POST['edit'])){
    if ($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
        header("Location: profile.php?error=1");
        exit;
    }

    $user = new \Core\User(
        $_POST['username'],
        $_POST['password'],
        $_SESSION['id']
    );

    if ($app->editUser($user)){
        header("Location: profile.php?success=1");
        exit;
    }

    header("Location: profile.php?error=1");
    exit;
}