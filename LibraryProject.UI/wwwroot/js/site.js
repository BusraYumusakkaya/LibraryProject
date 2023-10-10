function GetUpdateBook(id) {
    var myUrl = "/Home/Update/" + id;
    $.ajax({
        url: myUrl,
        type: "GET",
        success: function (response) {
            $("#updatePartial").html(response);
            $("#updateModal").modal("show"); 
        }
    });
}
