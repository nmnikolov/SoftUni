function solve(arr) {
	var table = arr.slice(0, 2);
	var prices = [];
	var products = [];

	for (var i = 2; i < arr.length - 1; i++) {
	    var row = arr[i].split(/(?:<tr><td>|<\/td><td>|<\/td><\/tr>)+/g).filter(Boolean);

	    if (prices.indexOf(Number(row[1])) === -1) {
	        prices.push(Number(row[1]));
	    }

	    if (products.indexOf(row[0]) === -1) {
	        products.push(row[0]);
	    }
	}

	prices.sort(function (a, b) { return a - b });
	products.sort();

	for (var price in prices) {
		for (var product in products) {
		    for (var i = 2; i < arr.length - 1; i++) {
		        var row = arr[i].split(/(?:<tr><td>|<\/td><td>|<\/td><\/tr>)+/g).filter(Boolean);
			    if (Number(row[1]) === prices[price] && row[0] === products[product]) {
			        table.push(arr[i]);
			    }
			}
		}
	}
	table.push(arr[arr.length - 1]);
	return table.join('\n');
}

//var input = [
//	['<table>',
//	 '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
//	 '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
//	 '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
//	 '<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
//	 '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
//	 '<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
//	 '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
//	 '</table>']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}