"use strict";



let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



connection.start().catch(function (err) {
    console.error(err);
});



$("#join").on("click", function () {
    let room = $("#room").val();

    connection.on(room, function (data) {
        $("#allMessage").append("<div class='col-lg-12'><b>" + data.nickname + " : </b>" + data.message + "</div>");
    });

    fetch("/Home/GetChatMessageByRoom?room=" + room, {
        method: "GET"
    }).then(function (response) {
        response.json().then(function (data) {
            let htmlArray = data.map(function (item) {
                return "<div class='col-lg-12'><b>" + item.Nickname + " : </b>" + item.Message + "</div>";
            });

            $("#allMessage").append(htmlArray.join(''));

            $(".hide").each(function () {
                $(this).addClass("show");
                $(this).removeClass("hide");
            });
        });
    }).catch(function (err) {
        console.error(err);
    });
});



$("#send").on("click", function () {
    let nickname = $("#nickname").val();
    let message = $("#message").val();
    let room = $("#room").val();

    $("#message").val(null);

    fetch("/Home/SendMessage", {
        method: "POST",
        body: JSON.stringify({ nickname, message, room }),
        headers: {
            'content-type': 'application/json'
        }
    }).catch(function (err) {
        console.error(err);
    });
});



$("#room").on('focus', function () {
    if (this.value) {
        this.oldValue = this.value;
    }
}).change(function () {
    if (this.oldValue) {
        connection.off(this.oldValue);
    }

    $("#allMessage").empty();

    $(".show").each(function () {
        $(this).addClass("hide");
        $(this).removeClass("show");
    });
});