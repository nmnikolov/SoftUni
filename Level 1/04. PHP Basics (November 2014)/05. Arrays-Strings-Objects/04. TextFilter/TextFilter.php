<?php

if (isset($_POST['text'], $_POST['banlist'])):

    $text = $_POST['text'];
    $banlist = explode(', ', $_POST['banlist']);
    $replace = [];

    foreach ($banlist as $key => $value) {
        $str = '';
        $replace[] = str_pad($str, strlen($value), "*", STR_PAD_LEFT);
        $banlist[$key] = "/$value/i";
    }

    $replaced = preg_replace($banlist, $replace, $text); ?>

    <p><span>Banlist: </span> <?= htmlentities($_POST['banlist']) ?> </p>
    <p><span>Text: </span> <?= htmlentities($text) ?> </p>
    <p><span>Replace: </span> <?= htmlentities($replaced) ?> </p>

<?php endif; ?>