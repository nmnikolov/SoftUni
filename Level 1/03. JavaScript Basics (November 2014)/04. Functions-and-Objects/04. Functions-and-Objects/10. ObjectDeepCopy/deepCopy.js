function clone(obj) {    
    return JSON.parse(JSON.stringify(obj));
}

function compareObjects(obj, objCopy) {
    return obj === objCopy;
}

var a = { name: 'Pesho', age: 21 }

var b1 = clone(a); // a deep copy 
var b2 = a; // not a deep copy

console.log('a == b --> %s', compareObjects(a, b1));
console.log('a == b --> %s', compareObjects(a, b2));