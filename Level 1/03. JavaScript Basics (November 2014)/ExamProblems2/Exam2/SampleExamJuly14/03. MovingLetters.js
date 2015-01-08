function solve(arg) {
    var words = arg[0].split(/[\s]+/g)
    var str = '';

    while (words.length != 0) {
        for (var i = 0; i < words.length; i++) {
            var lastChar = words[i].length - 1;
            str += words[i][lastChar];
            words[i] = words[i].substr(0, lastChar);
        }
        words = words.filter(function (v) { return v !== '' });
    }
    
    var chars = str.split('');

    for (var i = 0; i < chars.length; i++) {
        var char = chars[i];
        var move = (char.toUpperCase().charCodeAt(0) - 64 + i) % (chars.length);
        chars.splice(i, 1);
        chars.splice(move, 0, char);

    }
    console.log(chars.join(''));
}

//var input = [
//    ['Fun exam right'],
//    ['Hi exam']
//];

//for (var str in input) {
//    solve(input[str]);
//}