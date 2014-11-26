function init(e) {
    loadResources();
    canvas.canvasElement.width = canvas.width;
    canvas.canvasElement.height = canvas.height;
    canvas.canvasContext = canvas.canvasElement.getContext('2d');
    canvas.background.src = 'resources/bg/shining.png';
    canvas.starsLayer.src = 'resources/bg/stars.png';
    player.playerImage.src = 'resources/player/main.png';

    document.addEventListener('keydown', keyDown, false);
    document.addEventListener('keyup', keyUp, false);
    document.addEventListener("mousemove", mouseOver);
    document.addEventListener("click", mouseClick);

    bgMusic.play();
    bgMusic.volume = 0.2;
    bgMusic.loop = true;

    gameLoop();
};

function loadResources() {
    var i = 0;
    for (i = 1; i <= 4; i++) {
        enemyImages.push(createImage('resources/enemy.png'));
    }

    for (i = 1; i <= 10; i++) {
        explosionEffect.push(createImage('resources/effects/explosion/explosion_' + i + '.png'));
    }

    for (i = 1; i <= 8; i++) {
        playerAnimation.push(createImage('resources/player/animation/' + i + '.png'));
    }

    for (i = 1; i <= 2; i++) {
        mineAnimation.push(createImage('resources/weapons/mine/' + i + '.png'));
    }

    for (i = 1; i <= 3; i++) {
        bombAnimation.push(createImage('resources/weapons/bomb/' + i + '.png'));
    }

    menuScreenImages['play'] = [createImage('resources/menu/play.png'), createImage('resources/menu/play-hover.png')];
    menuScreenImages['instructions'] = [createImage('resources/menu/instructions.png'), createImage('resources/menu/instructions-hover.png')];
    menuScreenImages['credits'] = [createImage('resources/menu/credits.png'), createImage('resources/menu/credits-hover.png')];
    menuScreenImages['backToMenu'] = [createImage('resources/menu/menu.png'), createImage('resources/menu/menu-hover.png')];
    menuScreenImages['playAgain'] = [createImage('resources/menu/again.png'), createImage('resources/menu/again-hover.png')];
    menuScreenImages['menu'] = [createImage('resources/menu/menu.png'), createImage('resources/menu/menu-hover.png')];
    menuScreenImages['logo'] = [createImage('resources/logo/logo.png'), createImage('resources/logo/logo.png')];

    bulletImages.push(createImage('resources/bullet.png'));
    bulletImages.push(createImage('resources/bullet-enemies.png'));
    bonusImages.push(createImage('resources/bonuses/bullets.png'));
    bonusImages.push(createImage('resources/bonuses/repair-bonus.png'));

};