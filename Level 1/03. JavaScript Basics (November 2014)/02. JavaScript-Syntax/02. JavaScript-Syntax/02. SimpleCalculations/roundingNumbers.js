function roundNumber(number) {
    var floor = Math.floor(number);
    var round = Math.round(number);
    console.log(number + " floored = " + floor);
    console.log(number + " rounded = " + round + "\n*****************");

};

roundNumber(22.7);
roundNumber(12.3);
roundNumber(58.7);