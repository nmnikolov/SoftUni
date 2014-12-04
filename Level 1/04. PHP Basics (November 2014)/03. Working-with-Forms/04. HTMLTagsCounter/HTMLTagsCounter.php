<?php

session_start();
$tags = ['!DOCTYPE', 'a', 'abbr', 'address', 'area', 'article', 'aside', 'audio', 'b', 'base', 'bdi', 'bdo',
'blockquote', 'body', 'br','button', 'canvas', 'caption', 'cite', 'code', 'col', 'colgroup', 'command', 'datalist',
'dd', 'del', 'details','dfn', 'div', 'dl', 'dt', 'em', 'embed', 'fieldset', 'figcaption', 'figure', 'footer', 'form',
'h1 - h6', 'head','header', 'hgroup', 'hr', 'html', 'i', 'iframe', 'img', 'input', 'ins', 'kbd', 'keygen', 'label',
'legend', 'li', 'link','map', 'mark', 'menu', 'meta', 'meter', 'nav', 'noscript', 'object', 'ol', 'optgroup', 'option',
'output', 'p', 'param', 'pre','progress', 'q', 'rp', 'rt', 'ruby', 's', 'samp', 'script', 'section', 'select', 'small',
'source', 'span','strong', 'style', 'sub', 'summary', 'sup', 'table', 'tbody', 'td', 'textarea', 'tfoot', 'th', 'thead',
'time', 'title','tr', 'track', 'u', 'ul', 'var', 'video', 'wbr', ];
?>

<!DOCTYPE html>
<html>
<head>
    <title>HTML Tag Counter</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="get">
        <label for="tag">Enter HTML tag:</label>
        <input type="text" name="tag" id="tag"/>
        <input type="submit" value="Submit">
    </form>

    <?php if (isset($_GET['tag'])):
        if (!isset($_SESSION['count'])):
            $_SESSION['count'] = 0;
        endif;

        if (in_array($_GET['tag'], $tags)):
            $_SESSION['count']++; ?>
            <p><strong>Valid HTML tag!</strong></p>
        <?php else: ?>
            <p><strong>Invalid HTML tag!</strong></p>
        <?php endif; ?>

        <p><strong>Score: <?= $_SESSION['count'] ?></strong></p>
    <?php endif ?>
</div>
</body>
</html>