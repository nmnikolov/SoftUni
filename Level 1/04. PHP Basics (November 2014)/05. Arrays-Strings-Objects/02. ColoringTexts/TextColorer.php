<?php

if (isset($_POST['text'])):
    $string = preg_replace('/\s/','',$_POST['text']);
    $chars = str_split($string);

    foreach ($chars as $char):
        if (ord($char) % 2 == 0): ?>
            <span class="red"> <?= $char ?> </span>
        <?php else: ?>
            <span class="blue"> <?= $char ?> </span>
        <?php endif;
    endforeach;
endif;
?>