function solve(arg) {
    var tip;
    var bill = Number(arg[0]);

    switch(arg[1]) {
        case 'happy': tip = bill * 0.1; break;
        case 'married': tip = bill * 0.0005; break;
        case 'drunk': drunk(); break;
        default: tip = bill * 0.05; break;
    }

    function drunk() {
        tip = bill * 0.15;
        tip = Math.pow(tip, tip.toString()[0]);
    }

    console.log(tip.toFixed(2));
}

//var input = [
//    ['120.44', 'happy'],
//    ['1230.83', 'drunk'],
//    ['716.00', 'bored']
//];

//for (var str in input) {
//    solve(input[str]);
//}