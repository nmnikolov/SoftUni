function solve(arg) {
    var current;
    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');

    for (var i = 0; i < arg.length; i++) {
        var number = Number(arg[i]).toFixed(2);
        number = Number(number);      
        console.log('<tr><td>%s</td><td><img src="%s.png"/></td></td>', number.toFixed(2), trend(number));
        current = number;
    }

    console.log('</table>');

    function trend(num) {
        if (current == undefined || current == num) {
            return 'fixed';
        }

        return num > current ? 'up' : 'down';
    }
}

//var input = [
//    ['50', '60'],
//    ['36.333', '36.5', '37.019', '35.4', '35', '35.001', '36.225']
//];

//for (var str in input) {
//    solve(input[str]);
//}