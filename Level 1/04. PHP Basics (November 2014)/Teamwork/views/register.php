<?php 
if (Lib\Auth::get_instance()->is_logged_in()):?>
    <p class="error-message">Can't register while logged in!</p>
    
<?php else: ?>
    <form action="" method="POST" id="register-form">
        <div class="registration-hints">
            <input type="text" name="name" placeholder="Name"/>
            <p class="hide">Letters and digits between 3 and 20 symbols.</p>
        </div>
        <div class="registration-hints">
            <input type="text" name="username" placeholder="Username"/>
            <p class="hide">Letters, digits, '_' and '-' between 3 and 30 symbols.</p>
        </div>
        <div class="registration-hints">
            <input type="password" name="password" placeholder="Password" />
            <p class="hide">At least one uppercase letter, digit and special symbol [$@$!%*#?&].</p>
        </div>
        <div>
            <input  type="password" name="confirm" placeholder="Confirm password"/>
        </div>
        <div>
            <input type="email" name="email" placeholder="Email" />
        </div>
        <div>
            <input type="submit" class="button" name="register" value="Register"/>
        </div>
    </form>

    <p class="error-message center"><?php echo htmlentities($message) ?></p>

<?php endif;?>


