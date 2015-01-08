function solve(arg) {

    console.log('<ul>');

    for (var i = Number(arg[0]) ; i <= Number(arg[1]) ; i++) {
        if (isRakiya(i)) {
            console.log('<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>');
        } else {
            console.log('<li><span class=\'num\'>' + i + '</span></li>');
        }
    }

    console.log('</ul>');

    function isRakiya(n) {
        n = n.toString();
        for (var i = 0; i < n.length - 1; i++) {
            var temp = '' + n[i] + n[i + 1]
            var count = 0;

            for (var j = i + 2; j < n.length; j++) {
                if ('' + n[j] + n[j + 1] === temp) {
                    count++;
                    j++;
                }
            }

            if (count == 1) {
                return true;
            }
        }

        return false;
    }
}

//var input = [
//    [5, 8],
//    [11210, 11215]
//];

//for (var str in input) {
//    solve(input[str]);
//}