function solve(arr) {
	var words = arr[0].split(' ');
	var output = '';
	var length;

	while (words.length != 0) {
		for (var i = 0; i < words.length; i++) {
			length = words[i].length;
			var lastChar = words[i].charAt(length - 1);
			output += lastChar;
			words[i] = words[i].substring(0, length - 1)
		}

		words = words.filter(function(v){return v!==''});		
	}

	length = output.length;

	for (var i = 0; i < length ; i++) {
		var toMove = output[i];
		var movePosition = (i + output.toUpperCase().charCodeAt(i) - 64) % output.length;
		output  = output.substring(0, i) + '' + output.substring(i + 1, output.length);

		if (movePosition == 0) {
			output = toMove + output;
		} else if (movePosition == length - 1) {
			output = output + toMove;
		} else {
			output = output.substring(0, movePosition) + toMove + output.substring(movePosition, output.length);
		}
	}

	return output;
}

//var input = [
//	['Fun exam right'],
//	['Hi exam']
//];

//for (var arr in input) {
//	console.log(solve(input[arr]));
//}