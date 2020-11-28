$('.add-to-cart').on('click', function () {
    var cart = $('.shopping-cart');
    var imgtodrag = $(this).parents('.item').find("img").eq(0);
    if (imgtodrag) {
        var imgclone = imgtodrag.clone()
            .offset({
                top: imgtodrag.offset().top,
                left: imgtodrag.offset().left
            })
            .css({
                'opacity': '0.5',
                'position': 'absolute',
                'height': '150px',
                'width': '150px',
                'z-index': '100'
            })
            .appendTo($('body'))
            .animate({
                'top': cart.offset().top + 10,
                'left': cart.offset().left + 10,
                'width': 75,
                'height': 75
            }, 1000, 'easeInOutExpo');

        setTimeout(function () {
            cart.effect("shake", {
                times: 2
            }, 200);
        }, 1500);

        imgclone.animate({
            'width': 0,
            'height': 0
        }, function () {
            $(this).detach();
        });
    }

});
     

      function AddCart_fly(obj) {      


          var id = obj;
          $.ajax({
              url: "/GioHang/AddToCart_fly",
              data: { id: id },
              datatype: "json",
              type: "POST",
              success: function (response) {                
                      if (response.status != null) {
                          if (!response.warning)
                          {
                              $('.count_cart').html(response.status.TongSoLuong);
                              $('.total_cart').html(formatNumber(response.status.TongTienUD, '.', ',') + " VNĐ");
                             
                          } else {
                              showToast();
                          }
                      }
                

              }
          });
          function showToast() {
              var x = document.getElementById("snackbar");
              x.className = "show";
              setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
          };
        
      }



      function formatNumber(nStr, decSeperate, groupSeperate) {
          nStr += '';
          x = nStr.split(decSeperate);
          x1 = x[0];
          x2 = x.length > 1 ? '.' + x[1] : '';
          var rgx = /(\d+)(\d{3})/;
          while (rgx.test(x1)) {
              x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
          }
          return x1 + x2;
      }








function AddCart(obj)
{
    $("#success-alert").removeClass("hide-success");
    function add_Success() {
        //js success alert in ChiTietSanPham

      

       
        $("#success-alert").fadeTo(2500, 500).slideUp(500, function () {
                $("#success-alert").slideUp(500);
            });
      
    }


    var id = obj;
    $.ajax({
        url: "/GioHang/AddToCart",
        data: {id: id},
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (!response.warning)
            {
                if (response.status != null) {
                    $('.count_cart').html(response.status.TongSoLuong);
                    $('.total_cart').html(formatNumber(response.status.TongTienUD, '.', ',') + " VNĐ");
                    add_Success();
                }
            } else {
                showToast();
            }
          
        }
    });
    function showToast() {
        var x = document.getElementById("snackbar");
        x.className = "show";
        setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
    };
   
    
}



function formatNumber(nStr, decSeperate, groupSeperate) {
    nStr += '';
    x = nStr.split(decSeperate);
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
    }
    return x1 + x2;
}


$(document).ready(function () {
    $("#success-alert").addClass("hide-success");
    $("#success-alert").hide();

});

