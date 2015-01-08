function solve(arg) {
    var str = arg.join('\n');
    var pattern = /<a\s[^>]*href\s*=\s*(?:(?:\"([^\">]+)\")|(?:\'([^\'>]+)\')|([^>\s]+))*[^>]*>/g;
    var match;

    while (match = pattern.exec(str)) {
        if (match[1] != undefined) {
            console.log(match[1]);
        } else if (match[2] != undefined) {
            console.log(match[2]);
        } else {
            console.log(match[3]);
        }
    }
}

//var input = [[
//'<!DOCTYPE html>',
//'<html>',
//'<head>',
//'  <title>Hyperlinks</title>',
//'  <link href="theme.css" rel="stylesheet" />',
//'</head>',
//'<body>',
//'<ul><li><a   href="/"  id="home">Home</a></li><li><a',
//' class="selected" href=/courses>Courses</a>',
//'</li><li><a href = ',
//'\'/forum\' >Forum</a></li><li><a class="href"',
//'onclick="go()" href= "#">Forum</a></li>',
//'<li><a id="js" href =',
//'"javascript:alert(\'hi yo\')" class="new">click</a></li>',
//'<li><a id=\'nakov\' href =',
//'    http:\/\/www.nakov.com class=\'new\'>nak</a></li></ul>',
//'<a href="#empty"></a>',
//'<a id="href">href=\'fake\'<img src=\'http:\/\/abv.bg\/i.gif\' ',
//    'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
//'<!-- This code is commented:',
//'    <a href="#commented">commentex hyperlink</a> -->',
//'  </body>']];

//for (var str in input) {
//    solve(input[str]);
//}