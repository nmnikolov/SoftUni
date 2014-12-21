<section id="categories">
<?php foreach ($categories as $category) : ?>
    <article>
        <h2><a href="<?php echo DX_ROOT_URL . 'category.php?cid=' . $category['id'] ?>"><?php echo htmlentities($category['name']) ?></a></h2>
        <p><?php echo htmlentities($category['description']) ?></p>
    </article>
<?php endforeach; ?>
</section>