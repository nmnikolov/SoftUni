<?php

if (isset($_POST['text'], $_POST['banlist'])):

    $text = $_POST['text'];
    $banlist = explode(', ', $_POST['banlist']);
    $replace = [];

    foreach ($banlist as $key => $value) {
        $replacement = str_repeat('*', strlen($value));
        $text = str_ireplace($value, $replacement, $text);
    } ?>

    <p><span>Banlist: </span> <?= htmlentities($_POST['banlist']) ?> </p>
    <p><span>Text: </span> <?= htmlentities($_POST['text']) ?> </p>
    <p><span>Replace: </span> <?= htmlentities($text) ?> </p>

<?php endif; ?>