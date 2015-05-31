function solve(arr) {
    var TRACK_BORDER_SYMBOL = '#',
        TRACK_PATH_SYMBOL = '.',
        maxJumps = Number(arr[0]),
        lenght = Number(arr[1]),
        track = new Array(lenght + 1).join(TRACK_BORDER_SYMBOL),
        flees = [],
        jumps = 0,
        winnerPossition = 0,
        winner,
        fleeTrack;

    for (var i = 2, len = arr.length; i < len; i++) {
        var row = arr[i].split(/,\s+/);
        flees.push({
            'name': row[0],
            'jumpDistance': parseInt(row[1]),
            'currPos': 0
        });
    }

    while (winnerPossition < lenght - 1 && jumps++ < maxJumps) {
        for (var flee in flees) {
            flees[flee].currPos += flees[flee].jumpDistance;
            flees[flee].currPos = flees[flee].currPos >= lenght ? lenght - 1 : flees[flee].currPos;
            if (flees[flee].currPos >= winnerPossition) {
                winnerPossition = flees[flee].currPos;
                winner = flees[flee].name;
            }

            if (winnerPossition >= lenght - 1) {
                break;
            }
        }
    }

    winner = winner ? winner : flees[0].name;

    console.log(track + '\n' + track);
    printFlees();
    console.log(track + '\n' + track);
    console.log('Winner: ' + winner);

    function printFlees() {
        flees.forEach(function (flee) {
            fleeTrack = new Array(flee.currPos + 1).join(TRACK_PATH_SYMBOL) +
                flee.name[0].toUpperCase() +
                new Array(lenght - flee.currPos).join(TRACK_PATH_SYMBOL);

            console.log(fleeTrack);
        });
    }
}

//var input = [
//	['10',
//    '19',
//    'angel, 11',
//    'Boris, 10',
//    'Georgi, 3',
//    'Dimitar, 7'],

//    ['3',
//    '5',
//    'cura, 1',
//    'Pepi, 1',
//	'UlTraFlea, 1',
//	'BOIKO, 1']
//];

//input.forEach(function(arr) { solve(arr); })