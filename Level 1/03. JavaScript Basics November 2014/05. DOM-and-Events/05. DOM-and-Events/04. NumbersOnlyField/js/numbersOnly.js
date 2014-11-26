function checkInput() {
    var inputValue = input.value;
    var pattern = /\D/g;
    if (pattern.test(inputValue)) {
        input.style.background = '#ff0000';
        input.value = inputValue.replace(/[^0-9]+/g, '');
        setTimeout(function () { input.style.background = '#fff' }, 250)
    }
}

var input = document.getElementById('input');
input.addEventListener('input', checkInput);