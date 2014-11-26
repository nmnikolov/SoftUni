function solve(arr) {
    var hex = [];
    var numbers = arr[0].split(/[^\d]/).filter(Boolean);

    for (var i = 0; i < numbers.length; i++) {
        var number = (Number(numbers[i])).toString(16);
        while (number.length < 4) {
            number = '0' + number;
        }
        number = '0x' + number.toUpperCase();
        hex.push(number);
    }

    console.log(hex.join('-'));
}

//var input = [
//    ['5tffwj(//*7837xzc2---34rlxXP%$".'],
//    ['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312'],
//    ['20']
//];

//for (var arr in input) {
//    solve(input[arr])
//}