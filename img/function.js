// var arr = [
//     'Dang Dinh Duy',
//     'Nguyen Thi Ngoc Mai ',
//     'Dang Nguyen Ngoc Khanh'
// ];
var url = "http://localhost:9081/lisst";
axios.get(url).then(function(res) {
    var items = res.data;
    list(items)
});


// chen vao the ul
function list(items) {
    var thamchieu = document.getElementById('newitem');
    var contine = items.map(function(x) {
        return '<li>' + ten.x + '</li>'
    });
    thamchieu.innerHTML = contine.join('');
    localStorage.setItem(arrlist, JSON.stringify(arr))
};


// them du lieu vao ul
var button = document.getElementById("clicssk")
button.addEventListener("click", themdulieu)

function themdulieu() {
    var input = document.getElementById('number');
    var bien = input.value;
    arr.push(bien);

    list();
    input.value = " ";
}