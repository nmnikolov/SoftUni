<?php

namespace SoftUni\Controllers;

abstract class Controller
{
    public function __construct(){

    }

    public function isLogged(){
        return isset($_SESSION['id']);
    }
}