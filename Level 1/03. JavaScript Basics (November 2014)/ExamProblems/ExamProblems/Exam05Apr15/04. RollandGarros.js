function solve(arr) {
    var rollandGarros = [];

    arr.forEach(function (play) {
        var pattern = /(.*?)\s*vs\.\s*(.*?)\s*:\s*(.*)/,
            match;

        if (match = pattern.exec(play)) {
            var host = match[1].replace(/\s+/, ' '),
            guest = match[2].replace(/\s+/, ' '),
            result = match[3].split(/\s+/);

            processMatchResult(host, result);
            result = reverseResult(result);
            processMatchResult(guest, result);
        }
    });

    function reverseResult(result) {
        var reversed = result.map(function (m) {
            return m.split('').reverse().join('');
        });

        return reversed;
    }

    function processMatchResult(name, result) {
        var player,
            matchWon,
            setsWon = 0,
            setsLost = 0,
            gamesWon = 0,
            gamesLost = 0;

        player = rollandGarros.filter(function(pl) {
            return pl.name === name;
        })[0];

        result.forEach(function(s) {
            var res = s.split('-');
            gamesWon += Number(res[0]);
            gamesLost += Number(res[1]);
            setsWon += Number(res[0]) > Number(res[1]) ? 1 : 0;
            setsLost += Number(res[0]) < Number(res[1]) ? 1 : 0;
        });

        matchWon = setsWon > setsLost ? true : false;

        if (player) {
            player.matchesWon += matchWon ? 1 : 0;
            player.matchesLost += !matchWon ? 1 : 0;
            player.setsWon += setsWon;
            player.setsLost += setsLost;
            player.gamesWon += gamesWon;
            player.gamesLost += gamesLost;
        } else {
            rollandGarros.push({
                name: name,
                matchesWon: matchWon ? 1 : 0,
                matchesLost: !matchWon ? 1 : 0,
                setsWon: setsWon,
                setsLost: setsLost,
                gamesWon: gamesWon,
                gamesLost: gamesLost
            });
        }
    }

    rollandGarros.sort(function(p1, p2) {
        if (p1.matchesWon !== p2.matchesWon) {
            return p2.matchesWon - p1.matchesWon;
        }

        if (p1.setsWon !== p2.setsWon) {
            return p2.setsWon - p1.setsWon;
        }

        if (p1.gamesWon !== p2.gamesWon) {
            return p2.gamesWon - p1.gamesWon;
        }

        return p1.name.localeCompare(p2.name);
    });

    //console.log(rollandGarros);
    console.log(JSON.stringify(rollandGarros));
}

//var input = [['Novak Djokovic vs. Roger Federer : 6-3 6-3', 'Roger    Federer    vs.        Novak Djokovic    :         6-2 6-3', 'Rafael Nadal vs. Andy Murray : 4-6 6-2 5-7', 'Andy Murray vs. David Ferrer : 6-4 7-6', 'Tomas Bedrych vs. Kei Nishikori : 4-6 6-4 6-3 4-6 5-7', 'Grigor Dimitrov vs. Milos Raonic : 6-3 4-6 7-6 6-2', 'Pete Sampras vs. Andre Agassi : 2-1', 'Boris Beckervs.Andre        			Agassi:2-1']];
//
//input.forEach(function(arr) { solve(arr); });