<?php
header('Content-Type: text/html; charset=utf-8');
// Db
include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'models/master.php';
include_once 'models/category.php';
include_once 'models/topic.php';

$db = \Lib\Database::get_instance()->get_db();
$auth = \Lib\Auth::get_instance();

$topics_model = new \Models\Topic_Model();

if (isset($_GET['cid'])) {
    $cid = $_GET['cid'];
    $topics = $topics_model->find( array(
        'where' => 'category_id = "' . $cid . '"'
        )
    );

    if (empty ($topics)) {
        header('Location: ' . DX_ROOT_URL);
        exit;
    }
} else {
    header('Location: ' . DX_ROOT_URL);
    exit;
}

if (isset($_GET['logout'])) {
    Lib\Auth::get_instance()->logout();
    header( 'Location: ' . DX_ROOT_URL );
    exit;
}

$title='Forum';
$template_file = 'views/category.php';
include 'views/layouts/default.php';