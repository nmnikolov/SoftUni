function findPalindromes(str) {
    var arr = str.toLowerCase().split(/\W+/).filter(function(v){return v!==''});

    var palindromes = [];

    for (var i = 0; i < arr.length; i++) {
        var reversed = arr[i].split('').reverse().join('');

        if (arr[i] === reversed) {
            palindromes.push(arr[i]);
        }
    }

    return palindromes.join(', ');
}

console.log(findPalindromes('There is a man, his name was Bob.'));