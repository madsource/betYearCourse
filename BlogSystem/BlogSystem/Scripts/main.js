$(document).ready(function () {
    
    $(".editComment").click(function (e) {
        e.preventDefault();
        $(this).siblings(".editForm").show();
        console.log($(this).find(".editForm"));
    });

    $(".editForm > .close").click(function (e) {
        e.preventDefault();
        $(this).parent().hide();
    });
});