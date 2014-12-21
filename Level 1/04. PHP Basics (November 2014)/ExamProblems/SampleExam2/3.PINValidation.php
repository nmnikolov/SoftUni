<!DOCTYPE html>
<html>
<head>
    <title>3. PIN Validation</title>
</head>
<body>
<form method="get" action="">
    <label>
        Name:
        <input type="text" name="name" value="Ana Ivanova"/>
    </label>
    <br />
    <label>
        male:
        <input type="radio" name="gender" value="male" />
    </label>
    <label>
        female:
        <input type="radio" name="gender" value="female" checked="checked"/>
    </label>
    <br />
    <label>
        PIN:
        <input type="text" name="pin" value="9912164756"/>
    </label>
    <br />
    <input type="submit" value="Submit"/>
</form>
</body>
</html>

<?php
//$_GET['gender'] = "male";
//$_GET['name'] = "Angel georgiev";
//$_GET['pin'] = "4008262703";

$gender = $_GET['gender'];
$pin = str_split($_GET['pin']);
$pinMonth = intval($pin[2] . $pin[3]);
$pinGender = intval($pin[8]);
$multiplier = [2,4,8,5,10,9,7,3,6];
$name = $_GET['name'];

if (!preg_match("/[A-Z]{1}[a-z]+\s[A-Z]{1}[a-z]+/", $name)) {
    echo "<h2>Incorrect data</h2>";
    return;
}

if (count($pin) != 10) {
    echo "<h2>Incorrect data</h2>";
    return;
}

if (($pinMonth > 12 && $pinMonth < 21) || ($pinMonth > 32 && $pinMonth < 41) || $pinMonth > 52) {
    echo "<h2>Incorrect data</h2>";
    return;
}


if (($pinGender % 2 === 0 && $gender == "female") || ($pinGender % 2 !== 0 && $gender == "male")) {
    echo "<h2>Incorrect data</h2>";
    return;
}

$sum = 0;

for ($i = 0; $i < 9; $i++) {
    $sum += $pin[$i] * $multiplier[$i];
}

if ((($sum % 11) % 10) !== intval($pin[9]) ) {
    echo "<h2>Incorrect data</h2>";
    return;
}

$output = [
    'name' => $name,
    'gender' => $gender,
    'pin' => implode("", $pin)
];

echo json_encode($output);