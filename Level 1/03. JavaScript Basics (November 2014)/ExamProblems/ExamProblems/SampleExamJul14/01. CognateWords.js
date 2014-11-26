function solve(arr) {
    var words = arr[0].split(/[^A-z]+/g).filter(function(v){return v!==''});
    var result = [];

    if (words.length < 3) {
        return 'No';
    }

    for (var i = 0; i < words.length; i++) {
        for (var j = 0; j < words.length; j++) {
            for (var k = 0; k < words.length; k++) {
                if (words[i] + words[j] == words[k] && i != j && j != k) {
                    result.push(words[i] + '|' + words[j] + '=' + words[k]);                  
                }
            }
        }
    }

    result = result.reverse().filter(function (e, i, arr) {
        return arr.indexOf(e, i + 1) === -1;
    }).reverse();

    if (result.length !== 0) {
        return result.join('\n');
    } else {
        return 'No';;
    }
}

//var input = [
//    ['java..?|basics/*-+=javabasics'],
//    ['Hi, Hi, Hihi'],
//    ['Uni(lo,.ve=I love SoftUni (Soft)'],
//    ['a a aa a'],
//    ['x a ab b aba a hello+java a b aaaaa'],
//    ['aa bb bbaa'],
//    ['ho hoho']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}