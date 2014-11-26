function hideOddRows() {
    var rows = document.getElementsByTagName('tr');

    for (var i = 0; i < rows.length; i += 2) {
            rows[i].style.display = 'none';
    }
}

document.getElementById('btnHideOddRows').addEventListener('click', hideOddRows);