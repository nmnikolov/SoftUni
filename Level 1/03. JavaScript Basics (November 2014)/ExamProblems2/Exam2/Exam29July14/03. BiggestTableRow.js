function solve(arg) {
    var max = -Number.MAX_VALUE;
    var numbers;
    var isFound = false;
    var pattern = /<tr><td>.*<\/td><td>(.*)<\/td><td>(.*)<\/td><td>(.*)<\/td><\/tr>/g;

    for (var i = 2; i < arg.length - 1; i++) {       
        while (row = pattern.exec(arg[i])) {
            var sum = undefined;
            var temp = [];

            for (var j = 1; j < 4; j++) {
                if (!isNaN(row[j])) {
                    sum = sum == undefined ? Number(row[j]) : sum + Number(row[j]);
                    temp.push(row[j]);
                }
            }

            if (sum > max) {
                max = sum;
                numbers = temp;
                isFound = true;
            }
        }
    }

    if (isFound) {
        console.log('%s = %s', max, numbers.join(' + '));
    } else {
        console.log('no data');
    }
}

//var input = [
//    ['<table>',
//     '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//     '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
//     '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
//     '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
//     '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
//     '</table>']
//];

//for (var str in input) {
//    solve(input[str]);
//}