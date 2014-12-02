<?php
$name = 'Gosho';
$phoneNumber = '0882-321-423';
$age = 24;
$address = 'Hadji Dimitar';
?>

<!DOCTYPE html>
<html>
<head>
    <title>Information Table</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
    <div id="container">
        <table>
            <tr>
                <td class="title">Name</td>
                <td class="info"><?= $name ?></td>
            </tr>
            <tr>
                <td class="title">Phone Number</td>
                <td class="info"><?= $phoneNumber ?></td>
            </tr>
            <tr>
                <td class="title">Age</td>
                <td class="info"><?= $age ?></td>
            </tr>
            <tr>
                <td class="title">Address</td>
                <td class="info"><?= $address ?></td>
            </tr>
        </table>
    </div>
</body>
</html>