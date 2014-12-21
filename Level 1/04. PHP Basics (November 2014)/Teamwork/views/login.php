<?php if (\Lib\Auth::get_instance()->is_logged_in()): ?>
    <p class="error-message">Already logged in.</p>
<?php else: ?>
    <form method="post" id="login-form">
        <div>
            <input type="text" name="username" placeholder="Username"/>
        </div>
        <div>
            <input type="password" name="password" placeholder="Password"/>
        </div>
        <input type="submit" class="button" name="login" value="Login" />
    </form>

    <p class="error-message center"> <?php echo htmlentities($message) ?> </p>
<?php endif; ?>