<!DOCTYPE html>
<html>
<head>
    <title>Most Frequent Tag</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="get">
        <label for="tags">Enter Tags:</label>
        <input type="text" id="tags" name="tags" />
        <input type="submit" value="Submit">
    </form>

    <?php if (isset($_GET['tags']) && $_GET['tags'] != ''): ?>
        <ul>
            <?php
            $tags = explode(', ', $_GET['tags']);
            $counts = array_count_values($tags);
            arsort($counts);
            ?>
            <?php foreach($counts as $key => $value): ?>
                <li><?= htmlentities($key) ?> : <?= htmlentities($value) ?> times</li>
            <?php endforeach ?>
            <?php reset($counts); ?>
        </ul>
        <p>Most Frequent Tag is: <?= htmlentities(key($counts)) ?></p>
    <?php endif ?>
</div>
</body>
</html>