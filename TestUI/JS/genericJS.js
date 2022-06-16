function UserLogin()
{
    //var data = '{    "username": "SnehaS",        "password": "sneha@123" }';
    var data = '{"username":"' + $("#txtUserName").val() + '" , "password":"' + $("#txtPassword").val() + '"}';   
    $.ajax({
        url: "https://localhost:7026/api/user/authenticate",
        type: "POST",
        data: data,
        dataType: "json",
        contentType: "application/json",
        success: function (result) {
            LoginSucess(result);         
        },
        error: function (request, error) {
            alert("Login Failed...");
        }
    });
}

function LoginSucess(result) {   
    document.cookie = 'access_token=[' + result.token + ']';
    window.location.replace("HotelSearch.aspx");    
}


function GetHotels() {
    $("#mainSearch").append("");
    $.ajax({
        url: "https://localhost:7026/api/HotelSearch",
        type: "GET",
        data: {},
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + readCookie('access_token') );

        },        
        contentType: "application/json",
        success: function (result) {
            var list = result.hotelSearchResponse;
            $("#divCount").html(list.length);
            if (list.length > 0) {
                var a = '';
                for (var i = 0; i < list.length; i++) {
                    a += "<div style='padding: 10px; border: 1px; height: auto; border-color: black; width:auto;'>"
                        + " <div style='width: 20%; float: left'> "
                        + "     <img src='https://localhost:44360/images/hotel.png' height=50px; width=50px;></img>"
                        + " </div>"
                        + " <div style='width:60%; float:none'>"
                        + "     <p><b>" + list[i].hotelName + "</b></p>"
                        + "    <p><b>" + list[i].starLevel + "</b></p>"
                        + "    <p><b>" + list[i].address + "</b></p>"
                        + "     <p><b>" + list[i].hotelDescriptions + "</b></p>"
                        + " </div>"
                        + " <div style='width:20%; float:right'>"
                        + "    <p><b>" + list[i].currency + " " + list[i].totalRate + "</b></p>"
                        + " </div>"
                        + " </div>"

                }
                $("#mainSearch").append(a);
            }
            else { $("#mainSearch").html("No Data Found");}
        },
        error: function (request, error) {
            $("#mainSearch").html("No Data Found");
        }
    });
}

function SearchHotelByCity() {    
    $("#mainSearch").html('');
    $.ajax({
        url: "https://localhost:7026/api/HotelSearch/" + $("#txtSearch").val(),
        type: "GET",       
        dataType: "json",
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'Bearer ' + readCookie('access_token'));

        },
        contentType: "application/json",
        success: function (result) {
            var list = result.hotelSearchResponse;
            $("#divCount").html(list.length);
            if (list.length > 0) {
            var a = '';
            for (var i = 0; i < list.length; i++) {
                a += "<div style='padding: 10px; border: 1px; height: auto; border-color: black; width:auto;'>"
                    + " <div style='width: 20%; float: left'> "
                    + "     <img src='https://localhost:44360/images/hotel.png' height=50px; width=50px;></img>"
                    + " </div>"
                    + " <div style='width:60%; float:none'>"
                    + "     <p><b>" + list[i].hotelName + "</b></p>"
                    + "    <p><b>" + list[i].starLevel + "</b></p>"
                    + "    <p><b>" + list[i].address + "</b></p>"
                    + "     <p><b>" + list[i].hotelDescriptions + "</b></p>"
                    + " </div>"
                    + " <div style='width:20%; float:right'>"
                    + "    <p><b>" + list[i].currency + " " + list[i].totalRate + "</b></p>"
                    + " </div>"
                    + " </div>"

            }
            $("#mainSearch").append(a);
        }
            else { $("#mainSearch").html("No Data Found"); }
        },
        error: function (request, error) {
            $("#mainSearch").html("No Data Found");
        }
    });
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length+1, c.length-1);
    }
    return null;
}