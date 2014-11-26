function solve(arr) {
    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    var prev = undefined;
    
    for (var i = 0; i < arr.length; i++) {
        var trend;
        var rounded = Number(arr[i]).toFixed(2);
        rounded = Number(rounded);
       
        if (i === 0 || rounded === prev) {
            trend = 'fixed';           
        } else if (rounded > prev) {
            trend = 'up';
        } else {
            trend = 'down';
        }

        prev = rounded;
        console.log('<tr><td>%s</td><td><img src="%s.png"/></td></td>', rounded.toFixed(2), trend);
    }
    console.log('</table>');
}

//var input = [
//	['50', '60'],
//    ['36.333', '36.5', '37.019', '35.4', '35', '35.001', '36.225']
//];

//for (var arr in input) {
//    solve(input[arr])
//}