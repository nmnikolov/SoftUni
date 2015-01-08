function solve(arg) {
    var output = [];
    for (var i in arg) {
        output.push(arg[i].split(''));
    }

    for (var row = 0; row < output.length - 1; row++) {
        for (var col = 1; col < output[row].length; col++) {
            var c = arg[row][col];
            if (arg[row + 1][col - 1] == c &&
                arg[row + 1][col] == c &&
                arg[row + 1][col + 1] == c &&
                col + 1 < arg[row + 1].length) {

                output[row][col] = '*';
                output[row + 1][col - 1] = '*';
                output[row + 1][col] = '*';
                output[row + 1][col + 1] = '*';
            }
        }
    }

    for (var i in output) {
        console.log(output[i].join(''));
    }  
}

//var input = [
//    ['abcdexgh',
//     'bbbdxxxh',
//     'abcxxxxx',]
//];

//for (var str in input) {
//    solve(input[str]);
//}