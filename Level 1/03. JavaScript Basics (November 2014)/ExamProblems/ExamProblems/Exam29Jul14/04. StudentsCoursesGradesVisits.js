function solve(arr) {
    var output = {};
    var count = {}
    
    for (var i = 0; i < arr.length; i++) {
        var scoreRow = arr[i].split('|').filter(Boolean);
        var student = scoreRow[0].trim();
        var course = scoreRow[1].trim();
        var grade = Number(scoreRow[2].trim());
        var visits = Number(scoreRow[3].trim());

        if (output.hasOwnProperty(course)) {
            output[course].avgGrade += grade;
            output[course].avgVisits += visits;

            if (output[course]['students'].indexOf(student) === -1) {
                output[course]['students'].push(student);
                output[course]['students'].sort();
            }                    
        } else {
            output[course] = { avgGrade: grade, avgVisits: visits, students: [student] };
            count[course] = 0;
        }
        count[course]++;
    }

    var sorted = {};
    var cources = Object.keys(output);
    cources.sort();

    for (var cource in cources) {
        for (var key in output) {
            if (key === cources[cource]) {
                sorted[key] = output[key];
                sorted[key].avgGrade = (output[key].avgGrade / count[key]).toFixed(2);
                sorted[key].avgGrade = Number(sorted[key].avgGrade);
                sorted[key].avgVisits = (output[key].avgVisits / count[key]).toFixed(2);
                sorted[key].avgVisits = Number(sorted[key].avgVisits);
            }
        }
    }

    console.log(JSON.stringify(sorted));
}

//var input = [
//	['Peter Nikolov | PHP  | 5.50 | 8',
//     'Maria Ivanova | Java | 5.83 | 7',
//     'Ivan Petrov   | PHP  | 3.00 | 2',
//     'Ivan Petrov   | C#   | 3.00 | 2',
//     'Peter Nikolov | C#   | 5.50 | 8',
//     'Maria Ivanova | C#   | 5.83 | 7',
//     'Ivan Petrov   | C#   | 4.12 | 5',
//     'Ivan Petrov   | PHP  | 3.10 | 2',
//     'Peter Nikolov | Java | 6.00 | 9']
//];

//for (var arr in input) {
//	solve(input[arr]);
//}