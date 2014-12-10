<!DOCTYPE html>
<html>
<head>
    <title>Coloring Texts</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea name="text" id="text" required></textarea>
        <input type="submit" id="submit" value="Color text" />
    </form>

<?php require 'TextColorer.php' ?>

</div>
</body>
</html>