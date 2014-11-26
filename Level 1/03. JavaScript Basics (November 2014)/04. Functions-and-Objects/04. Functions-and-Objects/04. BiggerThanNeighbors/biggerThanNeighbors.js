function biggerThanNeighbors(index, array) {
    if (index < 0 || index >= array.length) {
        return -2;
    } else if (index === 0 || index === array.length - 1) {
        return -1; 
    } else if (array[index] > array[index - 1] && array[index] > array[index + 1]) {
        return 1
    } else {
        return 0;
    }
}

function printResult(arr) {
    var result = biggerThanNeighbors(arr[0], arr[1]);
    
    if (result === -2) {
        console.log('invalid index');
    } else if (result === -1) {
        console.log('only one neighbor');
    } else if (result === 0) {
        console.log('not bigger');
    } else if (result === 1) {
        console.log('bigger');
    }
};

var input = [
    [2, [1, 2, 3, 3, 5]],
    [2, [1, 2, 5, 3, 4]],
    [5, [1, 2, 5, 3, 4]],
    [0, [1, 2, 5, 3, 4]]
];

for (var array in input) {
    printResult(input[array]);
}