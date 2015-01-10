function solve(arg) {
    var position;
    var finished;

    for (var row = 0; row < arg.length; row++) {
        for (var col = 0; col < arg[row].length; col++) {
            if (arg[row][col] === 'o') {
                position = { 'row': row, 'col': col };
                break;
            }
        }
    }

    for (var row = position.row + 1; row < arg.length; row++) {
        var finished;
        var right = (arg[row].match(/>/g) || []).length;
        var left = (arg[row].match(/</g) || []).length;
        position.col += right - left;

        switch (arg[row][position.col]) {
            case '_': finished = 'Landed on the ground like a boss!'; break;
            case '~': finished = 'Drowned in the water like a cat!'; break;
            case '\\': case '/': case '|': finished = 'Got smacked on the rock like a dog!'; break;
        }

        if (finished) {
            console.log(finished);
            console.log('%s %s', row, position.col);
            return;
        }
    }
}

//var input = [
//    ['--o----------------------',
//     '>------------------------',
//     '>------------------------',
//     '>-----------------/\\-----',
//     '-----------------/--\\----',
//     '>---------/\\----/----\\---',
//     '---------/--\\--/------\\--',
//     '<-------/----\\/--------\\-',
//     '\\------/----------------\\',
//     '-\\____/------------------', ],
    
//    [
//     '-------------o-<<--------',
//     '-------->>>>>------------',
//     '---------------->-<---<--',
//     '------<<<<<-------/\\--<--',
//     '--------------<--/-<\\----',
//     '>>--------/\\----/<-<-\\---',
//     '---------/<-\\--/------\\--',
//     '<-------/----\\/--------\\-',
//     '\\------/--------------<-\\',
//     '-\\___~/------<-----------',
//    ]
//];

//for (var str in input) {
//    solve(input[str]);
//}