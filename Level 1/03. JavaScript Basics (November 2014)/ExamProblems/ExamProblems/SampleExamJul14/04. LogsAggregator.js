function solve(arr) {
    var log = {};
    var names = [];
    var ip, name, duration;
    
    for (var i = 1; i <= arr[0]; i++) {
        var logRow = arr[i].split(' ');
        name = logRow[1];
        duration = logRow[2];
        ip = logRow[0];       
        
        if (log.hasOwnProperty(name)) {
            log[name]['duration'] += Number(logRow[2]);           
            if (log[name]['ip'].indexOf(ip) === -1) {
                log[name]['ip'].push(ip);
                log[name]['ip'].sort();
            }           
        } else {
            log[name] = {'duration': Number(logRow[2]), 'ip': [logRow[0]]};
            names.push(name);          
        }
    }

    names.sort();
    var output = '';

    for (var i = 0; i < names.length; i++) {
        name = names[i];
        output += name + ': ' + log[name]['duration'] + ' [' + log[name]['ip'].join(', ') + ']\n';    
    }

    return output;
}

//var input = [
//    ['7',
//    '192.168.0.11 peter 33',
//    '10.10.17.33 alex 12',
//    '10.10.17.35 peter 30',
//    '10.10.17.34 peter 120',
//    '10.10.17.34 peter 120',
//    '212.50.118.81 alex 46',
//    '212.50.118.81 alex 4'],
//    ['2',
//    '84.238.140.178 nakov 25',
//    '84.238.140.178 nakov 35']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}