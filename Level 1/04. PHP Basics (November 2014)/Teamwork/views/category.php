<section>
<?php foreach ($topics as $topic) : ?>
    <article class="topic">
        <h2><a href="<?php echo DX_ROOT_URL . 'topic.php?tid=' . $topic['id'] ?>"><?php echo htmlentities($topic['name']) ?></a></h2>
        <p class="post-details">created by
            <a href="<?php echo DX_ROOT_URL . 'profile.php?mid=' . $topic['user_id'] ?>">
                <span class="author"><?php echo htmlentities($topic['username']) ?></span>
            </a>
             | <span class="date-created"><?php echo htmlentities($topic['date_created']) ?></span> | views <span><?php echo htmlentities($topic['views']) ?></span></p>
    </article>
<?php endforeach; ?>
</section>