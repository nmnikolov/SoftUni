<?php
header('Content-Type: text/html; charset=utf-8');
mb_internal_encoding("utf-8");
?>

<!DOCTYPE html>
<html>
<head>
    <title>URL Replacer</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea id="text" name="text" placeholder="Enter text here..." required ></textarea>
        <input type="submit" id="submit" value="Replace" />
    </form>

<?php require 'URLReplacer.php' ?>

</div>
</body>
</html>