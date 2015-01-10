function solve(arg) {
	for (var i = 0; i < arg.length; i++) {
		var row = arg[i].split(' ');
		var model = row[0];
		var fuelType = row[1];
		var route = row[2];
		var luggage = Number(row[3]);

		var fuelConsumption;
		var length = route === '1' ? 110 : 95;
		var snow = route === '1' ? 10 : 30;

		switch (fuelType) {
			case 'petrol': fuelConsumption = 10; break;
			case 'gas': fuelConsumption = 12; break;
			case 'diesel': fuelConsumption = 8; break;
		}

		fuelConsumption += luggage * 0.01;
		totalConsumption = snow * fuelConsumption * 0.3 / 100 + length * fuelConsumption / 100;

		console.log('%s %s %s %s', model, fuelType, route, Math.round(totalConsumption));
	}
}

//var input = [
//    ['BMW petrol 1 320.5',
//     'Golf petrol 2 150.75',
//     'Lada gas 1 202',
//     'Mercedes diesel 2 312.54']
//];

//for (var str in input) {
//    solve(input[str]);
//}