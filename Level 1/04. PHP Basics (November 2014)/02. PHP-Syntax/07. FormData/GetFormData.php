<!DOCTYPE html>
<html>
<head>
    <title>Form Data</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
    <div id="container">
        <form action="GetFormData.php" method="get">
            <input type="text" placeholder="Name.." name="name" />
            <input type="text" placeholder="Age.." name="age" />
            <input id="male" type="radio" name="gender" value="male" />
            <label for="male">Male</label>
            <input id="female" type="radio" name="gender" value="female" />
            <label for="female">Female</label>
            <input type="submit">
        </form>

        <?php if (isset($_GET['name'],$_GET['age'],$_GET['gender'])): ?>
            <p>My name is <?= htmlentities($_GET['name']) ?>. I am <?= htmlentities($_GET['age']) ?> years old. I am <?= htmlentities($_GET['gender']) ?>.</p>
        <?php endif ?>

    </div>
</body>
</html>