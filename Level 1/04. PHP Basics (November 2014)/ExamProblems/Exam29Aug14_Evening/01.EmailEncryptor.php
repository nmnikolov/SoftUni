<!DOCTYPE html>
<html>

<head>
    <title>Email Encryptor</title>
    <meta charset="utf-8" />
</head>

<body>
    <form method="get" action="">
        To: <input type="text" name="recipient" value="info@softuni.bg" /> <br/>
        Subject: <input type="text" name="subject" value="SoftUniConf <2014>" /> <br/>
        Message body: <br/><textarea rows="10" cols="80" name="body">SoftUniConf <2014> is coming.
<a href="https://softuni.bg/SoftUniConf">Learn more</a></textarea> <br/>
        Encryption key: <input type="text" name="key" value="s3cr3t!" /> <br/>
        <input type="submit" value="Send" />
    </form>
</body>

</html>

<?php
$key = $_GET['key'];
$text =
    "<p class='recipient'>" . htmlspecialchars($_GET['recipient']) . "</p>" .
    "<p class='subject'>" . htmlspecialchars($_GET['subject']) . "</p>" .
    "<p class='message'>" . htmlspecialchars($_GET['body']) . "</p>";

echo '|';
for ($i = 0; $i < strlen($text); $i++) {
    $number = ord($text[$i]) * ord($key[$i % strlen($key)]);
    echo dechex($number) . "|";
}