function ewoksFans(dates) {  
    var minDate = new Date('01-01-1900');
    var maxDate = new Date('01-01-2015');
    var checkDate = new Date('05-25-1973');
    var fan = undefined;
    var hater = undefined;

    for (var i = 0; i < dates.length; i++) {
        var dateRow = dates[i].split('.');
        var dateString = dateRow[1] + '-' + dateRow[0] + '-' + dateRow[2]
        var date = new Date(dateString);

        if (date > minDate && date <= checkDate) {
            if (hater === undefined) {
                hater = date;
            } else if (hater > date) {
                hater = date;
            }
        }

        if (date > checkDate && date <= maxDate) {
            if (fan === undefined) {
                fan = date;
            } else if (fan < date) {
                fan = date;
            }
        }
    }

    if (fan !== undefined || hater !== undefined) {
        if (fan != undefined) {
            console.log('The biggest fan of ewoks was born on ' + fan.toDateString());
        }
        if (hater != undefined) {
            console.log('The biggest hater of ewoks was born on ' + hater.toDateString());
        }
    } else {
        console.log('No result');
    }
}

//var input = [
//    ['22.03.2014', '17.05.1933', '10.10.1954'],
//    ['22.03.2000'],
//    ['22.03.1700', '01.07.2020']];

//for (var arr in input) {
//    ewoksFans(input[arr]);
//    console.log('***************************************');
//}