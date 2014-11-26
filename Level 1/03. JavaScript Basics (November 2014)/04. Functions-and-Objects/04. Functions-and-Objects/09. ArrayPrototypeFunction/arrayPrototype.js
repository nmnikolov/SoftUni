Array.prototype.removeItem = function () {
    var toRemove;
    var length = arguments.length;
    var index;

    while (length) {
        toRemove = arguments[--length];
        while ((index = this.indexOf(toRemove)) !== -1) {
            this.splice(index, 1);
        }       
    }

    return this;
};

var input = [
    [1, [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1']],
    ['bye', ['hi', 'bye', 'hello']]
];

for (var i = 0; i < input.length; i++) {
    console.log(input[i][1].removeItem(input[i][0]));
}