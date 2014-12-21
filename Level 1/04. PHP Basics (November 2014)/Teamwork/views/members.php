<div id="members">
    <h2>Members:</h2>
    <ul>
        <?php
        if (!empty ($users)):
            foreach ($users as $user): ?>
                <li><a href="<?php echo DX_ROOT_URL; ?>profile.php?mid=<?php echo htmlentities($user['id']) ?>"><?php echo htmlentities($user['username'])?></a></li>
            <?php endforeach; ?>
        <?php else: ?>
            <p>No members</p>
        <?php endif;?>

    </ul>
</div>
