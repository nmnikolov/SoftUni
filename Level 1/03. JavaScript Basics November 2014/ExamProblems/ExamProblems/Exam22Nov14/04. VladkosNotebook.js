function vladkoNotebook(arr) {
    var notebook = {};
    var output = {};

    for (var i = 0; i < arr.length; i++) {
        var sheet = arr[i].split('|');
        var color = sheet[0];
        var second = sheet[1];
        var third = sheet[2];

        if (notebook.hasOwnProperty(color)) {
            if (second == 'win' || second == 'loss') {
                notebook[color][second]++;
                notebook[color].opponents.push(third);
            } else if (second == 'name') {
                notebook[color].name = third;
            } else {
                notebook[color].age = third;
            }
        } else {
            if (second == 'win') {
                notebook[color] = { win: 1, loss: 0, opponents: [third] }
            } else if (second == 'loss') {
                notebook[color] = { win: 0, loss: 1, opponents: [third] }
            } else if (second == 'name') {
                notebook[color] = { name: third, win: 0, loss: 0, opponents: [] };
            } else {
                notebook[color] = { age: third, win: 0, loss: 0, opponents: [] };
            }
        }
    }

    var colors = Object.keys(notebook).sort();

    for (color in colors) {
        var key = colors[color];
        if (notebook[key].name && notebook[key].age) {
            var rank = (notebook[key].win + 1) / (notebook[key].loss + 1);
            output[key] = {
                age: notebook[key].age,
                name: notebook[key].name,
                opponents: notebook[key].opponents.sort(),
                rank: rank.toFixed(2)
            }
        }
    }

    console.log(JSON.stringify(output));
}

//var input = [
//    ['purple|age|99',
//    'red|age|44',
//    'blue|win|pesho',
//    'blue|win|mariya',
//    'purple|loss|Kiko',
//    'purple|loss|Kiko',
//    'purple|loss|Kiko',
//    'purple|loss|Yana',
//    'purple|loss|Yana',
//    'purple|loss|Manov',
//    'purple|loss|Manov',
//    'red|name|gosho',
//    'blue|win|Vladko',
//    'purple|loss|Yana',
//    'purple|name|VladoKaramfilov',
//    'blue|age|21',
//    'blue|loss|Pesho']];

//for (var arr in input) {
//    vladkoNotebook(input[arr]);
//}