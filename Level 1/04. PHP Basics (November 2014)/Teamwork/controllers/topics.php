<?php

namespace Controllers;

class Topic_Controller extends Master_Controller {

    public function __construct() {
        parent::__construct( get_class(), 'master', '/views/' );

    }

    public function add() {
        $auth = \Lib\Auth::get_instance();
        $topic_model = \Models\Topic_Model::get_instance();
        $category_model = \Models\Category_Model::get_instance();
        $user = $auth->get_logged_user();

        if ( ! empty( $user ) && isset( $_POST['title'], $_POST['category'], $_POST['content'])) {
            $title = $_POST['title'];
            $category = $_POST['category'];
            $content = $_POST['content'];
            $date = new \DateTime();
            $dbCategory = $category_model->find( array(
                'where' => 'name = "' . $category . '"'
            ));
            
            if (empty ($dbCategory)) {
                $message = 'Category does not exist.';
                return $message;
            }

            if (strlen($title) > 100) {
                $message = 'Name can\'t be longer than 100 symbols';
                return $message;
            }

            if ($title == '') {
                $message = 'Empty Name.';
                return $message;
            }
            
            if (strlen($content) > 2000) {
                $message = 'Content can\' be longer than 2000 symbols';
                return $message;
            }

            if ($content == '') {
                $message = 'Empty Content.';
                return $message;
            }

            if ($topic_model->add(array(
                'id' => '',
                'name' => $title,
                'content' => $content,
                'category_id' => $dbCategory[0]['id'],
                'views' => 0,
                'user_id' => $user['user_id'],
                'username' => $user['username'],
                'date_created' => $date->format('Y-m-d H:i:s')))
            ) {
                header('Location: ' . DX_ROOT_URL . 'category.php?cid=' . $dbCategory[0]['id']);
                exit;;
            } else {
                $message = 'Adding Question failed. Please try again.';
                return $message;
            }
        } elseif (! isset($_POST['category'])) {
            $message = 'Select category.';
            return $message;
        }
    }
}