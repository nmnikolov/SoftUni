function solve(arg) {
    var cloud = {};
    var cloudSorted = {};

    for (var i = 0; i < arg.length; i++) {
        var row = arg[i].split(' ').filter(function (v) { return v !== '' });
        var file = row[0];
        var extension = row[1];
        var memory = Number(row[2].substring(0, row[2].length - 2));
        
        if (cloud.hasOwnProperty(extension)) {
            memory = Number(cloud[extension].memory) + memory;
            cloud[extension].memory = memory.toFixed(2);
            cloud[extension].files.push(file);
            cloud[extension].files.sort();
        } else {
            cloud[extension] = {
                'files': [file],
                'memory': memory.toFixed(2)
            };
        }
    }

    var extensions = Object.keys(cloud).sort();

    for (var i in extensions) {
        cloudSorted[extensions[i]] = cloud[extensions[i]];
    }

    console.log(JSON.stringify(cloudSorted));
}

//var input = [
//    ['sentinel .exe 15MB',
//     'zoomIt .msi 3MB',
//     'skype .exe 45MB',
//     'trojanStopper .bat 23MB',
//     'kindleInstaller .exe 120MB',
//     'setup .msi 33.4MB',
//     'winBlock .bat 1MB']
//];

//for (var str in input) {
//    solve(input[str]);
//}