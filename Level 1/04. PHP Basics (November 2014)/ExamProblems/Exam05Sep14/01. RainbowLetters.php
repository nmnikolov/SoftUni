<!DOCTYPE html>
<html>
<head>
    <title>Rainbow Letters</title>
    <style>
        input {
            margin: 3px;
        }
        label {
            display: inline-block;
            width: 70px;
        }
    </style>
</head>
<body>
<form action="" method="get">
    <label for="text">Text:</label>
    <input type="text" name="text" id="text" value="Hello"/><br>
    <label for="red">Red:</label>
    <input type="text" name="red" id="red" value="255" /><br>
    <label for="green">Green:</label>
    <input type="text" name="green" id="green" value="0"/><br>
    <label for="blue">Blue:</label>
    <input type="text" name="blue" id="blue" value="0"/><br>
    <label for="nth">Nth letter:</label>
    <input type="text" name="nth" id="nth" value="2"/><br>
    <input type="submit" value="SUBMIT"/>
</form>
</body>
</html>

<?php
$red = str_pad(dechex($_GET['red']), 2, '0', STR_PAD_LEFT);
$blue = str_pad(dechex($_GET['blue']), 2, '0', STR_PAD_LEFT);
$green = str_pad(dechex($_GET['green']), 2, '0', STR_PAD_LEFT);
$rgb = '#' . $red . $green . $blue;
$nth = intval($_GET['nth']);
$text = $_GET['text'];

echo '<p>';

for ($i = 0; $i < strlen($text); $i++) {
    if (($i + 1) % $nth == 0) {
        echo '<span style="color: ' . $rgb . '">' . htmlspecialchars($text[$i]) . '</span>';
    } else {
        echo htmlspecialchars($text[$i]);
    }
}

echo '</p>';