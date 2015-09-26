<?php

namespace SoftUni\ViewModels;

class ProfileInformation
{
    public $error = false;
    public $success = false;

    /**
     * @var User
     */
    private $user = null;

    public function setUser(User $user){
        $this->user = $user;
    }

    public function getUser(){
        return $this->user;
    }
}