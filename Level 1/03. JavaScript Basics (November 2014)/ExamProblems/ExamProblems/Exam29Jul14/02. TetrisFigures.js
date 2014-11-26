function solve(arr) {
    var output = { I: 0, L: 0, J: 0, O: 0, Z: 0, S: 0, T: 0 };
    var c = 'o';

	for (var row = 0; row < arr.length - 1; row++) {
	    for (var col = 0; col < arr[row].length; col++) {

            // I
	        if (arr[row][col] === c && row + 3 < arr.length) {
	            if (arr[row + 1][col] == c && arr[row + 2][col] == c && arr[row + 3][col] == c) {
	                output.I++;
	            }
	        }

            // L
	        if (arr[row][col] === c && row + 2 < arr.length && col + 1 < arr[row].length) {
	            if (arr[row + 1][col] == c && arr[row + 2][col] == c && arr[row + 2][col + 1] == c) {
	                output.L++;
	            }
	        }

	        // J
	        if (arr[row][col] === c && row + 2 < arr.length && col - 1 >= 0) {
	            if (arr[row + 1][col] == c && arr[row + 2][col] == c && arr[row + 2][col - 1] == c) {
	                output.J++;
	            }
	        }

	        // O
	        if (arr[row][col] === c && col + 1 < arr[row].length) {
	            if (arr[row][col + 1] == c && arr[row + 1][col] == c && arr[row + 1][col + 1] == c) {
	                output.O++;
	            }
	        }

	        // Z
	        if (arr[row][col] === c && col + 2 < arr[row].length) {
	            if (arr[row][col + 1] == c && arr[row + 1][col + 1] == c && arr[row + 1][col + 2] == c) {
	                output.Z++;
	            }
	        }

	        // S
	        if (arr[row][col] === c && col - 2 >= 0) {
	            if (arr[row][col - 1] == c && arr[row + 1][col - 1] == c && arr[row + 1][col - 2] == c) {
	                output.S++;
	            }
	        }

	        // T
	        if (arr[row][col] === c && col + 2 < arr[row].length) {
	            if (arr[row][col + 1] == c && arr[row][col + 2] == c && arr[row + 1][col + 1] == c) {
	                output.T++;
	            }
	        }
	    }
	}

	console.log(JSON.stringify(output));
}

//var input = [
//	['--o--o-',
//     '--oo-oo',
//     'ooo-oo-',
//     '-ooooo-',
//     '---oo--'],
//    ['-oo',
//     'ooo',
//     'ooo']
//];

//for (var arr in input) {
//    solve(input[arr])
//}