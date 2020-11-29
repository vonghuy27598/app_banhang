// When the user scrolls down 80px from the top of the document, resize the navbar's padding and the logo's font size
var w = window.innerWidth;
if (w < 800) {
    window.onscroll = function () {
        $("#txtKeyword").css("width", "45px");
        $("#logo1").css("display", "inline");
        scrollFunction()
    };
}
$("#txtKeyword").click(function()
{
    $(this).css("width", "200%");
    $("#logo1").css("display", "none");
    event.stopPropagation();
})
$(document).click(function () {
    $("#txtKeyword").css("width", "45px");
    $("#logo1").css("display", "inline");
});
function scrollFunction() {
        
        if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
            document.getElementById("navbar").style.position = "fixed";
            document.getElementById("navbar").style.backgroundColor = "#7fad39";
            document.getElementById("navbar").style.left = "0";
            document.getElementById("logo").style.width = "100%";
            document.getElementById("logo").style.paddingLeft = "30px";
            document.getElementById("cart").style.padding = "5px 15px 0px 15px";
            document.getElementById("search").style.padding = "5px";
            document.getElementById("img_logo").src = "/Content/image/logo/logo_black.png";
            document.getElementById("content_tainer").style.paddingLeft = "15px";
            document.getElementById("content_tainer").style.paddingRight = "15px";
            document.getElementById("form").style.padding = "5px 5px";
            document.getElementById("header__cart").style.color = "#fff";
            document.getElementById("header__cart").style.padding = "15px 0";
          
            document.getElementById("fa-cart").style.color = "#fff";
           


        } else {
            document.getElementById("navbar").style.position = "unset";
            document.getElementById("navbar").style.backgroundColor = "transparent";
            document.getElementById("logo").style.width = "100%";
            document.getElementById("logo").style.marginLeft = "0px";
            document.getElementById("logo").style.paddingLeft = "0px";
            document.getElementById("cart").style.paddingRight = "15px";
            document.getElementById("search").style.paddingTop = "15px";
            document.getElementById("form").style.padding = "0px 0";
            document.getElementById("cart").style.padding = "0px";
            document.getElementById("img_logo").src = "/Content/image/logo/logo_black.png";
            document.getElementById("content_tainer").style.paddingLeft = "15px";
            document.getElementById("content_tainer").style.paddingRight = "15px";;
            document.getElementById("header__top").style.height = "75px";
            document.getElementById("header__cart").style.color = "#000";
            document.getElementById("header__cart").style.paddingTop = "25px";
            document.getElementById("fa-cart").style.color = "#000";
          
        }
    
   
}