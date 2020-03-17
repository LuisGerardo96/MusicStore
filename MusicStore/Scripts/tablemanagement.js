$(document).ready(function () {

        $('#add').click(function (e) {
            e.preventDefault();
            $.get(this.href, function (response) {
                $('.divForAdd').html(response);
            });

            $('#addmodel').modal({
                backdrop: 'static',
            }, 'show');
        });

        $('.openDialog-Edit').click(function (event) {
            event.preventDefault();
            $.get(this.href, function (response) {
                $('.divForEdit').html(response);
            });

            $('#editmodel').modal({
                backdrop: 'static',
            }, 'show');
        });


        $('#searchbutton').click(function (e) {
            var name = $('#search-box').val();
            e.preventDefault();

            $.ajax({
                url: "/StoreManager/Index",
                type: "POST",
                data: {'Name': name },
                success: function (data) {
                $('#tbody').html(data);},
                error: function () {
                    alert("An error has occured!!!");
                }
            });
        });


});
        