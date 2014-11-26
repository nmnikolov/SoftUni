function findLargestBySumOfDigits(arr) {
    var maxSum = Number.MIN_VALUE;
    var number;

    for (var num in arr) {
        if (typeof(arr[num]) === 'number' && arr[num] % 1 === 0) {
            var tempSum = sumDigits(Math.abs(arr[num]));
            if (tempSum > maxSum) {
                maxSum = tempSum;
                number = arr[num];
            }
        } else {
            return undefined;
        }
    }

    return number;
}

function sumDigits(number) {
    var str = number.toString();
    var sum = 0;

    for (var i = 0; i < str.length; i++) {
        sum += parseInt(str.charAt(i), 10);
    }

    return sum;
}

var arrays = [
    [5, 10, 15, 111],
    [33, 44, -99, 0, 20],
    ['hello'],
    [5, 3.3]
];

for (var array in arrays) {
    console.log(findLargestBySumOfDigits(arrays[array]));
}