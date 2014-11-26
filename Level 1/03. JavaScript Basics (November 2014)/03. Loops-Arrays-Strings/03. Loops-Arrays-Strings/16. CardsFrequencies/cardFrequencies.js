function findCardFrequency(str) {
    str = str.toUpperCase().replace(/[^0-9JQKA]+/g, ' ').trim();
    var cards = str.split(' ');

    var uniqueCards = cards.reverse().filter(function (e, i, arr) {
        return arr.indexOf(e, i + 1) === -1;
    }).reverse();

    for (var i = 0; i < uniqueCards.length; i++) {
        var pattern = new RegExp('\\b' + uniqueCards[i] + '\\b', 'g');
        var count = (str.match(pattern)).length;

        console.log("%s -> %s%", uniqueCards[i], (count / cards.length * 100).toFixed(2));
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
console.log();
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
console.log();
findCardFrequency('10♣ 10♥');