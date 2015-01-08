function solve(arg) {
    var words = arg[0].split(/[^a-zA-Z]+/g).filter(function (v) { return v !== '' });
    var results = [];

    for (var w1 = 0; w1 < words.length; w1++) {
        for (var w2 = 0; w2 < words.length; w2++) {
            for (var w3 = 0; w3 < words.length; w3++) {
                var cognate = words[w1] + '|' + words[w2] + '=' + words[w3];
                if (words[w1] + words[w2] === words[w3] && results.indexOf(cognate) === -1 && w1 != w2 && w2 != w3 && w3 != w1) {
                    console.log(cognate);
                    results.push(cognate);
                }
            }
        }
    }

    if (results.length == 0) {
        console.log('No');
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

//for (var str in input) {
//    solve(input[str]);
//}