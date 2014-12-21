<?php

namespace Controllers;

class Login_Controller extends Master_Controller {
	
	public function __construct() {
		parent::__construct( get_class(), 'master', '/views/' );
		
		// $this->model = new \Models\Artist();
		//echo "Login Controller created<br />";
	}
	
	public function index() {
		$auth = \Lib\Auth::get_instance();
		
		$login_text = '';
		$user = $auth->get_logged_user();

		if ( empty( $user ) && isset( $_POST['username'] ) && isset( $_POST['password'] ) ) {

			$hashPassword = hash('sha256', $_POST['password']);
			
			$logged_in = $auth->login( $_POST['username'], $hashPassword );
			
			if ( ! $logged_in ) {
				return 'Login failed. Pleasy try again.';

			} else {
				header( 'Location: ' . DX_ROOT_URL );
				exit;
			}
		}
		
		$template_file = DX_ROOT_DIR . $this->views_dir . 'users.php';
	}
	
	public function logout() {
		$auth = \Lib\Auth::get_instance();
		
		$auth->logout();
		
		header( 'Location: ' . DX_ROOT_URL );
		exit();
	}
}