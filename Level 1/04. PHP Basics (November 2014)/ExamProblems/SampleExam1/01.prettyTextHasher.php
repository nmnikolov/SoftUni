<!--<!DOCTYPE html>-->
<!--<html>-->
<!--<head>-->
<!--    <title>Pretty Text Hasher</title>-->
<!--    <!--    <link type="text/css" rel="stylesheet" href="styles/style.css">-->-->
<!--</head>-->
<!--<body>-->
<!--<div id="container">-->
<!--    <form action="" method="get">-->
<!--        <div>-->
<!--            Text:-->
<!--            <input type="text" name="text"/>-->
<!--        </div>-->
<!--        <div>-->
<!--            Hash:-->
<!--            <input type="text" name="hashValue"/>-->
<!--        </div>-->
<!--        <div>-->
<!--            Font Size:-->
<!--            <input type="number" name="fontSize"/>-->
<!--        </div>-->
<!--        <div>-->
<!--            Style:-->
<!--            <input type="text" name="fontStyle"/>-->
<!--        </div>-->
<!---->
<!--        <input type="submit" id="submit" value="Replace" />-->
<!--    </form>-->

<?php
    
// if (isset($_GET['text'], $_GET['hashValue'], $_GET['fontSize'], $_GET['fontStyle'])) {

$text = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize= $_GET['fontSize'];
$fontStyle = $_GET['fontStyle'];

for ($i = 0; $i < strlen($text); $i++) {
    $char = ord($text[$i]);
    $text[$i] = $i % 2 == 0 ? chr($char + $hashValue) : chr($char - $hashValue);
}

switch ($fontStyle) {
    case 'normal' :
        $fontStyle = "font-style:{$fontStyle};";
        break;
    case 'italic' :
        $fontStyle = "font-style:{$fontStyle};";
        break;
    default:
        $fontStyle = "font-weight:{$fontStyle};";
        break;
}

echo "<p style=\"font-size:" . $fontSize . ";" . $fontStyle . "\">" . $text . "</p>";

//}

?>

<!--</div>-->
<!--</body>-->
<!--</html>-->