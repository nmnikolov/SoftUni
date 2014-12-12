<?php
header('Content-Type: text/html; charset=utf-8');
mb_internal_encoding("utf-8");
?>

<!DOCTYPE html>
<html>
<head>
    <title>Seminar Generator</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
    <script src="js/SeminarGenerator.js" type="text/javascript" defer></script>
</head>
<body>
<div id="container">
    <form action="" method="post">
        <textarea id="text" name="text" placeholder="Enter seminars here..." required ></textarea>

        <select name="sort" id="sort" required >
            <option value="" selected disabled >-Sort by-</option>
            <option value="name">Name</option>
            <option value="date">Date</option>
        </select>

        <select name="sort-type" id="sort-type" required >
            <option value="" selected disabled>-Sort type-</option>
            <option value="ascending">Ascending</option>
            <option value="descending ">Descending </option>
        </select>

        <input type="submit" id="submit" value="Generate" />
    </form>

<?php require 'SeminarGenerator.php' ?>

</div>
</body>
</html>