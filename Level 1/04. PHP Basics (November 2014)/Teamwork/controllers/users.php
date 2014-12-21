<?php

namespace Controllers;

use Models\User_Model;

class Users_Controller extends Master_Controller {
	
	public function __construct() {
		parent::__construct( get_class(), 'user', '/views/' );

		//echo "Register Controller created<br />";
	}
	
	public function register() {
		$auth = \Lib\Auth::get_instance();
		$userModel = \Models\User_Model::get_instance();

		$user = $auth->get_logged_user();

		if ( empty( $user ) && isset( $_POST['name'], $_POST['username'], $_POST['password'], $_POST['confirm'], $_POST['email'] )) {
            $name = $_POST['name'];
			$username = $_POST['username'];
			$password = $_POST['password'];
			$confirmPassword = $_POST['confirm'];
			$email = $_POST['email'];
            $date = new \DateTime();
			$logged_in = $auth->is_logged_in();

            $findUser = $userModel->find( array(
                    'table' => 'users',
                    'columns' => 'username',
                    'where' => 'username = "' . $_POST['username'] . '"'
                )
            );

			if ( $logged_in ) {
                $message = "Can't register while logged in!";
                return $message;
			}
            
            if (! empty ($findUser)) {
                $message = "Username already in use.";
                return $message;
            }
			$patterns = [
                'name' => '/^[a-zA-Z\d ]{3,20}$/',
				'username' => '/^[a-zA-Z\d_-]{3,30}$/',
				'password' => '/^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,30}$/',
				'email' => '/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/'
			];

            if (!preg_match($patterns['name'], $name)) {
                $message = "Only letters and numbers between 3 and 20 symbols are allowed for Name";
                return $message;
            }

			if (!preg_match($patterns['username'], $username)) {
                $message = "Only letters, numbers, '_' and '-' between 3 and 30 symbols are allowed for Username";
                return $message;
			}
			if (!preg_match($patterns['password'], $password)) {
                $message = "Enter at least 1 uppercase letter, number and special symbol. Password must be between 8 and 30 symbols.";
                return $message;
			}

			if ($password !== $confirmPassword) {
                $message = "Different passwords!";
                return $message;
			}

			if (!preg_match($patterns['email'], $email)) {
                $message = "Invalid Email";
                return $message;
			}

            $hashPassword = hash('sha256', $password);

			if ($userModel->add(array(
				'id' => '',
				'username' => $username,
                'name' => $name,
				'password' => $hashPassword,
				'email' => $email,
                'register_date' => $date->format('Y-m-d H:i:s')))
			) {
                return true;
            } else {
                $message = 'Registration failed. Please try again.';
                return $message;
            }
		}
	}

    public function update($arr) {
        $auth = \Lib\Auth::get_instance();
        $userModel = User_Model::get_instance();
        $currentPassword = $userModel->find( array(
                'table' => 'users',
                'columns' => 'password',
                'where' => 'id = "' . $_SESSION['user_id'] . '"'
            )
        );

        $patterns = [
            'name' => '/^[a-zA-Z\d ]{3,20}$/',
            'username' => '/^[a-zA-Z\d_-]{3,30}$/',
            'password' => '/^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,30}$/',
            'email' => '/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/'
        ];

        foreach ($arr as $key => $value) {

            switch ($key) {
                case "name":
                    if (!preg_match($patterns['name'], $value)) {
                        $message = "Only letters and numbers are allowed for Name";
                        return $message;
                    }
                    break;
                case 'email':
                    if (!preg_match($patterns['email'], $value)) {
                        $message = "Only letters, numbers, one '@' and one '.' are allowed for Email";
                        return $message;
                     }
                    break;
                case 'curr-password':
                    $value = hash('sha256', $value);
                    if ($value !== $currentPassword[0]['password']) {
                        $message = "Current password does not match.";
                        return $message;
                    }
                    unset($arr['curr-password']);
                    break;
                case 'password':
                    if (!preg_match($patterns['password'], $value)) {
                        $message = "Enter at least 1 uppercase letter, number and special symbol. Password must be between 8 and 30 symbols.";
                        return $message;
                    }
                    if ($value !== $arr['confirm-pass']) {
                        $message = "Confirm password does not match.";
                        return $message;
                    }
                    unset($arr['confirm-pass']);

                    $arr['password'] = hash('sha256', $arr['password']);
                    break;
            }
        }

        if ($userModel->update($arr)) {
            header( 'Location: ' .DX_ROOT_URL . 'profile.php?mid=' . $_SESSION['user_id'] );
            exit;
        } else {
            return 'The were no changes to make.';
        }
    }
}