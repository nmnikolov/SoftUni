function findYoungestPerson(persons) {
    var youngest;
    var youngestAge = Number.MAX_VALUE;
    
    for (var person in persons) {
        if (persons[person].age < youngestAge) {
            youngest = persons[person].firstname + ' ' + persons[person].lastname;
            youngestAge = persons[person].age;
        }
    }

    return youngest;
}

var persons = [
  { firstname: 'George', lastname: 'Kolev', age: 42 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'Baba', lastname: 'Ginka', age: 40 }];

console.log('The youngest person is %s', findYoungestPerson(persons));