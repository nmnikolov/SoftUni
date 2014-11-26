function findMaxSequence(arr) {

    var sequences = [];
    var currSequence = [arr[0]];

    for (var i = 1; i < arr.length; i++) {
        if (i == arr.length - 1 && arr[i] > arr[i - 1]) {
            currSequence.push(arr[i]);
            sequences.push(currSequence);
        } else if (arr[i] > arr[i - 1]) {
            currSequence.push(arr[i]);
        } else {
            sequences.push(currSequence);
            currSequence = [];
            currSequence.push(arr[i]);
        }
    }

    sequences.sort(function (a, b) {
        return b.length - a.length;
    });

    if (sequences[0].length > 1) {
        return sequences[0];
    } else {
        return 'no';
    }
}

console.log(findMaxSequence([3, 2, 3, 4, 2, 2, 4]));
console.log(findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]));
console.log(findMaxSequence([3, 2, 1]));