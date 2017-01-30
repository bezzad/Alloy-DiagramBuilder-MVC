function showAlert(message, title, type) {
    $('#alert_placeholder').html("<div id='messageBox' class='alert alert-" + type + " alert-dismissible fade in'>" +
        "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" +
                "<strong>" + title + "</strong> " + message + "</div>");

    setTimeout(function () { $(".alert").alert("close"); }, 5000);
}