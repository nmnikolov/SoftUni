function solve(arg) {
    var numbers = arg[0].split(/[^\d]+/g).filter(function (v) { return v !== '' });
    var hexNumbers = [];

    for (var i = 0; i < numbers.length; i++) {
        var hex = Number(numbers[i]).toString(16).toUpperCase();
        
        while (hex.length < 4) {
            hex = '0' + hex;
        }

        hexNumbers.push('0x' + hex);
    }

    console.log(hexNumbers.join('-'));
}

//var input = [
//    ['5tffwj(//*7837xzc2---34rlxXP%$”.'],
//    ['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312'],
//    ['20']
//];

//for (var str in input) {
//    solve(input[str]);
//}