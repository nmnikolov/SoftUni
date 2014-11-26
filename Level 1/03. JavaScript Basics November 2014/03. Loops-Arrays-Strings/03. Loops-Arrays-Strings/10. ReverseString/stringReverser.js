function reverseString(str) {
    str = str.split("").reverse().join("");

    return str;
}

console.log(reverseString('sample'));
console.log(reverseString('softUni'));
console.log(reverseString('java script'));