function solve(arg) {
    var sortType = arg[0].split('^')[0];
    var users = {
        'students': [],
        'trainers': []
    }

    for (var i = 1; i < arg.length; i++) {
        var row = JSON.parse(arg[i]);
        if (row.role === 'student') {
            var grades = 0;
            for (var j = 0; j < row.grades.length; j++) {
                grades += Number(row.grades[j]);
            }

            users.students.push({
                'id': row.id,
                'firstname': row.firstname,
                'lastname': row.lastname,
                'averageGrade': (grades / row.grades.length).toFixed(2),
                'certificate': row.certificate,
                'level': row.level
            });
        } else {
            users.trainers.push({
                'id': row.id,
                'firstname': row.firstname,
                'lastname': row.lastname,
                'courses': row.courses,
                'lecturesPerDay': row.lecturesPerDay
            });
        }             
    }

    switch(sortType) {
        case 'name': sortByName(); break;
        default: sortByLevel(); break;
    }
    sortTrainers();
    deleteLevel();
    console.log(JSON.stringify(users));

    function sortByName() {
        users.students.sort(function (a, b) {
            if (a.firstname < b.firstname) {
                return -1;
            }            
            if (a.firstname > b.firstname) {
                return 1;
            }
            if (a.lastname < b.lastname) {
                return -1;
            }
            if (a.lastname > b.lastname) {
                return 1;
            }
            return 0;
        });
    }

    function sortByLevel() {
        users.students.sort(function (a, b) {
            if (a.level !== b.level) {
                return a.level - b.level;
            }
            return a.id - b.id;
        });
    }

    function sortTrainers() {
        users.trainers.sort(function (a, b) {
            if (a.courses.length !== b.courses.length) {
                return a.courses.length - b.courses.length;
            }

            return a.lecturesPerDay - b.lecturesPerDay;
        });
    }

    function deleteLevel() {
        for (var i = 0; i < users.students.length; i++) {
            delete users.students[i].level;
        }
    }
}

//var input = [
//    ['name^courses',
//     '{"id":0,"firstname":"Angel","lastname":"Ivanov","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//     '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//     '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//     '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//     '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}']
//];

//for (var str in input) {
//    solve(input[str]);
//}