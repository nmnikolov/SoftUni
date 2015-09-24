<?php
session_start();

spl_autoload_register(function($class){
    $classPath = str_replace('\\', DIRECTORY_SEPARATOR, $class);
    require_once $classPath . '.php';
});

require_once 'core/app.php';

\Core\Database::setInstance(
    \Config\DatabaseConfig::DB_INSTANCE,
    \Config\DatabaseConfig::DB_DRIVER,
    \Config\DatabaseConfig::DB_USER,
    \Config\DatabaseConfig::DB_PASS,
    \Config\DatabaseConfig::DB_NAME,
    \Config\DatabaseConfig::DB_HOST
);

$app = new \Core\App(
    \Core\Database::getInstance(\Config\DatabaseConfig::DB_INSTANCE)
);

function loadTemplate($templateName, $data = null){
    require_once 'templates/' . $templateName . '.php';
}