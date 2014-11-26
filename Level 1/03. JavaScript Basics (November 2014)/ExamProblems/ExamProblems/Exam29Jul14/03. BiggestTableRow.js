function solve(arr) {
    var maxSum = Number.NEGATIVE_INFINITY;
    var output = '';
    var found = false;

    for (var i = 2; i < arr.length - 1; i++) {
        var row = arr[i].split(/(?:<tr><td>|<\/td><td>|<\/td><\/tr>)+/g).filter(Boolean);
        var sum = 0;
        var tempStr = '';
        for (var j = 1; j < row.length; j++) {
            if (row[j] != '-' ) {
                sum += Number(row[j]);
                tempStr += ' ' + row[j] + ' +';
                found = true;
            }          
        }

        if (sum > maxSum) {
            maxSum = sum;
            output = maxSum + ' =' + tempStr.substring(0, tempStr.length - 2);
        }
    }

    if (!found) {
        return 'no data';
    }
    
    return output;
}

//var input = [
//	['<table>',
//	 '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//	 '<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>',
//	 '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
//	 '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
//	 '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
//	 '</table>'],
//    ['<table>',
//	 '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//	 '<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
//	 '</table>'],
//	['<table>',
//	 '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
//	 '<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>',
//	 '<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>',
//	 '<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>',
//	 '</table>']
//];

//for (var arr in input) {
//	console.log(solve(input[arr]));
//}