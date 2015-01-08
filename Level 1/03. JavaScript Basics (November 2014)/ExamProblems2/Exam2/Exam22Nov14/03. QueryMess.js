function solve(arg) {
    var pattern = /([^?&]+)=([^&?]+)/g;
    
    for (var i = 0; i < arg.length; i++) {
        var output = {};
        var str = '';
        while (match = pattern.exec(arg[i])) {
            var key = match[1].replace(/(%20|[+])+/g, ' ').trim();
            var value = match[2].replace(/(%20|[+])+/g, ' ').trim();

            if (output.hasOwnProperty(key)) {
                output[key].push(value);
            } else {
                output[key] = [value];
            }          
        }

        for (var key in output) {
            str += key + '=[' + output[key].join(', ') + ']';
        }

        console.log(str);        
    }  
}

//var input = [
//    ['login=student&password=student'],
//    /////////////////////////////////////////////////////////////////////////
//    ['field=value1&field=value2&field=value3',
//     'http://example.com/over/there?name=ferret'],
//     /////////////////////////////////////////////////////////////////////////
//    ['foo=%20foo&value=+val&foo+=5+%20+203',
//     'foo=poo%20&value=valley&dog=wow+',
//     'url=https://softuni.bg/trainings/coursesinstances/details/1070',
//     'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php']
//];

//for (var str in input) {
//    solve(input[str]);
//}