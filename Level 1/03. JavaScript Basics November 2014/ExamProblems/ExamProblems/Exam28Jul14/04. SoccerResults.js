function solve(arr) {
    var output = {};
    
    for (var i = 0; i < arr.length; i++) {
        var score = arr[i].split(/[/:-]+/);
        var host = score[0].trim();
        var guest = score[1].trim();
        var hostScore = Number(score[2].trim());
        var guestScore = Number(score[3].trim());
        addResult(host, guest, hostScore, guestScore);
        addResult(guest, host, guestScore, hostScore);
    }

    var teams = Object.keys(output);
    teams.sort();
    var sorted = {};

    for (var i in teams) {
        for (var key in output) {
            if (key === teams[i]) {
                sorted[key] = output[key];
            }
        }
    }

    return JSON.stringify(sorted);

    function addResult(h, g, hs, gs) {
        if (output.hasOwnProperty(h)) {
            output[h]['goalsScored'] += hs;
            output[h]['goalsConceded'] += gs;
            if (output[h]['matchesPlayedWith'].indexOf(g) === -1) {
                output[h]['matchesPlayedWith'].push(g);
                output[h]['matchesPlayedWith'].sort();
            }
        } else {
            output[h] = {goalsScored: hs, goalsConceded: gs, matchesPlayedWith: [g]};
        }
    }
}

//var input = [
//	['Germany / Argentina: 1-0',
//     'Brazil / Netherlands: 0-3',
//     'Netherlands / Argentina: 0-0',
//     'Brazil / Germany: 1-7',
//     'Argentina / Belgium: 1-0',
//     'Netherlands / Costa Rica: 0-0',
//     'France / Germany: 0-1',
//     'Brazil / Colombia: 2-1']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}