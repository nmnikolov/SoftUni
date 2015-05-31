function solve(arr) {
    var lenghtX,
        lenghtY,
        x = 0,
        y = 0,
        directions = arr[0].split(/, /),
        matrix = [],
        passed = [],
        output = {
            '&': 0,
            '*': 0,
            '#': 0,
            '!': 0,
            'wall hits': 0
        },
        pattern = /{([&\*#!])}/g,
        match,
        cell;

    for (var i = 1, len = arr.length; i < len; i += 1) {
        matrix.push(arr[i].split(/, /));
    }

    lenghtX = matrix[0].length;
    lenghtY = matrix.length;

    directions.forEach(function (direction) {
        isWallHitted = false;
        switch(direction) {
            case 'right':
                x++;
                if (x === lenghtX) {
                    x--;
                    isWallHitted = true;
                }
                break;
            case 'down':
                y++;
                if (y === lenghtY) {
                    y--;
                    isWallHitted = true;
                }
                break;
            case 'left':
                x--;
                if (x < 0) {
                    x++;
                    isWallHitted = true;
                }
                break;
            case 'up':
                y--;
                if (y < 0) {
                    y++;
                    isWallHitted = true;
                }
                break;
        }

        cell = matrix[y][x];

        if (!isWallHitted) {
            eatVegetables();
        } else {
            output["wall hits"]++;
        }
    });
    
    console.log(JSON.stringify(output));
    console.log(passed.length ? passed.join('|') : 'no');

    function eatVegetables() {
        while (match = pattern.exec(cell)) {
            output[match[1]]++;
        }

        cell = cell.replace(pattern, "@");
        passed.push(cell);
    }
}

//var input = [
//    ['right, up, up, down', 'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj', 'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip', 'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'],
//    ['up, right, left, down', 'as{!}xnk']
//];

//input.forEach(function(arr) { solve(arr); });