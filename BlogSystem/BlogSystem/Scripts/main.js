$(document).ready(function () {
    
    $("#comments").on("click",".editComment",function (e) {
        e.preventDefault();
        $(this).siblings(".editForm").show();
        console.log($(this).find(".editForm"));
    });

    $("#comments").on("click", ".editForm > .close", function (e) {
        e.preventDefault();
        $(this).parent().hide();
    });
});