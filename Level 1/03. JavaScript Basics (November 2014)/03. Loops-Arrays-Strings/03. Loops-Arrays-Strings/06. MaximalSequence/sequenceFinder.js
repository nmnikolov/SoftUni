function findMaxSequence(arr) {
    var maxSequence = [[arr[0]]];
    var currentSequence = [arr[0]];

    for (var i = 1; i < arr.length; i++) {

        if (i == arr.length - 1) {
            if (arr[i] === arr[i - 1]) {
                currentSequence.push(arr[i]);
            }
            if (currentSequence.length >= maxSequence[0].length) {
                maxSequence = [];
                maxSequence.push(currentSequence);
            }
        }
        else if (arr[i] === arr[i - 1]) {
            currentSequence.push(arr[i]);
        } else {
            if (currentSequence.length >= maxSequence[0].length) {
                maxSequence = [];
                maxSequence.push(currentSequence);                
            }

            currentSequence = [arr[i]];
        }
    }

    return maxSequence[0];
}

console.log(findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]));
console.log(findMaxSequence(['happy']));
console.log(findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']));