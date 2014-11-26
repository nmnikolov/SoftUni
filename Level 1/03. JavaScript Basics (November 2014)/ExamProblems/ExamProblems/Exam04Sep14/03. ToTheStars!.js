function solve(arr) {
    var stars = {};
    var startPoint = arr[3].split(' ').map(function(item) {
        return Number(item, 10);
    });
    var moves = Number(arr[4]);

    for (var i = 0; i < 3; i++) {
        var row = arr[i].split(' ');       
        stars['star' + (i + 1)] = { name: row[0].toLowerCase(), x: Number(row[1]), y: Number(row[2]) };
    }

    for (var i = 0; i <= moves; i++) {
        var found = false;
        for (var key in stars) {
            if (check(startPoint[0], startPoint[1], stars[key].x, stars[key].y)) {
                console.log(stars[key].name);
                found = true;
                break;
            }
        }

        if (!found) {
            console.log('space');
        }      
        startPoint[1]+= 1;       
    }
    
    function check(x, y, starX, starY) {
        if (x >= starX - 1 && x <= starX + 1 && y >= starY - 1 && y <= starY + 1) {
            return true;
        }
        return false;
    }
}

//var input = [
//    ['Sirius 3 7',
//     'Alpha-Centauri 7 5',
//     'Gamma-Cygni 10 10',
//     '8 1.3',
//     '6'],
//    ['Terra-Nova 16 2',
//     'Perseus 2.6 4.8',
//     'Virgo 1.6 7',
//     '2 5',
//     '4']
//];

//for (var arr in input) {
//    solve(input[arr])
//}