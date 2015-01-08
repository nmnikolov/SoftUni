function solve(arg) {
    var matrix = [];
    var longest = 0;
    var rotate = arg[0].match(/\d+/g) % 360;

    for (var i = 1; i < arg.length; i++) {
        matrix.push(arg[i]);
        longest = Math.max(longest, arg[i].length);
    }

    switch (Number(rotate)) {
        case 90:
            matrix = rotate90(); break;
        case 180:
            matrix = rotate180(); break;
        case 270:
            matrix = rotate90();
            longest = arg.length - 1;
            matrix = rotate180();
            break;
    }

    function rotate90() {
        var newArr = [];
        for (var i = 0; i < longest; i++) {
            var temp = '';
            for (var j = matrix.length - 1; j >= 0; j--) {
                temp += i < matrix[j].length ? matrix[j][i] : ' ';
            }
            newArr.push(temp);
        }
        return newArr;
    }

    function rotate180() {
        var newArr = [];       
        for (var i = matrix.length - 1; i >= 0; i--) {
            var temp = matrix[i].split('').reverse().join('');
            while (temp.length < longest) {
                temp = ' ' + temp;
            }
            newArr.push(temp);
        }
        return newArr;
    }

    console.log(matrix.join('\n'));
}

//var input = [
//    ['Rotate(90)',
//     'hello',
//     'softuni',
//     'exam'],
//     ['Rotate(180)',
//     'hello',
//     'softuni',
//     'exam'],
//     ['Rotate(270)',
//     'hello',
//     'softuni',
//     'exam']
//];

//for (var str in input) {
//    solve(input[str]);
//}