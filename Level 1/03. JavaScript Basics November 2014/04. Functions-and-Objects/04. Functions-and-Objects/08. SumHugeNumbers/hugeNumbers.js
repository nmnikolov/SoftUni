function sumTwoHugeNumbers(value) {
    var sum = '';
    var rest = 0;
    var longest = value[0].length >= value[1].length ? value[0] : value[1];
    var smallest = value[0].length < value[1].length ? value[0] : value[1];

    while (smallest.length < longest.length) {
        smallest = '0' + smallest;
    }

    for (var i = longest.length - 1; i >= 0; i--) {
        var sumOfDigits = '' + (Number(longest[i]) + Number(smallest[i]) + rest);

        if (sumOfDigits.length > 1) {
            sum = Number(sumOfDigits[1]) + sum;
            rest = Number(sumOfDigits[0]);
        } else {
            sum = sumOfDigits + sum;
            rest = 0;
        }
    }

    return sum;
}

var input = [
    ['155', '65'],
    ['123456789', '123456789'],
    ['887987345974539', '4582796427862587'],
    ['347135713985789531798031509832579382573195807', '817651358763158761358796358971685973163314321']];

for (var array in input) {
    console.log(sumTwoHugeNumbers(input[array]));
}