<!DOCTYPE html>
<html>
<head>
    <title>Primes In Range</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <input type="text" id="string" name="string" required />

        <input type="radio" id="palindrome" name="option" value="Check Palindrome" required >
        <label for="palindrome">Check Palindrome</label>
        <input type="radio" id="reverse" name="option" value="Reverse String" >
        <label for="reverse">Reverse String</label>
        <input type="radio" id="split" name="option" value="Split" >
        <label for="split">Split</label>
        <input type="radio" id="hash" name="option" value="Hash String" >
        <label for="hash">Hash String</label>
        <input type="radio" id="shuffle" name="option" value="Shuffle String" >
        <label for="shuffle">Shuffle String</label>

        <input type="submit" id="submit" value="Submit" />
    </form>

<?php require 'StringModifier.php' ?>

</div>
</body>
</html>