<?php $loggedUser = \Lib\Auth::get_instance()->get_logged_user(); ?>

<?php if( ! empty ($loggedUser) ): ?>
<section id="topic-add">
    <form action="" method="post" id="question-form">
        <input type="text" name="title" id="name" placeholder="Question name"/>
        <select name="category">
            <option selected disabled>--Category--</option>
            <?php foreach ($categories as $category): ?>
                <option value="<?php echo htmlentities($category['name']); ?>"><?php echo htmlentities($category['name']); ?></option>
            <?php endforeach;?>
        </select>
        <textarea name="content" class="content" placeholder="Content..."></textarea>
        <input type="submit" name="submit" class="button add" value="Add"/>
    </form>
    <p class="error-message"><?php echo htmlentities($message) ?></p>
</section>
<?php else: ?>
<p class="error-message">You hate to log in to Add Question.</p>
<?php endif; ?>