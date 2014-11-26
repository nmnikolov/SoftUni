function xRemove(arr) {
    var output = {};

    for (var i = 0; i < arr.length; i++) {
        output[i] = arr[i].split('');
    }

    for (var row = 0; row < arr.length - 2; row++) {
        for (var col = 0; col < arr[row].length - 2; col++) {
            var char = arr[row][col].toLowerCase();
            if (col + 1 < arr[row + 1].length &&
                col + 2 < arr[row + 2].length &&
                arr[row][col + 2].toLowerCase() === char &&
                arr[row + 1][col + 1].toLowerCase() === char &&
                arr[row + 2][col].toLowerCase() === char &&
                arr[row + 2][col + 2].toLowerCase() === char) {

                output[row][col] = '';
                output[row][col + 2] = '';
                output[row + 1][col + 1] = '';
                output[row + 2][col] = '';
                output[row + 2][col + 2] = '';
            }
        }
    }

    for (var key in output) {
        console.log(output[key].join(''));
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

//for (var arr in input) {
//    xRemove(input[arr]);
//    console.log('***************************************');
//}