<?php

namespace SoftUni;

class Application
{
    private $controllerName;
    private $actionName;
    private $requestParams = [];

    private $controller;

    const CONTROLLERS_NAMESPACE = 'SoftUni\\Controllers\\';
    const Controllers_SUFFIX = 'Controller';

    public function __construct($controllerName, $actionName, $requestParams = []){
        $this->controllerName = $controllerName;
        $this->actionName = $actionName;
        $this->requestParams = $requestParams;
    }

    public function start(){
        $this->initController();

        VIEW::$controllerName = $this->controllerName;
        VIEW::$actionName = $this->actionName;

        call_user_func_array(
            [
                $this->controller,
                $this->actionName
            ],
            $this->requestParams
        );
    }

    private function initController(){
        $controllerName = self::CONTROLLERS_NAMESPACE
            . $this->controllerName
            . self::Controllers_SUFFIX;

        $this->controller = new $controllerName();
    }

//    /**
//     * @var Database
//     */
//    private $db;
//
//    /**
//     * @var User
//     */
//    private $user = null;
//
//    /**
//     * @var BuildingsRepository
//     */
//    private $buildingsReposotory = null;
//
//    public function __construct(Database $db){
//        $this->db = $db;
//    }
//
//    public function isLogged(){
//        return isset($_SESSION['id']);
//    }
//
//    /**
//     * @param $username
//     * @return bool
//     */
//    public function userExists($username){
//        $result = $this->db->prepare("SELECT id FROM users WHERE username = ?");
//        $result->execute([$username]);
//
//        return $result->rowCount() > 0;
//    }
//
//    public function register($username, $password){
//        if ($this->userExists($username)){
//            throw new \Exception('User already registered');
//        }
//
//        $result = $this->db->prepare("INSERT INTO users (username, password, gold, food)
//          VALUES (?, ?, ?, ?)");
//
//        $result->execute([
//            $username,
//            password_hash($password, PASSWORD_DEFAULT),
//            USER::GOLD_DEFAULT,
//            USER::FOOD_DEFAULT]
//        );
//
//        if ($result->rowCount() > 0){
//            $userId = $this->db->lastId();
//            $this->db->query(
//                "INSERT INTO user_buildings(user_id, building_id, level_id)
//                 SELECT $userId, id, 0 FROM buildings"
//            );
//
//            return true;
//        }
//
//        throw new \Exception('Cannot register user');
//    }
//
//    public function login($username, $password){
//        $result = $this->db->prepare("SELECT id, username, password, gold, food FROM users WHERE username = ?");
//        $result->execute([$username]);
//
//        if ($result->rowCount() === 0){
//            throw new \Exception("User does not exist");
//        }
//
//        $userRow = $result->fetch();
//
//        if (password_verify($password, $userRow['password'])){
//            $_SESSION['id'] = $userRow['id'];
//            $this->user = new User(
//                $userRow['username'],
//                $userRow['password'],
//                $userRow['id'],
//                $userRow['gold'],
//                $userRow['food']
//            );
//
//            return $this->user;
//        }
//
//        throw new \Exception("Passwords does not match");
//    }
//
//    public function getUserInfo($id){
//        $result = $this->db->prepare("SELECT id, username, password, gold, food FROM users WHERE id = ?");
//        $result->execute([$id]);
//
//        return $result->fetch();
//    }
//
//    public function getUser(){
//        if ($this->user != null){
//            return $this->user;
//        }
//
//        if ($this->isLogged()){
//            $userRow = $this->getUserInfo($_SESSION['id']);
//
//            $this->user = new User(
//                $userRow['username'],
//                $userRow['password'],
//                $userRow['id'],
//                $userRow['gold'],
//                $userRow['food']
//            );
//
//            return $this->user;
//        }
//
//        return null;
//    }
//
//    public function editUser(User $user){
//        $result = $this->db->prepare("UPDATE users SET password = ?, username = ? WHERE id = ?");
//        $result->execute([
//            password_hash($user->getPass(), PASSWORD_DEFAULT),
//            $user->getUsername(),
//            $user->getId()
//        ]);
//
//        return $result->rowCount() > 0;
//    }
//
//    public function createBuildings(){
//        if ($this->buildingsReposotory == null){
//            $this->buildingsReposotory = new BuildingsRepository($this->db, $this->getUser());
//        }
//
//        return $this->buildingsReposotory;
//    }
}