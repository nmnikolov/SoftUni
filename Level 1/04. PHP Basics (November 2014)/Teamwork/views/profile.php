<?php
$loggedUser = \Lib\Auth::get_instance()->get_logged_user();

if ( ! empty($loggedUser)  ) : ?>
    <section class="profile">
        <h1><?php echo htmlentities($member[0]['username']); ?></h1>
        <p>Register Date: <?php echo htmlentities($member[0]['register_date']); ?></p>

        <?php if ($loggedUser['username'] == $member[0]['username']) :?>

            <form action="" method="post">
                <div>
                    <label>Name</label>
                    <input type="text" name="name" value="<?php echo htmlentities($member[0]['name']); ?>"/>
                </div>
                <div>
                    <label>Email</label>
                    <input type="email" name="email" value="<?php echo htmlentities($member[0]['email']); ?>"/>
                </div>
                <input type="submit" class="button save" name="profile-other" value="Save"/>
            </form>
            <p class="error-message"><?php echo htmlentities($message); ?></p>
            <form action="" method="post">
                <h4>Change Password</h4>
                <div>
                    <label>Current password</label>
                    <input type="password" name="curr-password" value="" />
                </div>
                <div>
                    <label>New password</label>
                    <input type="password" name="password" value="" />
                </div>
                <div>
                    <label>Confirm new password</label>
                    <input type="password" name="confirm-pass" value="" />
                </div>
                <input type="submit" class="button save" name="change-password" value="Save"/>
            </form>
            <p class="error-message"><?php echo htmlentities($message1); ?></p>
        <?php else: ?>
            <p>name: <?php echo htmlentities($member[0]['name']); ?></p>
            <p>email: <a href="mailto:<?php echo htmlentities($member[0]['email']); ?> "><?php echo htmlentities($member[0]['email']); ?></a></p>
        <?php endif ?>
    </section>

    <section id="profile-questions">
        <input type="button" id="questions-button" class="button" value="Questions started">
            <article id="profile-questions-details" class="hide">
                <?php if (! empty ($topics)): ?>
                    <?php foreach ($topics as $topic) : ?>
                        <div>
                            <h3><a href="<?php echo DX_ROOT_URL . 'topic.php?tid=' . htmlentities($topic['id']) ?>"><?php echo htmlentities($topic['name']) ?></a></h3>
                        </div>
                    <?php endforeach; ?>
                <?php else: ?>
                    <p class="error-message">No Questions started.</p>
                <?php endif; ?>
            </article>

    </section>

<?php else: ?>

    <p class="error-messages">You have to log in to see this page.</p>

<?php endif; ?>

