function checkDigit(number) {
    number = parseInt(number / 100);
    return number % 10 == 3;
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));