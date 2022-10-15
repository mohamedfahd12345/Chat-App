var connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();
/*
 NOTE : WE USE JQURY 
 $("#list") ->this JQURY
 */

window.scrollTo(0, document.body.scrollHeight);

// THIS TO SHOW ALL MESSAGES TO UESRS 
connection.on("reseivemessage", function (fromuser, message) {
    var msg = fromuser + " : " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    // $("#list").prepend(li);
    $("#list").append(li)

});
//TO START CONNECTION
connection.start();

//TO RESIVE INPUT AND SEND IT TO FUNCTION SEND MESSAGE IN HUBS CLASS 
$("#btnsend").on("click", function () {
    var fromuser = $("#txtuser").val();
    var message = $("#txtmessage").val();
    if (fromuser != "" && message != "") {
        connection.invoke("sendmessage", fromuser, message); //send to methods in class hubs
    }
   
});















/*
$("#btnsend").on("click", function () {
    var fromuser = $("#txtuser").val();
    var message = $("#txtmessage").val();

    connection.invoke("sendmessage", fromuser, message); //send to methods in class hubs
});
*/