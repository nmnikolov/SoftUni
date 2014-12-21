<?php
header('Content-Type: text/html; charset=utf-8');
// Db
include 'config/db.php';
include_once 'root.php';
include_once 'lib/database.php';
include_once 'lib/auth.php';

include_once 'controllers/master_controller.php';
include_once 'controllers/topics.php';
include_once 'models/master.php';
include_once 'models/category.php';
include_once 'models/topic.php';

$db = \Lib\Database::get_instance()->get_db();
$auth = \Lib\Auth::get_instance();
$topic_controller = new \Controllers\Topic_Controller();
$category_model = new \Models\Category_Model();
$topics_model = new \Models\Topic_Model();

$message = '';

$categories = $category_model->find( array(
    'columns' => 'name'
));

if (isset($_POST['submit'])) {
    $message = $topic_controller->add($categories);
}


$title = 'Forum';
$template_file = 'views/addTopic.php';
include 'views/layouts/default.php';