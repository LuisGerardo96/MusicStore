function ddlValidate() {

    var genre = document.getElementById("GenreId");
    var optiongenreIndex = genre.options[genre.selectedIndex].value;
    var artist = document.getElementById("ArtistId")
    var optionartistIndex = artist.options[artist.selectedIndex].value;
    console.log(optiongenreIndex)
    console.log(/^\d+$/.test(optiongenreIndex) && /^\d+$/.test(optionartistIndex));

    if (/^\d+$/.test(optiongenreIndex) && /^\d+$/.test(optionartistIndex)) {
        if (optiongenreIndex <= 0 || optiongenreIndex > 10 || optionartistIndex <= 0 || optionartistIndex > 137) {
            alert("Value not permit ");
            return false
        }
        else { return true }
    }
    else {
        alert("Value not permit")
        return false
    }

}
