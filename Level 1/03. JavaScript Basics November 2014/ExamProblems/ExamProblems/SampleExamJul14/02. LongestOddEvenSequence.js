function solve(arr) {
	var numbers = arr[0].split(/[^0-9-]+/g).filter(function (v) { return v !== '' });
	var maxCount = 0;	
	var count = 0;
	var isOdd = numbers[0] % 2 != 0 ;
	
	for (var i = 0; i < numbers.length; i++) {
		var currentIsOdd = numbers[i] % 2 != 0;

		if (isOdd === currentIsOdd || numbers[i] == 0) {
			count++;
		} else {			
			count = 1;
			isOdd = numbers[i] % 2 != 0;
		}

		isOdd = !isOdd;
		maxCount = Math.max(maxCount, count);		
	}

	return maxCount;
}

//var input = [
//    ['(3) (22) (-18) (55) (44) (3) (21)'],
//    ['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)'],
//    ['  ( 2 )  ( 33 ) (1) (4)   (  -1  ) '],
//    ['(102)(103)(0)(105)  (107)(1)'],
//    ['(2) (2) (2) (2) (2)']
//];

//for (var arr in input) {
//    console.log(solve(input[arr]));
//}