<?php

namespace SoftUni\Controllers;

use SoftUni\Core\BuildingsRepository;
use SoftUni\Core\Database;
use SoftUni\Helpers\Helpers;
use SoftUni\Models\User;
use SoftUni\View;
use SoftUni\ViewModels\BuildingsInformation;
use SoftUni\ViewModels\LoginInformation;
use SoftUni\ViewModels\ProfileInformation;
use SoftUni\ViewModels\RegisterInformation;

class UsersController extends  Controller
{    public function __construct()
    {
    }

    private function initLogin($user, $pass){
        $userModel = new User();

        $userId = $userModel->login($user, $pass);
        $_SESSION['id'] = $userId;
        header('Location: profile');
    }

    public function register(){
        $viewModel = new RegisterInformation();

        if (isset($_POST['username'], $_POST['password'])){
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $userModel = new User();
                $userModel->register($user, $pass);

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function login(){
        $viewModel = new LoginInformation();

        if (isset($_POST['username'], $_POST['password'])){
            try {
                $user = $_POST['username'];
                $pass = $_POST['password'];

                $this->initLogin($user, $pass);
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function logout(){
        if(!$this->isLogged()){
            header("Location: " . Helpers::url() . 'users/login');
            exit;
        }

        unset($_SESSION['id']);
        header("Location: " . Helpers::url() . 'users/login');
        exit;
    }

    public function profile(){
        if(!$this->isLogged()){
            header("Location: " . Helpers::url() . 'users/login');
            exit;
        }

        $userModel = new User();
        $viewModel = new ProfileInformation();
        $userRow = $userModel->getInfo($_SESSION['id']);

        $user = new \SoftUni\ViewModels\User(
            $userRow['username'],
            $userRow['password'],
            $userRow['id'],
            $userRow['gold'],
            $userRow['food']
        );
        $viewModel->setUser($user);

        if (isset($_POST['edit'])){
            try {
                if ($_POST['password'] != $_POST['confirm'] || empty($_POST['password'])){
                    throw new \Exception('Empty password or passwords does not match');
                }

                $user = new \SoftUni\ViewModels\User(
                    $_POST['username'],
                    $_POST['password'],
                    $_SESSION['id']
                );
                if ($userModel->edit($user)){
                    $viewModel->getUser()->setUsername($user->getUsername());
                    $viewModel->success = 'Edit successful';
                }
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }

    public function buildings($buildingId = null){
        if(!$this->isLogged()){
            header("Location: " . Helpers::url() . 'users/login');
            exit;
        }

        $userModel = new User();
        $viewModel = new BuildingsInformation();
        $userRow = $userModel->getInfo($_SESSION['id']);
        $user = new \SoftUni\ViewModels\User(
            $userRow['username'],
            $userRow['password'],
            $userRow['id'],
            $userRow['gold'],
            $userRow['food']
        );

        $buildingsRepository = new BuildingsRepository(Database::getInstance('app'), $user);
        $buildings = $buildingsRepository->getBuildings();

        $viewModel->setUser($user);
        $viewModel->setBuildings($buildings);

        if($buildingId != null){
            try {
                if($buildingsRepository->evolve($buildingId)){
                    header("Location: " . Helpers::url() . 'users/buildings');
                    exit;
                }
            } catch (\Exception $e) {
                $viewModel->error = $e->getMessage();
                return new View($viewModel);
            }
        }

        return new View($viewModel);
    }
}