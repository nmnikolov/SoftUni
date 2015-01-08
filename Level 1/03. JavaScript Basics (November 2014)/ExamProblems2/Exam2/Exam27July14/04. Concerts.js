function solve(arg) {
    var concerts = {};
    var sorted = {};

    for (var i = 0; i < arg.length; i++) {
        var row = arg[i].split(/\s+\|\s+/g);
        var town = row[1];
        var venue = row[3];
        var band = row[0];

        if (concerts.hasOwnProperty(town)) {
            if (concerts[town].hasOwnProperty(venue)) {
                if (concerts[town][venue].indexOf(band) == -1) {
                    concerts[town][venue].push(band);
                }              
            } else {
                concerts[town][venue] = [band];
            }
        } else {
            concerts[town] = {};
            concerts[town][venue] = [band];
        }   
    }

    var towns = Object.keys(concerts).sort();

    for (var i in towns) {
        var town = towns[i];
        var venues = Object.keys(concerts[town]).sort();
        sorted[town] = {};

        for (var j in venues) {
            var venue = venues[j];
            sorted[town][venue] = concerts[town][venue].sort();            
        }
    }

    console.log(JSON.stringify(sorted));
}

//var input = [
//    ['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
//    'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
//    'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
//    'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
//    'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
//    'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
//    'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
//    'Helloween | London | 28-Jul-2014 | Wembley Stadium',
//    'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
//    'Metallica | London | 03-Oct-2014 | Olympic Stadium',
//    'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
//    'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium']
//];

//for (var str in input) {
//    solve(input[str]);
//}