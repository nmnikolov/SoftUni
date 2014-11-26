function displayProperties() {
    var propertiesArray = [];

    for (var properties in document) {
        propertiesArray.push(properties);        
    }

    propertiesArray.sort(function (a, b) {
        return a.toLowerCase().localeCompare(b.toLowerCase());
    });

    var output = propertiesArray.join('\n');
    console.log(output);

    for (var i = 0; i < propertiesArray.length; i++) {
        var li = document.createElement('li');
        li.innerHTML = propertiesArray[i];
        document.getElementById('result').appendChild(li);
    }
}

displayProperties();