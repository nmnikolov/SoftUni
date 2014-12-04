<!DOCTYPE html>
<html>
<head>
    <title>Print Tags</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="PrintTags.php" method="get">
        <label for="tags">Enter Tags:</label>
        <input type="text" id="tags" name="tags" />
        <input type="submit" value="Submit">
    </form>

    <?php if (isset($_GET['tags']) && $_GET['tags'] != ''): ?>
        <ul>
            <?php $tags = explode(', ', $_GET['tags']); ?>
            <?php for ($i = 0; $i < count($tags); $i++): ?>
                <li><?= htmlentities($i) ?> : <?= htmlentities($tags[$i]) ?></li>
            <?php endfor ?>
        </ul>
    <?php endif ?>
</div>
</body>
</html>