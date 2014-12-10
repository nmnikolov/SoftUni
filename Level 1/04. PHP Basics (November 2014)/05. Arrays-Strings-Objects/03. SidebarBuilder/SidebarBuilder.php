<?php

$sections = [
    'categories' => isset($_POST['categories']) ? preg_split('/, /', $_POST['categories'], -1, PREG_SPLIT_NO_EMPTY) : [],
    'tags' => isset($_POST['tags']) ? preg_split('/, /', $_POST['tags'], -1, PREG_SPLIT_NO_EMPTY) : [],
    'months' => isset($_POST['months']) ? preg_split('/, /', $_POST['months'], -1, PREG_SPLIT_NO_EMPTY) : []
];

foreach ($sections as $key => $section):
    if (!empty($section)) : ?>

        <article id="<?= $key ?>">
            <h1> <?= $key ?></h1>
            <ul>
                <?php foreach ($section as $value): ?>
                    <li> <?= $value ?> </li>
                <?php endforeach; ?>
            </ul>
        </article>
    <?php endif;
endforeach; ?>