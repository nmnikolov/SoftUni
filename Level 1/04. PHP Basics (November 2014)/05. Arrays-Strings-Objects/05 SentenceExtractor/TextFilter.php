<?php
header('Content-Type: text/html; charset=utf-8');
mb_internal_encoding("utf-8");

if (isset($_POST['text'], $_POST['word'])) :
    $text = $_POST['text'];
    $word = $_POST['word'];
    $isFound = false;

    preg_match_all('/[^.!?\s]{1}[^.!?]*[.?!]+/', $text, $sentences); ?>

    <p><span>Text:</span> <?= htmlentities($text); ?> </p>
    <p><span>Word:</span> <?= htmlentities($word); ?> </p>
    <p id="result">Sentences:</p>

    <ul>
        <?php foreach ($sentences[0] as $value) :
            if (preg_match("/\b$word\b/i", $value)) :
                $isFound = true; ?>
                <li> <?= htmlentities($value); ?> </li>
            <?php endif;
        endforeach; ?>
    </ul>

    <?php if (!$isFound) : ?>
        <p>No match!</p>
    <?php endif;

endif; ?>