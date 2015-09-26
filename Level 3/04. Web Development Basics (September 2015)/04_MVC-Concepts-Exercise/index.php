<?php
use SoftUni\Config\DatabaseConfig;
use SoftUni\Core\Database;

session_start();

require_once 'Autoloader.php';

\SoftUni\Autoloader::init();

$uri = $_SERVER['REQUEST_URI'];
$self = $_SERVER['PHP_SELF'];
$index = basename($self);
$directories = str_replace($index, '', $self);
$requestString = str_replace($directories, '', $uri);
$requestParams = explode("/", $requestString);

$controller = array_shift($requestParams);
$action = array_shift($requestParams);

Database::setInstance(
    DatabaseConfig::DB_INSTANCE,
    DatabaseConfig::DB_DRIVER,
    DatabaseConfig::DB_USER,
    DatabaseConfig::DB_PASS,
    DatabaseConfig::DB_NAME,
    DatabaseConfig::DB_HOST
);

$app = new \SoftUni\Application($controller, $action, $requestParams);
$app->start();