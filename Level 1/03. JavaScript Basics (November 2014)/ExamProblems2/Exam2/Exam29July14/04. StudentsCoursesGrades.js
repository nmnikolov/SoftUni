function solve(arg) {
    var courses = {};
    var output = {};

    for (var i = 0; i < arg.length; i++) {
        var row = arg[i].split('|');
        var course = row[1].trim();
        var name = row[0].trim();     
        var grade = Number(row[2]);
        var visits = Number(row[3]);

        if (courses.hasOwnProperty(course)) {           
            courses[course].grades += grade;
            courses[course].visits += visits;
            courses[course].count++;

            if (courses[course].students.indexOf(name) == -1) {
                courses[course].students.push(name);
                courses[course].students.sort();
            }
        } else {
            courses[course] = {
                'grades': grade,
                'visits': visits,
                'count': 1,
                'students': [name]
            };
        }
    }

    var keys = Object.keys(courses).sort();

    for (var i = 0; i < keys.length; i++) {
        var avgGrade = (courses[keys[i]].grades / courses[keys[i]].count).toFixed(2);
        var avgVisits = (courses[keys[i]].visits / courses[keys[i]].count).toFixed(2);

        output[keys[i]] = {
            'avgGrade': Number(avgGrade),
            'avgVisits': Number(avgVisits),
            'students': courses[keys[i]].students
        };
    }

    console.log(JSON.stringify(output));
}

var input = [
    [
     'Peter Nikolov | PHP  | 5.50 | 8',
     'Maria Ivanova | Java | 5.83 | 7',
     'Ivan Petrov   | PHP  | 3.00 | 2',
     'Ivan Petrov   | C#   | 3.00 | 2',
     'Peter Nikolov | C#   | 5.50 | 8',
     'Maria Ivanova | C#   | 5.83 | 7',
     'Ivan Petrov   | C#   | 4.12 | 5',
     'Ivan Petrov   | PHP  | 3.10 | 2',
     'Peter Nikolov | Java | 6.00 | 9'
    ]
];

for (var str in input) {
    solve(input[str]);
}