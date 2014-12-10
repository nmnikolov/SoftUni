<?php

if (isset($_POST['text'])):

    $words = str_word_count($_POST['text'], 2);
    $wordsCount = array_count_values(array_map('strtolower', $words)); ?>

    <p> <span>Text: </span> <?= htmlentities($_POST['text']) ?></p>

    <?php if (empty($wordsCount)): ?>
        <p>No words in the text.</p>
    <?php else: ?>
        <table>
            <thead>
                <tr>
                    <th>Word</th>
                    <th>Count</th>
                </tr>
            </thead>
            <tbody>
                <?php foreach ($wordsCount as $key => $value): ?>
                    <tr>
                        <td> <?= htmlentities($key); ?></td>
                        <td> <?= $value; ?> </td>
                    </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    <?php endif;

endif; ?>