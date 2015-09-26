<?php

namespace SoftUni\Core;


class Statement
{
    /**
     * @var \PDOStatement
     */
    private $stmt = null;

    public function __construct(\PDOStatement $stmt){
        $this->stmt = $stmt;
    }

    public function fetch($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, $variable, $dataType = \PDO::PARAM_STR, $length = null, $driverOptions = null){
        return $this->stmt->bindParam($parameter, $variable, $dataType, $length, $driverOptions);
    }

    public function rowCount(){
        return $this->stmt->rowCount();
    }

    public function execute($params = []){
        $this->stmt->execute($params);
    }
}