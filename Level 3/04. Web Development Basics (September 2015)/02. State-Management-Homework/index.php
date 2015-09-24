<?php
session_start();
require_once 'guessNumberGame.php'; ?>

<?php if(!isset($_SESSION['user'])) : ?>
    <form action="play.php" method="post">
        <label for="user">Enter your name:</label>
        <input type="text" name="user" />
        <input type="submit" value="Start Game" />
    </form>
<?php elseif(!isset($_SESSION['gameOver'])): ?>
   <?= header("Location: " . 'play.php'); ?>
<?php else: ?>
    <?= __reset(); ?>
<?php endif; ?>