<?php

namespace Core\Drivers;

class DriverFactory
{
    public static function Create($driver, $user, $pass, $dbName, $host){
        switch(strtolower($driver)){
            case 'mysql':
                return new \Core\Drivers\MySqlDriver($user, $pass, $dbName, $host);
            default:
                throw new \Exception('non-existing driver');
        }
    }
}