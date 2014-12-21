<section>
    <article class="topic">
        <h2><a href=""><?php echo htmlentities($topic[0]['name']); ?></a></h2>
        <p class="post-details">created by
            <a href="<?php echo DX_ROOT_URL . 'profile.php?mid=' . htmlentities($topic[0]['user_id']); ?>">
                <span class="author"><?php echo htmlentities($topic[0]['username']); ?></span>
            </a>
            | <span class="date-created"><?php echo htmlentities($topic[0]['date_created']); ?></span> | views <span><?php echo htmlentities($topic[0]['views']); ?></span></p>
        <p class="topic-content"><?php echo htmlentities($topic[0]['content']); ?></p>


        <?php if ($auth->is_logged_in()): ?>
            <input type="button" id="answer" class="button" Value="Answer"/>
            <form action="" method="post" class="hide" id="answer-form">
                <textarea name="content"></textarea>
                <input type="submit" class="button reply" name="reply" value="Answer"/>
            </form>
            <p class="error-message"> <?php echo htmlentities($message); ?></p>
        <?php endif; ?>
    </article>

    <?php if (! empty($pageAnswers)) :
        foreach ($pageAnswers as $answer) :?>
            <article class="answer">
                <p class="post-details">author
                    <a href="<?php echo DX_ROOT_URL . 'profile.php?mid=' . htmlentities($answer['user_id']); ?>">
                        <span class="author"><?php echo htmlentities($answer['username']); ?></span>
                    </a>
                    | <span class="date-created"><?php echo htmlentities($answer['date_created']); ?></span>
                </p>

                <p class="content"><?php echo htmlentities($answer['content']); ?></p>
            </article>
        <?php endforeach;
    endif; ?>

    <?php if (count($answers) > PER_PAGE): ?>
        <div id="pages-bar">
            <ul class="pages">
                <?php if ($initialPages == 2): ?>
                    <li <?php if ($_GET['page'] == 1) { echo 'class="current-page"';} ?>>
                        <a href="<?php echo DX_ROOT_URL . "topic.php?tid=" . $tid . "&page=1"?>">1</a>
                    </li>
                    <li <?php if ($_GET['page'] == $initialPages) { echo 'class="current-page"';} ?> >
                        <a href="<?php echo DX_ROOT_URL . "topic.php?tid=" . $tid . "&page=" . $initialPages;?>">2</a>
                    </li>
                <?php endif; ?>

                <?php if ($initialPages > 2): ?>

                    <?php switch (intval($_GET['page'])) :
                        case 1:
                        case 2:
                        case 3: $startPage = 2; break;
                        case $initialPages - 2: $startPage = $initialPages - 5; break;
                        case $initialPages - 1: $startPage = $initialPages - 5; break;
                        case $initialPages: $startPage = $initialPages - 5; break;
                        default: $startPage = $_GET['page'] - 2; break;
                    endswitch; ?>

                    <li <?php if ($_GET['page'] == 1) { echo 'class="current-page"';} ?>>
                        <a href="<?php echo DX_ROOT_URL . "topic.php?tid=" . $tid . "&page=1"?>">
                            <?php echo ($startPage > 2 ? "<<" : 1); ?>
                        </a>
                    </li>

                    <?php for ($i = $startPage; $i < $startPage + 5; $i++):
                        if ($i > 1 && $i < $initialPages) : ?>
                            <li <?php if ($_GET['page'] == $i) { echo 'class="current-page"';} ?>>
                                <a href="<?php echo DX_ROOT_URL . "topic.php?tid=" . $tid . "&page=" . $i;?>"><?php echo $i; ?></a>
                            </li>
                        <?php endif; ?>
                    <?php endfor; ?>

                    <li <?php if ($_GET['page'] == $initialPages) { echo 'class="current-page"';} ?> >
                        <a href="<?php echo DX_ROOT_URL . "topic.php?tid=" . $tid . "&page=" . $initialPages;?>">
                            <?php echo $startPage + 5 < $initialPages ? ">>" : $initialPages; ?>
                        </a>
                    </li>
                <?php endif; ?>
            </ul>
        </div>
    <?php endif; ?>
</section>