<?php

namespace SoftUni\ViewModels;

use SoftUni\Core\BuildingsRepository;

class BuildingsInformation
{
    public $error = false;
    public $success = false;

    /**
     * @var User
     */
    private $user = null;

    /**
     * @var Array
     */
    private $buildings = [];

    public function setUser(User $user){
        $this->user = $user;
    }

    public function getUser(){
        return $this->user;
    }

    public function getBuildings(){
        return $this->buildings;
    }

    public function setBuildings(Array $buildings = []){
        $this->buildings = $buildings;
    }
}