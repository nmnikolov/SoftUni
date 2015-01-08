function solve(arg) {
    console.log('<table>');
    console.log('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');

    for (var i = Number(arg[0]); i <= Number(arg[1]); i++) {
        var numFib = isFib(i);
        var row = '<tr><td>' + i + '</td><td>' + i * i + '</td><td>' + numFib + '</td></tr>';
        console.log(row);
    }
    
    console.log('</table>');   
    
    function isFib(val) {
        var prev = 0;
        var curr = 1;
        while (prev <= val) {
            if (prev == val) {
                return 'yes';
            }
            curr = prev + curr;
            prev = curr - prev;
        }
        return 'no';
    }
}

//var input = [
//    [2, 6],
//    [55, 56]
//];

//for (var str in input) {
//    solve(input[str]);
//}