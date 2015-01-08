function solve(arg) {
    var output = [];

    for (var i = 0; i < arg.length; i++) {
        output.push(arg[i].split(''))
    }

    for (var row = 0; row < arg.length - 2; row++) {
        for (var col = 1; col < arg[row].length; col++) {
            var c = arg[row][col].toLowerCase();

            if (col + 1 < arg[row + 1 ].length &&
                col < arg[row + 2].length &&
                arg[row + 1][col - 1].toLowerCase() == c &&
                arg[row + 1][col].toLowerCase() == c &&
                arg[row + 1][col + 1].toLowerCase() == c &&
                arg[row + 2][col].toLowerCase() == c) {

                output[row][col] = '';
                output[row + 1][col - 1] = '';
                output[row + 1][col] = '';
                output[row + 1][col + 1] = '';
                output[row + 2][col] = '';
            }
        }
    }

    for (var i = 0; i < output.length; i++) {
        console.log(output[i].join(''));
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

//for (var str in input) {
//    solve(input[str]);
//}