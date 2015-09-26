<?php include_once 'Views/layouts/header.php' ?>

<h1>Hello, <?= htmlspecialchars($model->getUser()->getUsername()) ?></h1>

<div class="panel panel-primary col-xs-3 col-md-3">
    <div class="panel-heading">
        Resources:
    </div>
    <div class="panel-body">
        <p>Gold: <?= $model->getUser()->getGold(); ?></p>
        <p>Food: <?= $model->getUser()->getFood(); ?></p>
    </div>
</div>

<?php if($model->error): ?>
    <h2>An error occurred</h2>
<?php elseif($model->success):?>
    <h2>Successfully updated profile</h2>
<?php endif; ?>
<form action="" method="post">
    <div>
        <input type="text" name="username" value="<?= htmlspecialchars($model->getUser()->getUsername()); ?>">
        <input type="password" name="password">
        <input type="password" name="confirm">
        <input type="submit" name="edit" value="Edit">
    </div>
</form>

<?php include_once 'Views/layouts/footer.php' ?>