function calcExpression(expression) {
    if (expression != '') {
        expression = expression.replace(/[^0-9\-+*/()%|&^><!~]/g, '');
        var result = eval(expression);
        document.getElementById('result').innerHTML = result;       
    } else {
        document.getElementById('result').innerHTML = 'The expression is empty.';
    }

    document.getElementById('expression').focus();   
}

function clearResults() {
    document.getElementById('expression').value = "";
    document.getElementById('result').innerHTML = "";
    document.getElementById('expression').focus();
};