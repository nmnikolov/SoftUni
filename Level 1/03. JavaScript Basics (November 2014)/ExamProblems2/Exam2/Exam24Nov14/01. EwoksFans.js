function solve(arg) { 
    var start = new Date(1900, 00, 01);
    var middle = new Date(1973, 04, 25);
    var end = new Date(2015, 00, 01);
    var hater;
    var fan;

    for (var i = 0; i < arg.length; i++) {
        var date = arg[i].split('.');
        date = new Date(date[2], date[1] - 1, date[0]);

        if (date > start && date <  middle) {
            if (hater == undefined || date < hater) {
                hater = date;
            } 
        }
        if (date >= middle && date < end) {
            if (fan == undefined || date > fan) {
                fan = date;
            }
        }
    }

    if (fan) {
        console.log('The biggest fan of ewoks was born on %s', fan.toDateString());
    }
    if (hater) {
        console.log('The biggest hater of ewoks was born on %s', hater.toDateString());
    }
    if (!fan && !hater) {
        console.log('No result');
    }
}

//var input = [
//    ['22.03.2014', '17.05.1933', '10.10.1954'],
//    ['22.03.2000'],
//    ['22.03.1700', '01.07.2020']
//];

//for (var str in input) {
//    solve(input[str]);
//}