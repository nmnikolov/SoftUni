function solve(arg) {  
    var temp = {};
    var results = {};

    for (var i = 0; i < arg.length; i++) {
        var row = arg[i].split(/\/|:|\-/g);

        add(row[0].trim(), row[1].trim(), Number(row[2]), Number(row[3]));
        add(row[1].trim(), row[0].trim(), Number(row[3]), Number(row[2]));
    }

    var teams = Object.keys(temp).sort();

    for (var i in teams) {
        var team = teams[i];
        results[team] = temp[team];
    }

    console.log(JSON.stringify(results));

    function add(team, opponent, gf, ga) {
        if (temp.hasOwnProperty(team)) {
            temp[team].goalsScored += gf;
            temp[team].goalsConceded += ga;
            if (temp[team].matchesPlayedWith.indexOf(opponent) == -1) {
                temp[team].matchesPlayedWith.push(opponent);
                temp[team].matchesPlayedWith.sort();
            }

        } else {
            temp[team] = {
                'goalsScored': gf,
                'goalsConceded': ga,
                'matchesPlayedWith': [opponent]
            };
        }
    }   
}

var input = [
    ['Germany / Argentina: 1-0',
     'Brazil / Netherlands: 0-3',
     'Netherlands / Argentina: 0-0',
     'Brazil / Germany: 1-7',
     'Argentina / Belgium: 1-0',
     'Netherlands / Costa Rica: 0-0',
     'France / Germany: 0-1',
     'Brazil / Colombia: 2-1']
];

for (var str in input) {
    solve(input[str]);
}