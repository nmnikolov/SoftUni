function solve(arr) {
    var degrees = Number(arr[0].replace(/[^0-9]+/g, '')) % 360;
    arr.splice(0, 1);
    var matrix = [];
    var longest = 0;

    for (var i = 0; i < arr.length; i++) {
        longest = Math.max(longest, arr[i].length);
    }

    switch (degrees) {
        case 0: matrix = arr.slice(); break;
        case 90: rotate90(); break;
        case 180: rotate180(); break;
        case 270: rotate270(); break;
    }

    function rotate90() {
        for (var col = 0; col < longest; col++) {
            var temp = '';
            for (var row = arr.length - 1; row >= 0; row--) {
                if (col < arr[row].length) {
                    temp += arr[row][col];
                } else {
                    temp += ' ';
                }
            }
            matrix.push(temp);
        }
    }

    function rotate180() {
        for (var row = arr.length - 1; row >= 0 ; row--) {
            var temp = arr[row].split("").reverse().join("");
            while (temp.length < longest) {
                temp = ' ' + temp;
            }
            matrix.push(temp);
        }
    }

    function rotate270() {
        rotate90();
        matrix.reverse();
        for (var i = 0; i < matrix.length; i++) {
            matrix[i] = matrix[i].split("").reverse().join("");
        }
    }
    return matrix.join('\n');
}

//var input = [
//	['Rotate(90)',
//     'hello',
//     'softuni',
//     'exam'],
//	['Rotate(180)',
//     'hello',
//     'softuni',
//     'exam'],
//    ['Rotate(270)',
//     'hello',
//     'softuni',
//     'exam'],
//    ['Rotate(720)',
//    'js',
//    'exam'],
//    ['Rotate(810)',
//     'js',
//     'exam'],
//    ['Rotate(0)',
//     'js',
//     'exam']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}