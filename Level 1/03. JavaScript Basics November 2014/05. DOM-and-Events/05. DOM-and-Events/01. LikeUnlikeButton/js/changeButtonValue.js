function changeValue() {
    this.innerHTML = this.innerHTML === 'Like' ? 'Unlike' : 'Like';
}

document.getElementById('button').addEventListener('click', changeValue);