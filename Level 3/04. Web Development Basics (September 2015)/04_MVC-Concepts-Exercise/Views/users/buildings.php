<?php include_once 'Views/layouts/header.php' ?>

<h1>Buildings</h1>

<div class="panel panel-primary col-xs-3 col-md-3">
    <div class="panel-heading">
        Resources:
    </div>
    <div class="panel-body">
        <p>Gold: <?= $model->getUser()->getGold(); ?></p>
        <p>Food: <?= $model->getUser()->getFood(); ?></p>
    </div>
</div>

<table class="table table-striped">
    <tr>
        <th>Building name</th>
        <th>Level</th>
        <th>Gold</th>
        <th>Food</th>
        <th>Action</th>
    </tr>
    <?php if($model->error): ?>
        <h2><?= $model->error ?></h2>
    <?php elseif($model->success):?>
        <h2>Successfully updated profile</h2>
    <?php endif; ?>
    <?php foreach($model->getBuildings() as $building): ?>
        <?php if($building['gold'] != null): ?>
            <tr>
                <td><?= $building['name']?></td>
                <td><?= $building['level'] - 1?></td>
                <td><?= $building['gold']?></td>
                <td><?= $building['food']?></td>
                <td>
                    <?php if($model->getUser()->getGold()>= $building['gold'] && $model->getUser()->getFood()>= $building['food']): ?>
                        <a href="<?= \SoftUni\Helpers\Helpers::url() . 'users/buildings/' .  $building['building_id'];?>">Upgrade</a>
                    <?php else: ?>
                        <span>Not enough resources</span>
                    <?php endif; ?>

                </td>
            </tr>
        <?php endif; ?>
    <?php endforeach; ?>
</table>

<?php include_once 'Views/layouts/footer.php' ?>