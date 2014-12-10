<!DOCTYPE html>
<html>
<head>
    <title>Sidebar Builder</title>
    <link type="text/css" rel="stylesheet" href="styles/style.css">
</head>
<body>
<div id="container">
    <form action="" method="post">
        <div>
            <label for="categories">Categories</label>
            <input type="text" id="categories" name="categories" value=""/>
        </div>
        <div>
            <label for="tags">Tags</label>
            <input type="text" id="tags" name="tags" />
        </div>
        <div>
            <label for="months">Months</label>
            <input type="text" id="months" name="months" />
        </div>

        <input type="submit" id="submit" value="Generate" />
    </form>
    <section>

    <?php require 'SidebarBuilder.php' ?>

    </section>
</div>
</body>
</html>