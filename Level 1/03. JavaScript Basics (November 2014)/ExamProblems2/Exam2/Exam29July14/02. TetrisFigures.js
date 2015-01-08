function solve(arg) {
    var tetris = { "I": 0, "L": 0, "J": 0, "O": 0, "Z": 0, "S": 0, "T": 0}
    var c = 'o';
    var rows = arg.length;
    var cols = arg[0].length;
    
    for (var row = 0; row < arg.length; row++) {
        for (var col = 0; col < arg[row].length; col++) {
            // -I-
            if (row + 3 < rows &&
                arg[row][col] == c &&
                arg[row + 1][col] == c &&
                arg[row + 2][col] == c &&
                arg[row + 3][col] == c) {
                tetris.I++;
            }

            // -L-
            if (row + 2 < rows &&
                col + 1 < cols &&
                arg[row][col] == c &&
                arg[row + 1][col] == c &&
                arg[row + 2][col] == c &&
                arg[row + 2][col + 1] == c) {
                tetris.L++;
            }

            // -J-
            if (row + 2 < arg.length &&
                col - 1 >= 0 &&
                arg[row][col] == c &&
                arg[row + 1][col] == c &&
                arg[row + 2][col] == c &&
                arg[row + 2][col - 1] == c) {
                tetris.J++;
            }

            // -O-
            if (row + 1 < rows &&
                col + 1 < cols &&
                arg[row][col] == c &&
                arg[row][col + 1] == c &&
                arg[row + 1][col] == c &&
                arg[row + 1][col + 1] == c) {
                tetris.O++;
            }

            // -Z-
            if (row + 1 < rows &&
                col + 2 < cols &&
                arg[row][col] == c &&
                arg[row][col + 1] == c &&
                arg[row + 1][col + 1] == c &&
                arg[row + 1][col + 2] == c) {
                tetris.Z++;
            }

            // -S-
            if (row + 1 < rows &&
                col - 2 >= 0 &&
                arg[row][col] == c &&
                arg[row][col - 1] == c &&
                arg[row + 1][col - 1] == c &&
                arg[row + 1][col - 2] == c) {
                tetris.S++;
            }

            // -T-
            if (row + 1 < rows &&
                col + 2 < cols &&
                arg[row][col] == c &&
                arg[row][col + 1] == c &&
                arg[row][col + 2] == c &&
                arg[row + 1][col + 1] == c) {
                tetris.T++;
            }
        }
    }

    console.log(JSON.stringify(tetris));
}

//var input = [
//    ['--o--o-',
//     '--oo-oo',
//     'ooo-oo-',
//     '-ooooo-',
//     '---oo--']
//];

//for (var str in input) {
//    solve(input[str]);
//}