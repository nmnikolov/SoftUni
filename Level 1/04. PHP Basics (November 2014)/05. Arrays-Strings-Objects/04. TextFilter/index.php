<!DOCTYPE html>
<html>
<head>
    <title>Text Filter</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea id="text" name="text" placeholder="Enter text here..." required ></textarea>
        <input type="text" id="banlist" name="banlist" placeholder="Enter banlist here. Separate entries with ', '" required />

        <input type="submit" id="submit" value="Filter" />
    </form>

<?php require 'TextFilter.php' ?>

</div>
</body>
</html>