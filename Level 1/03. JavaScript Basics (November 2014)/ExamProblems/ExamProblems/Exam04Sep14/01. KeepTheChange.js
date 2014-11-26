function solve(arr) {
	var bill = Number(arr[0]);
	var mod = arr[1];
	var tip;

	switch (mod) {
		case 'happy': tip = bill * 0.1; break;
		case 'married': tip = bill * 0.0005; break;
		case 'drunk': drunk(); break;
		default: tip = bill * 0.05; break;
	}
	
	function drunk() {
		tip = bill * 0.15;
		tip = Math.pow(tip, tip.toString().charAt(0))
	}
	
	console.log(tip.toFixed(2));
}

//var input = [
//	['120.44', 'happy'],
//    ['1230.83', 'drunk'],
//	['716.00', 'bored'],
//	['9999.13', 'drunk']
//];

//for (var arr in input) {
//    solve(input[arr])
//}