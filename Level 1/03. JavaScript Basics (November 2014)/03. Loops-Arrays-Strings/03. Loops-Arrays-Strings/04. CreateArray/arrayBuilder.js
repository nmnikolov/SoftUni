function createArray() {
    var numbersArray = new Array (20);

    for (var i = 0; i < numbersArray.length; i++) {
        numbersArray[i] = i * 5;
    }

    console.log(numbersArray.join(' '));
}

createArray();