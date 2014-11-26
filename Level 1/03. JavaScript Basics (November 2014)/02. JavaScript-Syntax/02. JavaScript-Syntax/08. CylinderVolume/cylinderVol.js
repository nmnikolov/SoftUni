function calcCylinderVol(radius, height) {
    var cylinderVolume = Math.PI * Math.pow(radius, 2) * height;
    return cylinderVolume.toFixed(3);
}

console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));