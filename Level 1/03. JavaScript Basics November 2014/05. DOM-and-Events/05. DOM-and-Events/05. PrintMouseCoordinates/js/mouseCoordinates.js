function printCoordinate(e) {
    var x = e.clientX || e.pageX;
    var y = e.clientY || e.pageY;

    document.getElementById('coordinates').value += 'X:' + x + ';   Y:' + y + '   Time: ' + new Date() + '\n';
}

document.addEventListener('mousemove', printCoordinate, false);