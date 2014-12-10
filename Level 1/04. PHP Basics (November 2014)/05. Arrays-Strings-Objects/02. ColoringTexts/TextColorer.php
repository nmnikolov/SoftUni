<?php

if (isset($_POST['text'])):
    $string = preg_replace('/\s/','',$_POST['text']);
    $chars = str_split($string);

    foreach ($chars as $char):
        $color = ord($char) % 2 == 0 ? "red" : "blue"; ?>
        <span class="<?= $color ?>"> <?= $char ?> </span>
    <?php endforeach;
endif; ?>