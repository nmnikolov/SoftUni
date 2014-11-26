function variablesTypes(value) {
    var name = "\"My name: " + value[0] + " //type is " + typeof (value[0]);
    var age = "\nMy age: " + value[1] + " //type is " + typeof (value[1]);
    var isMale = "\nI am male: " + value[2] + " //type is " + typeof (value[2]);
    var foods = "\nMy favorite foods are: " + value[3] + " //type is " + typeof (value[3]) + "\"";

    return name + age + isMale + foods;
}

console.log(variablesTypes(['Pesho', 22, true, ['fries', 'banana', 'cake']]));