<!DOCTYPE html>
<html>
<head>
    <title>Pretty Text Hasher</title>
    <!--    <link type="text/css" rel="stylesheet" href="styles/style.css">-->
</head>
<body>
<div id="container">
    <form action="" method="get">
        <div>
            Text:
            <input type="text" name="text"/>
        </div>
        <div>
            Blacklist:
            <textarea name="blacklist"></textarea>
        </div>

        <input type="submit" id="submit" value="Submit" />
    </form>

<?php

//if (isset($_GET['text'], $_GET['blacklist'])) {

    $text = $_GET['text'];
    $blacklist = explode("\n", $_GET['blacklist']);

    $pattern = '/[a-zA-Z\d\-+_]+@[a-zA-Z\d-]+.[a-zA-Z\d-.]+[a-zA-Z\d]/';

    preg_match_all($pattern, $text, $emails);

    foreach ($blacklist as $pattern) {
        $pattern = trim($pattern);
        $pattern = str_replace('.', '\.', $pattern);
        $pattern = str_replace('*', '.+', $pattern);
        $pattern = "/" . $pattern . "$/";

        foreach ($emails[0] as $email) {

            if (preg_match($pattern, $email)) {
                $replacement = str_repeat('*', strlen($email));
                $text = str_replace($email, $replacement, $text);
            }
        }
    }

        foreach ($emails[0] as $email) {
            $pos = strpos($text, $email);
            //var_dump($email);
            //$pattern = "/" . $email . "$/";

            if ($pos !== false) {
                $replacement = '<a href="mailto:' . $email . '">' . $email . '</a>';
                $text = str_replace($email, $replacement, $text);
            }

        }

    $text = "<p>" . $text . "</p>";
    echo $text;

//}

?>

</div>
</body>
</html>