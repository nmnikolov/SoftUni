<?php
session_start();
require_once 'guessNumberGame.php';

if(!isset($_SESSION['user'])){
    header("Location: " . 'index.php');
    exit;
}
?>

<p>Hello, <?= htmlspecialchars($_SESSION['user']); ?></p>

<?php if(isset($_SESSION['gameOver'])): ?>
    <p>Congratulations, you guessed the number. Number of tries: <?= count($_SESSION['sendNumbers']); ?></p>
    <a href="index.php">TryAgain</a>
<?php else: ?>
    <form action="" method="post">
        <label for="guess">Enter number between <?= MIN_RANDOM_NUMBER?> and <?= MAX_RANDOM_NUMBER ?></label>
        <br>
        <input type="number" min="1" max="100" name="guess">
        <input type="submit" value="Send">
    </form>
<?php endif; ?>
<hr>
<?php for($i = count($_SESSION['sendNumbers']) - 1; $i >= 0; $i--): ?>
    <p><?= '(' . ($i + 1) . ')' ?>: <?= $_SESSION['sendNumbers'][$i]['number']?>
        <?php if($_SESSION['sendNumbers'][$i]['result'] === 'UP'): ?>
            <span style="color: red">
        <?php elseif($_SESSION['sendNumbers'][$i]['result'] === 'DOWN'): ?>
            <span style="color: blue">
        <?php else: ?>
            <span style="color: black">
        <?php endif; ?>
        <?= $_SESSION['sendNumbers'][$i]['result']?></span></p>
<?php endfor; ?>
