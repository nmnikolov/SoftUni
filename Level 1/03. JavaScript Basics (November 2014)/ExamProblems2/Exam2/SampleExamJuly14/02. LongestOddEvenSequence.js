function solve(arg) {
    var numbers = arg[0].split(/[^0-9\-]+/g).filter(function (v) { return v !== '' });
    var max = 0;
    var count = 0;
    var isOdd = numbers[0] % 2 != 0;
    
    for (var i = 0; i < numbers.length; i++) {
        var current = numbers[i] % 2 != 0;

        if (isOdd === current || numbers[i] == 0) {
            count++;
        } else {
            count = 1;
            isOdd = current;
        }

        isOdd = !isOdd;
        max = Math.max(max, count);
    }

    console.log(max);
}

//var input = [
//    ['(3) (22) (-18) (55) (44) (3) (21)'],
//    ['(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)'],
//    ['  ( 2 )  ( 33 ) (1) (4)   (  -1  )'],
//    ['(102)(103)(0)(105)  (107)(1)'],
//    ['(2) (2) (2) (2) (2)']
//];

//for (var str in input) {
//    solve(input[str]);
//}