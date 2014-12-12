var aTags = document.getElementsByClassName("seminar");

for(var i = 0; i <aTags.length ; i++){
    aTags[i].addEventListener('mousemove', mouseMove, false);
    aTags[i].addEventListener('mouseover', mouseOver, false);
    aTags[i].addEventListener('mouseout', mouseOut, false);
}

function mouseMove(e) {
    var div = this.getElementsByTagName('div')[0];
    div.style.left= (e.clientX || e.pageX) + 15 + 'px';
    div.style.top= (e.clientY || e.pageY) + 10 + 'px';
};

function mouseOver(e) {
    this.getElementsByTagName('div')[0].className = 'show';

};

function mouseOut(e) {
    this.getElementsByTagName('div')[0].className = 'hide';
};