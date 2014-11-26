function solve(arr) {
    var output = arr.slice();

    for (var i = 0; i < arr.length - 1; i++) {
        for (var j = 0; j < arr[i].length; j++) {
            var letter = arr[i][j];
            var leftIndex = j - 1;
            var rightIndex = j + 1;
            if (leftIndex >= 0 && rightIndex < (arr[i + 1].length)) {
                var temp = arr[i + 1].substring(leftIndex, rightIndex + 1);

                if (temp.replace(new RegExp(letter, 'g'), '') == '') {
                    output[i] = output[i].substring(0, j) + '*' + output[i].substring(j + 1, output[i].length);
                    for (var index = leftIndex; index <= rightIndex; index++) {
                        output[i + 1] = output[i + 1].substring(0, index) + '*' + output[i + 1].substring(index + 1, output[i + 1].length);
                    }
                }
            }
        }
    }

    return output.join('\n');
}

//var input = [
//	['abcdexgh',
//     'bbbdxxxh',
//     'abcxxxxx'],
//    ['aa',
//    'aaa',
//    'aaaa',
//    'aaaaa'],
//    ['ax',
//    'xxx',
//    'b',
//    'bbb',
//    'bbbb'],
//    ['dffdsgyefg',
//     'ffffeyeee',
//     'jbfffays',
//     'dagfffdsss',
//     'dfdfa',
//     'dadaaadddf',
//     'sdaaaaa',
//     'daaaaaaasf']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}