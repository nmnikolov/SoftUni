<!DOCTYPE html>
<html>
<head>
    <title>Primes in Range</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="get">
        <label for="start">Starting Index:</label>
        <input type="text" id="start" name="start" required />
        <label for="end">End:</label>
        <input type="text" id="end" name="end" required />
        <input type="submit" value="Submit" />
    </form>

<?php require 'PrimesInRange.php' ?>

</div>
</body>
</html>