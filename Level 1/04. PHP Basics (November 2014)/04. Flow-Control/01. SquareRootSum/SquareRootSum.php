<?php
    $total = 0;
?>

<!DOCTYPE html>
<html>
<head>
    <title>Square Root Sum</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <table>
        <thead>
            <tr>
                <th>Number</th>
                <th>Square</th>
            </tr>
        </thead>
        <tbody>
            <?php for ($i = 0; $i <= 100; $i += 2): ?>
                <tr>
                    <td> <?= $i ?> </td>
                    <td> <?= round(sqrt($i), 2) ?> </td>

                    <?php $total += round(sqrt($i), 2) ?>
                </tr>
            <?php endfor; ?>
        </tbody>
        <tfoot>
            <tr>
                <td>Total</td>
                <td> <?= round($total, 2) ?> </td>
            </tr>
        </tfoot>
    </table>
</div>
</body>
</html>