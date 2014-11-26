function reverseWordsInString(str) {
    var reversed = str.split(" ");

    for (var i = 0; i < reversed.length; i++) {
        reversed[i] = reversed[i].split('').reverse().join('');
    }

    return reversed.join(' ');
}

var input = [
    'Hello, how are you.',
    'Life is pretty good, isn\'t it?'
];

for (var string in input) {
    console.log(reverseWordsInString(input[string]));
}