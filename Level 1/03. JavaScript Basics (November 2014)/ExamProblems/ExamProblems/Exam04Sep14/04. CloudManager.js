function solve(arr) {
	var cloud = {};

	for (var i = 0; i < arr.length; i++) {
		var row = arr[i].split(' ');
		var extension = row[1];
		var file = row[0];	
		var memory = Number(row[2].substring(0, row[2].length - 2));

		if (cloud.hasOwnProperty(extension)) {
			cloud[extension].files.push(file);
			cloud[extension].memory += memory;

		} else {
			cloud[extension] = {files: [file], memory: memory}
		}
	}

	var files = Object.keys(cloud);
	files.sort();
	var cloudSorted = {};

	for (var file in files) {
		for (var key in cloud) {
			if (files[file] == key) {
				cloudSorted[key] = cloud[key];
				cloudSorted[key].files.sort();
				cloudSorted[key].memory = cloudSorted[key].memory.toFixed(2);
			}
		}
	}

	console.log(JSON.stringify(cloudSorted));
}

//var input = [
//    ['sentinel .exe 15MB',
//	 'zoomIt .msi 3MB',
//	 'skype .exe 45MB',
//	 'trojanStopper .bat 23MB',
//	 'kindleInstaller .exe 120MB',
//	 'setup .msi 33.4MB',
//	 'winBlock .bat 1MB']
//];

//for (var arr in input) {
//	solve(input[arr])
//}