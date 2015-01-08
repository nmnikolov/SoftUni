function solve(arg) {
    var arr = [];

    for (var i = 2; i < arg.length - 1; i++) {
        var row = arg[i].split(/<tr><td>|<\/td><td>|<\/td><\/tr>/g).filter(function (v) { return v !== '' });

        arr.push({
            'product': row[0],
            'price': row[1],
            'votes': row[2]
        });      
    }

    arr.sort(function (a, b) {
        if (a.price !== b.price) {
            return a.price - b.price;
        }
        return a.product > b.product;
    });

    console.log('<table>');
    console.log('<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');

    for (var i = 0; i < arr.length; i++) {
        console.log('<tr><td>' + arr[i].product + '</td><td>' + arr[i].price + '</td><td>' + arr[i].votes + '</td></tr>');
    }

    console.log('</table>');
}

var input = [
    ['<table>',
     '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
     '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
     '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
     '<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
     '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
     '<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
     '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
     '</table>']
];

for (var str in input) {
    solve(input[str]);
}