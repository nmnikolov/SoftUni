<?php include_once 'Views/layouts/header.php' ?>

<?= $model->error ? $model->error : ''; ?>

<form action="" method="post">
    <input type="text" name="username" />
    <input type="password" name="password" />
    <input type="submit" value="Login" />
</form>

<?php include_once 'Views/layouts/footer.php' ?>