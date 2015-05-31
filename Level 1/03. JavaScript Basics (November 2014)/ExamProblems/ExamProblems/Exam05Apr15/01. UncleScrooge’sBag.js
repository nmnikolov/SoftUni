function solve(arr) {
    var amount = {
            'gold': 0,
            'silver': 0,
            'bronze': 0
        },
        coins = 0,
        pattern = /coin\s+(.*)/i,
        match,
        number;

    arr.forEach(function(el) {
        if ((match = pattern.exec(el)) && !isNaN(match[1])) {
            number = Number(match[1]);
            if (parseInt(number) === number && number > 0) {
                coins += parseInt(number);
            }
        }
    });

    amount.gold = parseInt(coins / 100);
    coins %= 100;
    amount.silver = parseInt(coins / 10);
    amount.bronze = coins - amount.silver * 10;

    for (var key in amount) {
        console.log(key + ' : ' + amount[key]);
    }
}

//var input = [
//	['coin 1','coin 2', 'coin 5', 'coin 10', 'coin 20', 'coin 50', 'coin 100', 'coin 200', 'coin 500','cigars 1'],
//	['coin one', 'coin two', 'coin five', 'coin ten', 'coin twenty', 'coin fifty', 'coin hundred', 'cigars 1'],
//	['coin 1', 'coin two', 'coin 5', 'coin 10.50', 'coin 20', 'coin 50', 'coin hundred', 'cigars 1']
//];

//input.forEach(function(arr) { solve(arr); })