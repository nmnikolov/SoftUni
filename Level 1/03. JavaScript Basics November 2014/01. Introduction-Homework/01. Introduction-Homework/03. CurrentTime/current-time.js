var currTime = new Date();
var hours = currTime.getHours();
var minutes = currTime.getMinutes() < 10 ? "0" + currTime.getMinutes() : currTime.getMinutes(); 
console.log(hours + ":" + minutes);