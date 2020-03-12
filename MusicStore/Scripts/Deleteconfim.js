$(document).ready(function () {
    $('a').click(function () { // noting work => btn btn-small btn-danger

        if (confirm("Etes vous sur de vouloir effacer cet element ?"))
            alert("confirm ok ");
    });
});