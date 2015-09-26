<?php

namespace SoftUni\Helpers;

class Helpers
{
    public static function url(){
        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);

        return $directories;
    }
}