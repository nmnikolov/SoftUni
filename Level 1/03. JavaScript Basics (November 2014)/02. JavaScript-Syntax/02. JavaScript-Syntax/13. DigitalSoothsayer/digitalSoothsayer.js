function soothsayer(value) {
    var years = value[0][parseInt(Math.random() * value[0].length)];
    var programmingLanguage = value[1][parseInt(Math.random() * value[1].length)];
    var city = value[2][parseInt(Math.random() * value[2].length)];
    var car = value[3][parseInt(Math.random() * value[3].length)];

    var output = 'You will work ' + years + ' years on ' + programmingLanguage + '. You will live in ' + city + ' and drive ' + car + '.';

    console.log(output);
}

var inputArray = [[3, 5, 2, 7, 9],
                  ['Java', 'Python', 'C#', 'JavaScript', 'Ruby'],
                  ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'],
                  ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']];

soothsayer(inputArray);