<?php
    require_once 'localization.php';
    require_once 'Db.php';
?>

<?php
    if (isset($_GET['lang'])){
        $lang = htmlspecialchars($_GET['lang']);

        $db = Db::getInstance();
        $query = "SHOW COLUMNS FROM translations";
        $db->query($query, []);
        $rows = $db->fetchAll();

        $possibleLanguages = [];

        foreach($rows as $row){
            foreach($row as $test){
                if(strpos($test, 'text_') === 0){
                    array_push($possibleLanguages, str_replace('text_', '', $test));
                }
            }
        }

        Localization::$possibleLanguages = $possibleLanguages;
        Localization::$LANG_DEFAULT = $possibleLanguages[0];

        if (!in_array($lang, Localization::$possibleLanguages)){
            $requestPath = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
            header("Location: " . $requestPath);
            exit;
        }
        setcookie('lang', $lang);
        $_COOKIE['lang'] = $lang;
    }

    function __($tag){
        $lang = isset($_COOKIE['lang'])
            ? htmlspecialchars($_COOKIE['lang'])
            : Localization::$LANG_DEFAULT;

        $db = Db::getInstance();
        $query = "SELECT text_{$lang} FROM translations WHERE tag = '$tag'";
        $db->query($query, [$lang, $tag]);
        $row = $db->fetchAll();

        return $row[0]['text_' . $lang];
    }