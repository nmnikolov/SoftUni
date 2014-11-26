function reverseString(str) {
    var firstBracket = '';
    var lastBracket = '';
    var bracketsCount = 0;

    for (var i = 0; i < str.length; i++) {
        if (str[i] === '(') {
            bracketsCount++;
        }

        if (str[i] === ')') {
            bracketsCount--;
        }

        if (firstBracket == '') {
            firstBracket = str[i];
        }

        lastBracket = str[i];
    }

    if (firstBracket == '(' && lastBracket == ')' && bracketsCount == 0) {
        return 'correct';
    }

    return 'incorrect';
}

console.log(reverseString('( ( a + b ) / 5 – d )'));
console.log(reverseString(') ( a + b ) )'));
console.log(reverseString('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));