function plusRemove(arr) {
    var output = {};

    for (var i = 0; i < arr.length; i++) {
        output[i] = arr[i].split('');
    }

    for (var row = 0; row < arr.length - 2; row++) {
        for (var col = 1; col < arr[row].length; col++) {
            var char = arr[row][col].toLowerCase();
            if (col + 1 < arr[row + 1].length &&
                col < arr[row + 2].length &&
                arr[row + 1][col - 1].toLowerCase() === char &&
                arr[row + 1][col].toLowerCase() === char &&
                arr[row + 1][col + 1].toLowerCase() === char &&
                arr[row + 2][col].toLowerCase() === char) {

                output[row][col] = '';
                output[row + 1][col - 1] = '';
                output[row + 1][col] = '';
                output[row + 1][col + 1] = '';
                output[row + 2][col] = '';
            }
        }
    }

    for (var key in output) {
        console.log(output[key].join(''));
    }
}

//var input = [
//    ['ab**l5',
//     'bBb*555',
//     'absh*5',
//     'ttHHH',
//     'ttth'],
//    ///////////////
//    ['888**t*',
//     '8888ttt',
//     '888ttt<<',
//     '*8*0t>>hi'],
//     ///////////////
//    ['@s@a@p@una',
//     'p@@@@@@@@dna',
//     '@6@t@*@*ego',
//     'vdig*****ne6',
//     'li??^*^*']
//];

//for (var arr in input) {
//    plusRemove(input[arr]);
//    console.log('***************************************');
//}