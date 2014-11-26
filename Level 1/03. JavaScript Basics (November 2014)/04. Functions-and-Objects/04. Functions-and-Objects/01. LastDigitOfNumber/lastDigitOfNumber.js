function lastDigitAsText(number) {
    number = typeof number === 'number' ? number : 'no a number';
    var word = '';

    switch (Math.abs(number % 10)) {
        case 0: word = 'Zero'; break;
        case 1: word = 'One'; break;
        case 2: word = 'Two'; break;
        case 3: word = 'Three'; break;
        case 4: word = 'Four'; break;
        case 5: word = 'Five'; break;
        case 6: word = 'Six'; break;
        case 7: word = 'Seven'; break;
        case 8: word = 'Eight'; break;
        case 9: word = 'Nine'; break;
        default: word = 'not an integer number'; break;
    }

    return word;
}

var arr = [6, -55, 133, 14567]

for (var number in arr) {
    console.log(lastDigitAsText(arr[number]));
}