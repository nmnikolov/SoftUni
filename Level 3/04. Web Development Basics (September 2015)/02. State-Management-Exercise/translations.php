<?php require_once 'localization.php' ?>

<?php
    if (isset($_GET['lang'])){
        $lang = $_GET['lang'];
        if ($lang != Localization::LANG_BG && $lang != Localization::LANG_EN){
            throw new Exception("Wrong language");
        }
        setcookie('lang', $lang);
        $_COOKIE['lang'] = $lang;
    }

    function __($tag){
        $lang = isset($_COOKIE['lang'])
            ? $_COOKIE['lang']
            : Localization::LAND_DEFAULT;

        return Localization::$string[$tag][$lang];
    }