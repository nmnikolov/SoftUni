<?php
header_remove('Cache-Control');
header('Content-Type: text/html; charset=utf-8');
// Db
include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'models/master.php';
include_once 'models/category.php';

$db = \Lib\Database::get_instance()->get_db();
$auth = \Lib\Auth::get_instance();

$category_model = new \Models\Category_Model();
$categories = $category_model->find();

if (isset($_GET['logout'])) {
    Lib\Auth::get_instance()->logout();
    header( 'Location: ' . DX_ROOT_URL );
    exit;
}

$title = 'Forum';
$template_file = 'views/index.php';
include 'views/layouts/default.php';