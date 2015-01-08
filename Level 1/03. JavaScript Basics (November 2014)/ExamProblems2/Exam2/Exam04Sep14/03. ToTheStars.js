function solve(arg) {
    var stars = {};
    var x = Number(arg[3].split(' ')[0]);
    var y = Number(arg[3].split(' ')[1]);
    var moves = Number(arg[4]);
   
    for (var i = 0; i < 3; i++) {       
        var row = arg[i].split(' ');
        var name = 'star' + (i + 1);
        stars[name] = { 'name': row[0].toLowerCase(), 'x': Number(row[1]), 'y': Number(row[2]) };
    }

    for (var i = 0; i <= moves; i++, y++) {
        console.log(checkStars());
    }

    function checkStars() {
        for (var i = 1; i < 4; i++) {
            var star = 'star' + i;
            if (x >= stars[star].x - 1 && x <= stars[star].x + 1 && y >= stars[star].y - 1 && y <= stars[star].y + 1) {
                return stars[star].name;
            }
        }
        return 'space';
    }   
}

//var input = [
//    ['Sirius 3 7',
//     'Alpha-Centauri 7 5',
//     'Gamma-Cygni 10 10',
//     '8 1',
//     '6'],
//     ['Terra-Nova 16 2',
//     'Perseus 2.6 4.8',
//     'Virgo 1.6 7',
//     '2 5',
//     '4']
//];

//for (var str in input) {
//    solve(input[str]);
//}