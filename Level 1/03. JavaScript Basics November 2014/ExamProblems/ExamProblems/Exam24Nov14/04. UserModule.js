function userModule(arr) {
    var users = {students: [], trainers: []};
    var sortCriteria = arr[0].split('^');

    for (var i = 1; i < arr.length; i++) {
        var row = JSON.parse(arr[i]);
        if (row.role == 'student') {
            users.students.push(row);
        } else {
            users.trainers.push(row);
        }
    }

    usersSort();
    deleteStudentsInfo()
    deleteTrainersInfo();
    console.log(JSON.stringify(users));
  
    function usersSort() {
        if (sortCriteria[0] === 'level') {
            sortbyLevel();
        } else {
            sortByName();
        }
        sortByCources();
    }

    function sortbyLevel() {
        users.students.sort(function (a, b) {
            if (a.level !== b.level) {
                return Number(a.level) - Number(b.level);
            } 
            return a.id - b.id;
        });
    }

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

    function sortByCources() {
        users.trainers.sort(function (a, b) {
            if (a.courses.length !== b.courses.length) {
                return a.courses.length - b.courses.length;
            } else {
                return a.lecturesPerDay - b.lecturesPerDay;
            }
        });
    }

    function deleteStudentsInfo() {
        for (var i = 0; i < users.students.length; i++) {
            var sum = 0;
            for (var grade in users.students[i].grades) {
                sum += Number(users.students[i].grades[grade]);
            }
            users.students[i].averageGrade = (sum / users.students[i].grades.length).toFixed(2);
            var hasCertificate = users.students[i].certificate;
            delete users.students[i].town;
            delete users.students[i].role;
            delete users.students[i].level;
            delete users.students[i].grades;
            delete users.students[i].certificate;
            users.students[i].certificate = hasCertificate;
        }
    }

    function deleteTrainersInfo() {
        for (var i = 0; i < users.trainers.length; i++) {
            delete users.trainers[i].town;
            delete users.trainers[i].role;
        }
    }
}

//var input = [
//    ['name^courses',
//     '{"id":0,"firstname":"Angel","lastname":"Ivano","town":"Plovdiv","role":"student","grades":["5.89"],"level":2,"certificate":false}',
//     '{"id":1,"firstname":"Mitko","lastname":"Nakova","town":"Dimitrovgrad","role":"trainer","courses":["PHP","Unity Basics"],"lecturesPerDay":6}',
//     '{"id":2,"firstname":"Bobi","lastname":"Georgiev","town":"Varna","role":"student","grades":["5.59","3.50","4.54","5.05","3.45"],"level":4,"certificate":false}',
//     '{"id":3,"firstname":"Ivan","lastname":"Ivanova","town":"Vidin","role":"trainer","courses":["JS","Java","JS OOP","Database","OOP","C#"],"lecturesPerDay":7}',
//     '{"id":4,"firstname":"Mitko","lastname":"Petrova","town":"Sofia","role":"trainer","courses":["Database","JS Apps","Java"],"lecturesPerDay":2}']
//];

//for (var arr in input) {
//    userModule(input[arr]);
//}