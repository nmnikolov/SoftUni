function queryMess(arr) {
    var regex = /[^?&=]+=[^?&=]+/g;

    for (var i = 0; i < arr.length; i++) {
        var output = {};
        var outputStr = '';

        while (match = regex.exec(arr[i])) {
            var row = match[0].split('=');
            var left = row[0].replace(/(%20|[+])+/g, ' ').trim();
            var right = row[1].replace(/(%20|[+])+/g, ' ').trim();

            if (output.hasOwnProperty(left)) {
                output[left].push(right);
            } else {
                output[left] = [right];
            }
        }

        for (var key in output) {
            outputStr += key + '=[' + output[key].join(', ') + ']';
        }

        console.log(outputStr);
    }
}

//var input = [
//    ['login=student&password=student'],
//    ['field=value1&field=value2&field=value3', 'http://example.com/over/there?name=ferret'],
//    ['foo=%20foo&value=+val&foo+=5+%20+203',
//     'foo=poo%20&value=valley&dog=wow+',
//     'url=https://softuni.bg/trainings/coursesinstances/details/1070',
//     'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php']
//];

//for (var arr in input) {
//    queryMess(input[arr])
//}