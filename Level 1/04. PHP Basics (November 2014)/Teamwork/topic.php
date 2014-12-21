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
include_once 'models/answer.php';

$db = \Lib\Database::get_instance()->get_db();
$auth = \Lib\Auth::get_instance();
$topics_model = new \Models\Topic_Model();
$answer_model = new \Models\Answer_Model();

$message = '';

if (isset($_GET['tid'])) {
    $tid = $_GET['tid'];
    $topic = $topics_model->find( array(
        'where' => 'id = "' . $tid . '"'
        )
    );

    if (! empty ($topic) ) {
        $views = $topic[0]['views'] + 1;

        $topics_model->update(array(
            'id' => $tid,
            'views' => $views
        ));
    }
    else {
        header('Location: ' . DX_ROOT_URL);
    }

} else {
    header('Location: ' . DX_ROOT_URL);
}

$answers = $answer_model->find( array(
    'where' => 'topic_id = "' . $tid . '"'
));

if (count($answers) <= PER_PAGE) {
    $initialPages = 1;
} elseif (count($answers) % PER_PAGE === 0) {
    $initialPages = intval(count($answers) / PER_PAGE);
} else {
    $initialPages = intval(count($answers) / PER_PAGE + 1);
}

if (!isset($_GET['page']) || $_GET['page'] > $initialPages || $_GET['page'] === '') {
    header('Location: ' . DX_ROOT_URL . 'topic.php?tid=' . $tid . '&page=1');
    exit;
}

$pages = $initialPages;
if ($initialPages > 3) {
    $pages = 3 + $_GET['page'];
}

$pageAnswers = $answer_model->find( array(
    'where' => 'topic_id = "' . $tid . '"',
    'limit' => ((intval($_GET['page']) * PER_PAGE) - PER_PAGE) . ", " . PER_PAGE
));

if (isset($_POST['content']) && $auth->is_logged_in()) {
    if (! empty($_POST['content'])) {
        $date = new \DateTime();
        if ($answer_model->add(array(
                'id' => '',
                'content' => $_POST['content'],
                'topic_id' => $_GET['tid'],
                'date_created' => $date->format('Y-m-d H:i:s'),
                'user_id' => $_SESSION['user_id'],
                'username' => $_SESSION['username']
            )) > 0) {
            header( 'Location: ' . DX_ROOT_URL . 'topic.php?tid=' . $tid );
            exit;
        } else {
            $message = "Error while posting your answer. Please try again." ;
        }
    } else {
        $message = "Can't add empty answer.";
    }
}

if (isset($_GET['logout'])) {
    Lib\Auth::get_instance()->logout();
    header( 'Location: ' . DX_ROOT_URL );
    exit;
}

$title = 'Forum';
$template_file = 'views/topic.php';
include 'views/layouts/default.php';