<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link type="text/css" href="styles/style.css" rel="stylesheet"/>
    <link type="text/css" href="styles/styles-index.css" rel="stylesheet"/>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/global.js"></script>
    <title>Начало</title>
</head>
<body>
<header class="header">
    <?php include 'templates/header.php';?>
</header>
<main>
    <div id="main-wrapper">
        <h1 id="homeHeader">Добре дошли в нашата паралелна Вселена!</h1>
        <h3 id="homeSubheader"> Тук можете да откриете всякакви нелепици от ежедневието на обитателите на SoftUni </h3>
        <div id="links">
            <a href="gallery.php" class="homeLinks">
                <section class="homeSection">
                    <h4>Галерия</h4>
                    <img src="resources/images/home/gallery.jpg" alt="galleryImage" class="homeImgSection"/>
                    <p class="homeParagraph">В нашата галерия ще откриете интересни картинки.</p>
                </section>
            </a>
            <a href="guide.php" class="homeLinks">
                <section class="homeSection">
                    <h4>Наръчник</h4>
                    <img src="resources/images/home/guide.jpg" alt="guideImage" class="homeImgSection"/>
                    <p class="homeParagraph">Какъв е пътят на програмиста? </p>
                </section>
            </a>
            <a href="jokes.php" class="homeLinks">
                <section class="homeSection">
                    <h4>Бисери</h4>
                    <img src="resources/images/home/text.png" alt="textImage" class="homeImgSection"/>
                    <p class="homeParagraph">В секцията с бисери сме ви подготвили всякакви тъпотии в писмен вид</p>
                </section>
            </a>
            <h4 id="homePS">П.С. Ако не си от нашата Вселена е силно вероятно да не ни разбереш</h4>
        </div>
    </div>
</main>
<footer>
    <?php include 'templates/footer.php';?>
</footer>
</body>
</html>
