<?php

class Guest {
    private $fistName;
    private $lastName;
    private $id;

    function __construct($fistName, $lastName, $id)
    {
        $this->setFistName($fistName);
        $this->setLastName($lastName);
        $this->setId($id);
    }

    public function getFistName()
    {
        return $this->fistName;
    }

    private function setFistName($fistName)
    {
        if (!is_string($fistName) || trim($fistName) == "") {
            throw new \InvalidArgumentException("First name should be string and cannot be empty.");
        }

        $this->fistName = $fistName;
    }

    public function getLastName()
    {
        return $this->lastName;
    }

    private function setLastName($lastName)
    {
        if (!is_string($lastName) || trim($lastName) == "") {
            throw new \InvalidArgumentException("Last name should be string and cannot be empty.");
        }

        $this->lastName = $lastName;
    }

    public function getId()
    {
        return $this->id;
    }

    private function setId($id)
    {
        $num = (string)$id;
        if(!(is_double($id) || is_int($id)) || !preg_match("/^\\d{10}$/", $num, $output_array)) {
            throw new \InvalidArgumentException("ID should contain exactly 10 digits.");
        }

        $this->id = (double)$id;
    }

    function __toString(){
        $result = "Name: $this->fistName $this->lastName </br>EGN: $this->id";

        return $result;
    }
}