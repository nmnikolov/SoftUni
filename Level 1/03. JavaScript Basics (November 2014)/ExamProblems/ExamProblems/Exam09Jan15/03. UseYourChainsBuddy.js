function solve(arg) {
    var pattern = /<p>(.*?)<\/p>/g;
    var output = '';

    while (match = pattern.exec(arg)) {
        var str = match[1].replace(/[^a-z\d]+/g, ' ');
        for (var c = 0; c < str.length; c++) {
            var char = str[c];
            if (isLetter(str[c])) {
                var charCode = str.charCodeAt(c);
                charCode = charCode < 110 ? charCode += 13 : charCode -= 13;
                char = String.fromCharCode(charCode);
            }
            output += char;
        }
    }

    console.log(output);

    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/g);
    }
}

//var input = [
//    ['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>'],
//    ['<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>']
//];

//for (var str in input) {
//    solve(input[str]);
//}