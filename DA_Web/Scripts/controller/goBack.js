
$(document).ready(function () {
   
});

function goBack()
{
    history.back();
}


function goBackCart() {

   
    
    var referrer = document.referrer;
    
    var url = window.location.href;
  
   
        history.back();
   
  
    return false;
}

function goBackHome()
{
    location.href = "/Display/TrangChu";
}

function goCart()
{
    location.href = "/GioHang/GioHang";
}