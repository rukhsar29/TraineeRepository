function InsertUser() {
    debugger;
    var userName = $("#AName").val();
    var Email = $("#ALat").val();
    var Address = $("#ALong").val();
    var image = $("#image").val();
    //var fileUpload = $("#image").get(0);
    //var files = fileUpload.files;
   
    ///  get var values 

    //var url = "@Url.Action("InsertuS", "Index")" 
    $.ajax({
        url: '/Index/InsertuS',
        type: 'POST',
        data: JSON.stringify({
            FullName: userName,
            UserEmail: Email,
            Address: Address,
            ProfilePic: image
            
            

        }),
        dataType: 'json',
        contentType: 'application/json',
        async: false,
        success: function (data) {
            //$("#addUser").hide();
            //$("#addUser").addClass('hide');
        }

    });
}