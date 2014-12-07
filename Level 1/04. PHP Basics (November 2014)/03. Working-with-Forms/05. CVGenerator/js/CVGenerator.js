var variables = {prLang: 0, lang: 0};

function addProgLang() {
    variables.prLang++;

    var inputDiv = document.getElementById('pr-lang-hidden').cloneNode(true);
    inputDiv.id = 'pr-lang' + variables.prLang;
    inputDiv.className =  'show';

    var progLang = inputDiv.getElementsByTagName('input')[0];
    progLang.value = '';
    progLang.name = 'pr-lang[]';
    progLang.required = 'required';

    var skills = inputDiv.getElementsByTagName('select')[0];
    skills.name = 'pr-skill[]';
    skills.required = 'required';

    var removeButton =  inputDiv.getElementsByTagName('input')[1];
    removeButton.setAttribute("onclick","removeProgLang(" + ('\'pr-lang' + variables.prLang + '\')'));

    document.getElementById('prog-lang').appendChild(inputDiv);
}

function addLang() {
    variables.lang++;
    var inputDiv = document.getElementById('lang-hidden').cloneNode(true);
    inputDiv.id = 'lang' + variables.lang;
    inputDiv.className =  'show';

    var lang = inputDiv.getElementsByTagName('input')[0];
    lang.name = 'lang[]';
    lang.required = 'required';

    var langLevels = inputDiv.getElementsByTagName('select');
    langLevels[0].name = 'comprehension[]';
    langLevels[0].required = 'required';
    langLevels[1].name = 'reading[]';
    langLevels[1].required = 'required';
    langLevels[2].name = 'writing[]';
    langLevels[2].required = 'required';

    var removeButton =  inputDiv.getElementsByTagName('input')[1];
    removeButton.setAttribute("onclick","removeLang(" + ('\'lang' + variables.lang + '\')'));

    document.getElementById('lang').appendChild(inputDiv);
}

function removeProgLang(id) {
    var inputDiv = document.getElementById(id);
    document.getElementById('prog-lang').removeChild(inputDiv);
}

function removeLang(id) {
    var inputDiv = document.getElementById(id);
    document.getElementById('lang').removeChild(inputDiv);
}