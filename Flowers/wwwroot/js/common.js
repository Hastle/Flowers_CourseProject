$(document).ready(function () {
    $('.carousel').carousel();
    $(".carousel-control-prev").click(function () {
        $(".carousel").carousel("prev");
    });
    $(".carousel-control-next").click(function () {
        $(".carousel").carousel("next");
    });
});
