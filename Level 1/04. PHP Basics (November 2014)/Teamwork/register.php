<?php

include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'controllers/users.php';

include_once 'models/master.php';
include_once 'models/user.php';

$master_controller = new \Controllers\Master_Controller();
$register_controller = new \Controllers\Users_Controller();
$user_model = new \Models\Master_Model(array('table' => 'users'));
$user_model = new \Models\User_Model();
$message = '';

if (isset($_POST['register'])) {
    $message = $register_controller->register();

    if ($message === true) {
        $message = 'Successfully registered.';
    }
}

$title = 'Register';
$template_file = 'views/register.php';
include_once 'views/layouts/default.php';