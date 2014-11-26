function bitChecker(number) {
    var checkBit = ((number >> 3) & 1) == 1;

    return checkBit;
}

console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));