<?php

    $months = array();
    $year = (int)date('Y');

    for ($i = 1; $i <= 12 ; $i++) {
        $months[] =  DateTime::createFromFormat('!m', $i);
    }
?>

<!DOCTYPE html>
<html>
<head>
    <title>Annual Expenses</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="get">
        <label for="years">Enter number of years</label>
        <input type="text" id="years" name="years" required />
        <input type="submit" value="Show costs" />
    </form>

    <?php
    if (isset($_GET['years'])):
        $numberOfYears = (int)$_GET['years'];

        if (preg_match('/[^\d]/', $numberOfYears) || (int)$numberOfYears < 1) {
            echo "<p>Must enter integer number greater than 0</p>";
            exit;
        }
    ?>

    <table>
        <thead>
            <tr>
                <th>Year</th>

                <?php foreach ($months as $month): ?>
                    <th> <?= $month->format('F'); ?></th>
                <?php endforeach; ?>

                <th>Total:</th>
            </tr>
        </thead>
        <tbody>
            <?php for ($i = $year; $i > $year - $numberOfYears ; $i--):
                $total = 0; ?>
                <tr>
                    <td> <?= $i ?> </td>

                    <?php for ($j = 0; $j < count($months); $j++):
                        $rand = rand(0, 999);
                        $total += $rand; ?>
                    <td> <?= $rand ?> </td>
                    <?php endfor; ?>

                    <td> <?= $total ?> </td>
                </tr>
            <?php endfor; ?>
        </tbody>
    </table>

    <?php endif; ?>
</div>
</body>
</html>