function convertDigitToWord(digit) {
    var word;
    switch (digit) {
        case 1: word = 'one'; break;
        case 2: word = 'two'; break;
        case 3: word = 'three'; break;
        case 4: word = 'four'; break;
        case 5: word = 'five'; break;
        case 6: word = 'six'; break;
        case 7: word = 'seven'; break;
        case 8: word = 'eight'; break;
        case 9: word = 'nine'; break;
        default: word = 'not a digit'; break;
    }

    console.log(word);
}

for (var i = 0; i < 9; i++) {
    convertDigitToWord(i + 1);
}