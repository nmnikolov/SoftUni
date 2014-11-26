function solve(arr) {

	var output = ['<table>', '<tr><th>Num</th><th>Square</th><th>Fib</th></tr>'];

	for (var i = Number(arr[0]); i <= Number(arr[1]); i++) {
	    var fib = isFibonacci(i);
	    var row = '<tr><td>' + i + '</td><td>' + i * i + '</td><td>' + fib + '</td></tr>';
	    output.push(row);	    
	}

	output.push('</table>');

	function isFibonacci(number) {
	    var fib1 = 0;
	    var fib2 = 1;
	    do {
	        var saveFib1 = fib1;
	        fib1 = fib2;
	        fib2 = saveFib1 + fib2;
	    }
	    while (fib2 < number);

	    if (fib2 == number)
	        return 'yes';
	    else
	        return 'no';
	}

	return output.join('\n');
}

//var input = [
//	[2, 6],
//	[55, 56]
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}