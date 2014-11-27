function isPrime(number) {
    if (number < 2) {
        return false;
    } else {
        for (var i = 2; i <= Math.sqrt(number) ; i++) {
            if (number % i == 0) {
                return false;
            }
        }    
    }

    return true;
}

console.log(isPrime(2));
console.log(isPrime(254));
console.log(isPrime(587));