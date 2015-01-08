function solve(arg) {
    var notebook = {};
    var notebookSorted = {};

    for (var i = 0; i < arg.length; i++) {
        var row = arg[i].split('|');
        var color = row[0];
        var option = row[1];
        var value = row[2];
        process(color, option, value);
    }

    var colors = Object.keys(notebook).sort();

    for (var i in colors) {
        var color = colors[i];
        if (notebook[color].age && notebook[color].name) {
            var rank = (notebook[color].win + 1) / (notebook[color].loss + 1);
            notebookSorted[color] = {
                'age': notebook[color].age,
                'name': notebook[color].name,
                'opponents': notebook[color].opponents.sort(),
                'rank': rank.toFixed(2)
            };
        }
    }

    console.log(JSON.stringify(notebookSorted));

    function process(color, option, value) {
        if (!notebook.hasOwnProperty(color)) {
            notebook[color] = { 'win': 0, 'loss': 0, 'opponents': [] };
        }

        switch (option) {
            case 'win': case 'loss':
                notebook[color][option]++;
                notebook[color].opponents.push(value);
                break;
            case 'name': notebook[color].name = value; break;
            default: notebook[color].age = value; break;
        }
    } 
}

//var input = [
//    ['purple|age|99',
//     'red|age|44',
//     'blue|win|pesho',
//     'blue|win|mariya',
//     'purple|loss|Kiko',
//     'purple|loss|Kiko',
//     'purple|loss|Kiko',
//     'purple|loss|Yana',
//     'purple|loss|Yana',
//     'purple|loss|Manov',
//     'purple|loss|Manov',
//     'red|name|gosho',
//     'blue|win|Vladko',
//     'purple|loss|Yana',
//     'purple|name|VladoKaramfilov',
//     'blue|age|21',
//     'blue|loss|Pesho']
//];

//for (var str in input) {
//    solve(input[str]);
//}