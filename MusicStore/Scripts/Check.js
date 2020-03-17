function checkTitle() {
    var txt = document.getElementById("Title").value;
    console.log(txt);
    regex = /^[^/*<>]{0,160}$/;
    if (!regex.test(txt)) {
        alert("Value not permit for Title ");
        document.getElementById("Title").value = "";
    }
}

function checkPrice() {
    var txt2 = document.getElementById("Price").value;
    regex = /^\d{1,5}(\.\d{1,2})?$/;
    if (!regex.test(txt2)) {
        alert("Value not permit for Price");
        document.getElementById("Price").value = "";
    }
}

