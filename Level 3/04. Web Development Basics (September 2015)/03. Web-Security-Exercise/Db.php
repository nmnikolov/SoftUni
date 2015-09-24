<?php

require_once 'DbConfig.php';

class Db
{
    /**
     * @var \PDO
     */
    private $conn;
    /**
     * @var \PDOStatement
     */
    private $stmt;
    /**
     * @var Db
     */
    private static $inst = null;
    private function __construct()
    {
        $dsn = 'mysql:dbname='.DbConfig::DBNAME .';host='. DbConfig::HOST;
        $this->conn = new \PDO($dsn, DbConfig::USER, DbConfig::PASS);
    }
    public static function setInstance()
    {
        if (self::$inst == null)
        {
            self::$inst = new self();
        }
    }
    /**
     * @return Db
     */
    public static function getInstance()
    {
        if (self::$inst == null)
        {
            self::setInstance();
        }

        return self::$inst;
    }
    /**
     * @param $query
     * @param array $params
     */
    public function query($query, array $params = [])
    {
        $this->stmt = $this->conn->prepare($query);
        $this->stmt->execute($params);
    }
    /**
     * @return array
     */
    public function fetchAll()
    {
        return $this->stmt->fetchAll(PDO::FETCH_ASSOC);
    }
    /**
     * @return mixed
     */
    public function row()
    {
        return $this->stmt->fetch();
    }
    /**
     * @return int
     */
    public function rows()
    {
        return $this->stmt->rowCount();
    }
}