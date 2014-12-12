var aTags = document.getElementsByClassName("seminar");

for(var i = 0; i <aTags.length ; i++){
    aTags[i].addEventListener('mouseover', mouseOver, false);
    aTags[i].addEventListener('mouseout', mouseOut, false);
}

function mouseOver(e) {
    var el = this.getElementsByTagName('div')[0];
    el.style.marginLeft= (e.clientX || e.pageX) - 10 + 'px';
    el.className = 'show';

};

function mouseOut(e) {
    var el = this.getElementsByTagName('div')[0];
    el.className = 'hide';
};