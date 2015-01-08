function solve(arg) {
    var log = {};

    for (var i = 1; i <= arg[0]; i++) {
        var row = arg[i].split(' ');
        var name = row[1];
        var duration = parseInt(row[2]);
        var ip = row[0];

        if (log.hasOwnProperty(name)) {
            log[name].duration += duration;
            if (log[name].ip.indexOf(ip) == -1) {
                log[name].ip.push(ip);
            }
        } else {
            log[name] = {duration: duration, ip : [ip]}
        }
    }

    var names = Object.keys(log);
    names.sort();

    for (var i in names) {
        var name = names[i];
        var output = name + ': ' + log[name].duration + ' [' + log[name].ip.sort().join(', ') + ']';
        console.log(output);
    }
}

//var input = [
//    ['7',
//     '192.168.0.11 peter 33',
//     '10.10.17.33 alex 12',
//     '10.10.17.35 peter 30',
//     '10.10.17.34 peter 120',
//     '10.10.17.34 peter 120',
//     '212.50.118.81 alex 46',
//     '212.50.118.81 alex 4']
//];

//for (var str in input) {
//    solve(input[str]);
//}