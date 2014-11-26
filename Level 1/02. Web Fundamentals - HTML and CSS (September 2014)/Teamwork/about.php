<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link type="text/css" href="styles/style.css" rel="stylesheet"/>
    <link type="text/css" href="styles/styles-about-us.css" rel="stylesheet"/>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/global.js"></script>
    <title>За нас</title>
</head>
<body>
<header class="header">
    <?php include 'templates/header.php'; ?>
</header>
<main>
    <div id="main-wrapper">
        <div class="deep-sky">
            Ние сме
            <strong>TEAM DEEP SKY BLUE</strong>
            , екип студенти от
            <a href="http://softuni.bg" target="_blank">Software University</a>
            . Този сайт е продукт на нашата дейност, свързана с курса по HTML/CSS.
            Целия source код на проекта може да намерите
            <a href="https://github.com/rozay/WebFundamentals-HTML-CSS-Teamwork" target="_blank">тук</a>
            .</div>
        <hr/>

        <div class="us">А ето и малко повече информация за нас:</div>

        <section id="info">
            <article id="nikola" class="personal">
                <img src="resources/images/about/NikolaN.jpg" alt="icon"/>
                <div class="text">
                    <h5>Никола Николов</h5>
                    <p><a href="https://softuni.bg/users/profile/show/nikola.m.nikolov" target="_blank">SoftUni профил</a></p>
                    <p><a href="https://github.com/nmnikolov" target="_blank">Github профил</a></p>
                </div>
            </article>

            <article id="todor" class="personal">
                <img src="resources/images/about/TodorA.jpg" alt="icon"/>
                <div class="text">
                    <h5>Тодор Атанасов</h5>
                    <p><a href="https://softuni.bg/users/profile/show/toshko93" target="_blank">SoftUni профил</a></p>
                    <p><a href="https://github.com/toshko93" target="_blank">Github профил</a></p>
                </div>
            </article>

            <article id="rossica" class="personal">
                <img src="resources/images/about/RositsaP.jpg" alt="icon"/>
                <div class="text">
                    <h5>Росица Попова</h5>
                    <p><a href="https://softuni.bg/users/profile/show/rpopova" target="_blank">SoftUni профил</a></p>
                    <p><a href="https://github.com/rozay" target="_blank">Github профил</a></p>
                </div>
            </article>

            <article id="ivelin" class="personal">
                <img src="resources/images/about/IvelinM.jpg" alt="icon"/>
                <div class="text">
                    <h5>Ивелин Марчев</h5>
                    <p><a href="https://softuni.bg/users/profile/show/ivelin_m" target="_blank">SoftUni профил</a></p>
                    <p><a href="https://github.com/IvelinMarchev" target="_blank">Github профил</a></p>
                </div>
            </article>
        </section>
    </div>
</main>
<footer>
    <?php include 'templates/footer.php'; ?>
</footer>
</body>
</html>
