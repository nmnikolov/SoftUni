function solve(arg) {
    var output = [];

    for (var i = 0; i < arg.length; i++) {
        output.push(arg[i].split(''))
    }

    for (var row = 0; row < arg.length - 2; row++) {
        for (var col = 0; col < arg[row].length - 2; col++) {
            var c = arg[row][col].toLowerCase();

            if (col + 1 < arg[row + 1 ].length &&
                col + 2 < arg[row + 2].length &&
                arg[row][col + 2].toLowerCase() == c &&
                arg[row + 1][col + 1].toLowerCase() == c &&
                arg[row + 2][col].toLowerCase() == c &&
                arg[row + 2][col + 2].toLowerCase() == c) {

                output[row][col] = '';
                output[row][col + 2] = '';
                output[row + 1][col + 1] = '';
                output[row + 2][col] = '';
                output[row + 2][col + 2] = '';
            }
        }
    }

    for (var i = 0; i < output.length; i++) {
        console.log(output[i].join(''));
    }
}

//var input = [
//    ['abnbjs',
//     'xoBab',
//     'Abmbh',
//     'aabab',
//     'ababvvvv'],
//    ///////////////
//    ['888888',
//     '08*8*80',
//     '808*888',
//     '0**8*8?'],
//     ///////////////
//    ['^u^',
//     'j^l^a',
//     '^w^WoWl',
//     'adw1w6',
//     '(WdWoWgPoop)'],
//     ////////////////
//     ['puoUdai',
//     'miU',
//     'ausupirina',
//     '8n8i8',
//     'm8o8a',
//     '8l8o860',
//     'M8i8',
//     '8e8!8?!']
//];

//for (var str in input) {
//    solve(input[str]);
//}