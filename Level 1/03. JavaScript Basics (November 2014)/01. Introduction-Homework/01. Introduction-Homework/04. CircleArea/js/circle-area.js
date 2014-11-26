function calcCircleArea(r) {
    var output;
    
    if (isNaN(r) || r == "") {
        output = "Must enter number";
    }
    else {
        var area = r * r * Math.PI;
        output = "r = " + r + "; area = " + area;
    }

    printResult(output);
};

function printResult(output) {
    var p = document.createElement('p');
    var inputField = document.getElementById('input');

    p.innerHTML = output;
    document.getElementById('results').appendChild(p);

    inputField.value = "";
    inputField.focus();
};

function clearResults() {
    var list = document.getElementById("results");

    while (list.firstChild) {
        list.removeChild(list.childNodes[0]);
    }

    document.getElementById('input').value = "";
    document.getElementById('input').focus();
};

function KeyPress(e) {
    var evtobj = window.event ? event : e
    if (evtobj.keyCode == 46 && evtobj.ctrlKey) {
        clearResults();
    }
}

document.onkeydown = KeyPress;