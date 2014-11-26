function findNthDigit(arr) {
    var number = arr[1].toString().replace(/[^0-9]+/g, '');

    if (number.length >= arr[0]) {
        return Number(number.charAt(number.length - arr[0]))
    }

    return undefined;
}

var arrays = [
    [1, 6],
    [2, -55],
    [6, 923456],
    [3, 1451.78],
    [6, 888.88]
];

for (var array in arrays) {
    var result = findNthDigit(arrays[array]);

    if (result) {
        console.log(result);
    } else {
        console.log("The number doesn't have %d digits", arrays[array][0]);
    }
}