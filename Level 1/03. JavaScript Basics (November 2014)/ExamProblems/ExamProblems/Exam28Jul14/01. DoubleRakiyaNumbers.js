function solve(arr) {   
    var output = '<ul>\n';

    for (var i = Number(arr[0]) ; i <= Number(arr[1]); i++) {
        if (isRakiyaNumber(i)) {
            output += "<li><span class='rakiya'>" + i + "</span><a href=\"view.php?id=" + i + ">View</a></li>\n";
        } else {
            output += "<li><span class='num'>" + i + "</span></li>\n";
        }       
    }

    output += '</ul>'

    return output;

    function isRakiyaNumber(n) {
        n = n.toString();

        for (var i = 0; i < n.length - 2; i++) {
            for (var j = i + 2; j < n.length - 1; j++) {
                if (n[i] + n[i + 1] === n[j] + n[j + 1]) {
                    return true;
                }
            }
        }
        return false;
    }
}

//var input = [
//	['5', '8'],
//	['11210', '11215'],
//    ['55555', '55560'],
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}