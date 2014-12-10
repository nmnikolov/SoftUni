<!DOCTYPE html>
<html>
<head>
    <title>Word Mapping</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea name="text" id="text" required></textarea>
        <input type="submit" id="submit" value="Count words" />
    </form>

<?php require 'WordMapper.php' ?>

</div>
</body>
</html>