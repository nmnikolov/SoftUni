function printNumbers(number) {
    if (number > 0) {
        var output = '';
        for (var i = 1; i <= number; i++) {
            if ((i % 4) != 0 && (i % 5) != 0) {
                output += i + ', ';
            }
        }
        console.log(output.substring(0, output.length - 2));
    } else {
        console.log('no');
    }
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);