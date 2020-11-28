// When the user scrolls down 80px from the top of the document, resize the navbar's padding and the logo's font size
var w = window.innerWidth;
if (w < 800) {
    window.onscroll = function () {
        scrollFunction()
    };
}
function scrollFunction() {
        
        if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
            document.getElementById("navbar").style.position = "fixed";
            document.getElementById("navbar").style.backgroundColor = "#7fad39";
          
            document.getElementById("logo").style.width = "100%";
            document.getElementById("logo").style.padding = "0px";
            document.getElementById("logo").style.marginLeft = "15px";
            document.getElementById("logo").style.paddingRight = "30px";
            document.getElementById("img_logo").src = "/Content/image/logo/logo_black.png";
            document.getElementById("content_tainer").style.paddingLeft = "0";
            document.getElementById("content_tainer").style.paddingRight = "0";
           
            document.getElementById("header__cart").style.color = "#fff";
            document.getElementById("header__cart").style.padding = "13px 0";
            document.getElementById("right-menu").style.paddingLeft = "0px";
          
            document.getElementById("fa-cart").style.color = "#fff";
            document.getElementById("total_cart").style.color = "#fff";


        } else {
            document.getElementById("navbar").style.position = "unset";
            document.getElementById("navbar").style.backgroundColor = "transparent";
            document.getElementById("logo").style.width = "100%";
            document.getElementById("logo").style.marginLeft = "0px";
            document.getElementById("logo").style.paddingRight = "0px";
            document.getElementById("img_logo").src = "/Content/image/logo/logo_black.png";
            document.getElementById("content_tainer").style.paddingLeft = "15px";
            document.getElementById("content_tainer").style.paddingRight = "15px";
            
            document.getElementById("header__cart").style.color = "#000";
            document.getElementById("header__cart").style.paddingRight = "0px";
            document.getElementById("fa-cart").style.color = "#000";
            document.getElementById("total_cart").style.color = "#000";
        }
    
   
}