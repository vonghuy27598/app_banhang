// Get the modal
var modal = document.getElementById("myModal");
// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var iddh = "";
function clickView(obj) {
    iddh = obj;
    if(btn != null)
    {
        btn.click();
    }
   
}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal

    btn.onclick = function () {
        $.ajax({
            url: "ChitietDonHang",
            data: { ID_DONHANG: iddh },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.status != null) {
                    $(".table-bordered").find("tr:gt(0)").remove();
                    var contentTable = "";
                    var contentTableGiaohang = "";
                    $.each(response.status, function () {
                        if (this.TinhTrang) {
                            contentTable += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_success.png" width="90%" height="auto" /></td></tr>'
                            contentTableGiaohang += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_success.png" width="90%" height="auto" onclick="checkTinhTrang(' + this.ID_DONHANG_DM + ')" id="id_dhdm' + this.ID_DONHANG_DM + '"/></td></tr>'

                        } else {
                            contentTable += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_warning.png" width="90%" height="auto" /></td></tr>'
                            contentTableGiaohang += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_warning.png" width="90%" height="auto" onclick="checkTinhTrang(' + this.ID_DONHANG_DM + ')" id="id_dhdm' + this.ID_DONHANG_DM + '"/></td></tr>'

                        }






                    });
                    $('.table_chitiet').append(contentTable);
                    $('.table_chitietdongiaohang').append(contentTableGiaohang);
                }

            }

        });
    
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
modal.style.display = "block";

}


// When the user clicks on <span> (x), close the modal
span.onclick = function () {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it



//Get modal nhân viên


// Get the modal
var modal2 = document.getElementById("myModal2");
// Get the button that opens the modal
var btn2 = document.getElementById("myBtn2");
function clickGetNV(obj) {
    var dh = obj;
    $('#hd_iddh').text(dh);
    btn2.click();
}
//// Get the <span> element that closes the modal
var span2 = document.getElementsByClassName("close2")[0];

//// When the user clicks the button, open the modal
if (btn2 != null) {
    btn2.onclick = function () {

        modal2.style.display = "block";

    }
}



//// When the user clicks on <span> (x), close the modal
if (span2 != null) {
    span2.onclick = function () {
        modal2.style.display = "none";
    }
}


//// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (modal2 != null) {
        if (modal.style.display == "block") {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        } else if (modal2.style.display == "block") {
            if (event.target == modal2) {
                modal2.style.display = "none";
            }
        }
    } else if (modal != null) {
        if (modal.style.display == "block") {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    } else if (modal_img != null) {
        if (modal_img.style.display == "block") {
            if (event.target == modal_img) {
                modal_img.style.display = "none";
            }
        }


    }
}

