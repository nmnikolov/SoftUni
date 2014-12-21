<?php

include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'controllers/login.php';
include_once 'models/master.php';
include_once 'models/user.php';

$master_controller = new \Controllers\Master_Controller();
$login_controller = new \Controllers\Login_Controller();
$user_model = new \Models\User_Model( array( 'table' => 'users' ) );
$message = '';

if (isset($_POST['login'])) {
    $message = $login_controller->index();
}

$title = 'Login';
$template_file = 'views/login.php';
include_once 'views/layouts/default.php';