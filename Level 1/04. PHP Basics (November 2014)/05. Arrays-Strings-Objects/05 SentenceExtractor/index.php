<!DOCTYPE html>
<html>
<head>
    <title>Sentence Extractor</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea id="text" name="text" placeholder="Enter text here..." required ></textarea>
        <input type="text" id="word" name="word" placeholder="Enter word here..." required />
        <input type="submit" id="submit" value="Extract" />
    </form>

<?php require 'TextFilter.php' ?>

</div>
</body>
</html>