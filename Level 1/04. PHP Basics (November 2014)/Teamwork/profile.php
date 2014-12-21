<?php
// Db
include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'controllers/users.php';
include_once 'models/master.php';
include_once 'models/user.php';
include_once 'models/topic.php';

$db = \Lib\Database::get_instance()->get_db();
$auth = \Lib\Auth::get_instance();
$register_controller = new \Controllers\Users_Controller();
//
$topics_model = new \Models\Topic_Model();
$user_model = new \Models\User_Model();
$message = '';
$message1 = '';

if (isset($_GET['mid'])) {
    $mid = $_GET['mid'];

    $user = $user_model->find( array(
            'where' => 'id = "' . $mid . '"'
        )
    );

    if (empty ($user)) {
        header('Location: ' . DX_ROOT_URL);
        exit;
    }
} else {
    header('Location: ' . DX_ROOT_URL);
    exit;
}

$member = $user_model->get($mid);
$topics = $topics_model->find( array(
    'where' => 'user_id = "' . $mid . '"'
));

if (isset($_POST['name'], $_POST['email'])) {
    $message = $register_controller->update(array(
        'id' => $_SESSION['user_id'],
        'name' => $_POST['name'],
        'email' => $_POST['email']));
}

if (isset($_POST['curr-password'], $_POST['password'], $_POST['confirm-pass'])) {
    $message1 = $register_controller->update(array(
        'id' => $_SESSION['user_id'],
        'curr-password' => $_POST['curr-password'],
        'password' => $_POST['password'],
        'confirm-pass' => $_POST['confirm-pass']));
}

if (isset($_GET['logout'])) {
    Lib\Auth::get_instance()->logout();
    header( 'Location: ' . DX_ROOT_URL );
}

$title = 'Profile';
$template_file = 'views/profile.php';
include 'views/layouts/default.php';