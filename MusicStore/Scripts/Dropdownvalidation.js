function ddlValidate() {
    var e = document.getElementById("GenreId");
    var optionSelIndex = e.options[e.selectedIndex].value;
    console.log(optionSelIndex)
    if (optionSelIndex <= 0 || optionSelIndex > 10) {
        alert("Value not permit ");
        return false
    }
}
