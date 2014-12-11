<?php

if (isset($_POST['text'])) :

    $text = $_POST['text'];
    preg_match_all("/<a(?:\s+(?!href).)*\s+href\s*=\s*(?:'|\")*([^\'\"]+)*(?:'|\")*(?:(?!href|>).)*>([^<]*)<\/a>/", $text, $match);

    for ($i = 0; $i < count($match[0]); $i++) {
        $replacement = '[URL=' . $match[1][$i] . ']' . $match[2][$i] . '[/URL]';
        $text = str_replace($match[0][$i], $replacement, $text);
    } ?>

<p><span>Text:</span> <?= htmlentities($_POST['text']) ?></p>
<p><span>Replace:</span> <?= htmlentities($text) ?></p>

<?php endif; ?>