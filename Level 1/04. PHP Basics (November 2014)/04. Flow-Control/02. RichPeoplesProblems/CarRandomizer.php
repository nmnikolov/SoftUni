<?php

$colors = array('yellow', 'green', 'black', 'blue', 'brown', 'silver', 'white', 'red', 'orange');

?>

<!DOCTYPE html>
<html>
<head>
    <title>Rich People's Problems</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="get">
        <label for="cars">Enter cars</label>
        <input type="text" id="cars" name="cars" required />
        <input type="submit" value="Submit" />
    </form>

    <?php
        if (isset($_GET['cars'])):
            $cars = explode(', ', $_GET['cars']); ?>

            <table>
                <thead>
                    <tr>
                        <th>Car</th>
                        <th>Color</th>
                        <th>Count</th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($cars as $car): ?>
                        <tr>
                            <td> <?= htmlentities($car) ?></td>
                            <td> <?= htmlentities($colors[array_rand($colors)]) ?> </td>
                            <td> <?= rand(1, 5) ?> </td>
                        </tr>
                    <?php endforeach; ?>
                </tbody>
            </table>
        <?php endif; ?>
</div>
</body>
</html>