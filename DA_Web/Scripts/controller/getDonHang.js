// Get the modal
var modal = document.getElementById("myModal");
var modal2 = document.getElementById("myModal2");
// Get the button that opens the modal
var btn = document.getElementById("myBtn");
var btn2 = document.getElementById("myBtn2");
var iddh = "";
function clickView(obj) {
    iddh = obj;
    if (btn != null) {
        btn.click();
    }

}
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
var span2 = document.getElementsByClassName("close2")[0];
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
                        contentTable += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td><td>' + this.TuyChon + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_success.png" width="90%" height="auto" /></td></tr>'
                        contentTableGiaohang += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td><td>' + this.TuyChon + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/image/icon_note.png" width="90%" height="auto" onclick="openNote(' + this.ID_DONHANG_DM + ')" /></td><td><img src="/Content/img/icon_success.png" width="90%" height="auto" onclick="checkTinhTrang(' + this.ID_DONHANG_DM + ')" id="id_dhdm' + this.ID_DONHANG_DM + '"/></td></tr>'

                    } else {
                        contentTable += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td><td>' + this.TuyChon + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/img/icon_warning.png" width="90%" height="auto" /></td></tr>'
                        contentTableGiaohang += '<tr> <td width="13%">' + this.ID_SANPHAM + '</td><td width="15%"><img src="' + this.HinhAnh + '" width="100%" height="auto"/></td> <td width="35%">' + this.TenSanPham + '</td> <td>' + this.TuyChon + '</td> <td width="13%">' + this.SoLuong + '</td> <td width="30%">' + formatNumber(this.Giatien, '.', ',') + ' VNĐ</td><td><img src="/Content/image/icon_note.png" width="90%" height="auto" onclick="openNote(' + this.ID_DONHANG_DM + ')"/></td><td><img src="/Content/img/icon_warning.png" width="90%" height="auto" onclick="checkTinhTrang(' + this.ID_DONHANG_DM + ')" id="id_dhdm' + this.ID_DONHANG_DM + '"/></td></tr>'

                    }






                });
                $('.table_chitiet').append(contentTable);
                $('.table_chitietdongiaohang').append(contentTableGiaohang);
            }

        }

    });


    modal.style.display = "block";

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

// When the user clicks on <span> (x), close the modal
if (span != null)
    span.onclick = function () {
        modal.style.display = "none";
    }
if (span2 != null)
    span2.onclick = function () {
        modal2.style.display = "none";
    }
// When the user clicks anywhere outside of the modal, close it



//Get modal nhân viên



function clickGetNV(obj) {
    var dh = obj;

    var r = confirm("Bạn có chắc chuyển đơn hàng này sang BEST không?");
    if (r == true) {


        $.ajax({
            url: "setNV_giaohang",
            data: { ID_DONHANG: dh },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.status == true) {
                    $('#id_nvgiaohang_' + dh).empty();
                    $('#id_nvgiaohang_' + dh).append('<img src="/Content/img/icon_success.png" width="40%" height="auto" />');
                } else {
                    alert("Đơn hàng này đã được nhân viên khác chốt đơn");
                    location.reload();
                }

            }

        });
    }

}

//// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (modal != null) {
        if (modal.style.display == "block") {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
    }
    if (modal2 != null) {
        if (modal2.style.display == "block") {
            if (event.target == modal2) {
                modal2.style.display = "none";
            }
        }
    }
}

//get Modal đơn hàng thất bại
var id_dh_hong = "";
function donhong(obj) {
    id_dh_hong = obj;
    btn2.click();
    if ($("#select-aws").val() != 4)
        $("#baocao").text($(".current").text());
    else
        $("#baocao").text("");
}
if (btn2 != null)
    btn2.onclick = function () {
        modal2.style.display = "block";
    }
$("#select-aws").change(function () {
    if (this.value == 4) {
        $(".option-dif").css("display", "block")
        $("#baocao").text("");
    }
    else {
        $(".option-dif").css("display", "none");
        $("#baocao").text($("#select-aws option:selected").text());
    }

});
function send_report() {
    var r = confirm("Khi gửi, đơn hàng này sẽ mất hiệu lực. Bạn có đồng ý không?")
    if (r) {
        var message = $("#baocao").text();
        if (message.length > 0) {
            $.ajax({
                url: "sendReport",
                data: { ID_DONHANG: id_dh_hong, message: message },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        alert("Đã gửi báo cáo thành công");
                        location.reload();
                    }

                }

            });
        } else {
            message = $("#baocao").val();
            if (message.length > 0) {
                $.ajax({
                    url: "sendReport",
                    data: { ID_DONHANG: id_dh_hong, message: message },
                    datatype: "json",
                    type: "POST",
                    success: function (response) {
                        if (response.status == true) {
                            alert("Đã gửi báo cáo thành công");
                            location.reload();
                        }

                    }

                });
            } else
                alert("Vui lòng nhập lý do");

        }

    }
}
function openNote_DH(obj) {
    var id_dh = obj;
    $.ajax({
        url: "openNote_DH",
        data: { ID_DONHANG: id_dh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                swal("Ghi chú đơn hàng", response.status);

            }

        }

    });
}
function openNote_PH(obj) {
    var id_dh = obj;
    $.ajax({
        url: "openNote_DH",
        data: { ID_DONHANG: id_dh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                swal("Ghi chú đơn hàng", response.status);

            }

        }

    });
}
function openNote_GC(obj) {
    var id_dh = obj;
    $.ajax({
        url: "openNote_GC",
        data: { ID_DONHANG: id_dh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                swal("Ghi chú đơn hàng", response.status);

            }

        }

    });
}
function openNote(obj) {
    var id_dm = obj;
    $.ajax({
        url: "openNote",
        data: { ID_DONHANG_DM: id_dm },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                swal("Ghi chú sản phẩm", response.status);

            }

        }

    });
}
$("#select-change-hd").change(function () {
    var form = this.value;
    var date = $("#hd_date").text();
    if (date.length > 0) {

        if (form != "none") {

            $.ajax({
                url: "change_select_donhang_bydate",
                data: { form: form, date: date },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    if (response.status != null) {
                        $(".tb_ql").find("tr:gt(0)").remove();

                        var contentTable = "";

                        $.each(response.status, function () {
                            var damua = "Đã thanh toán";
                            if (this.Damua == false) {
                                damua = "Chưa thanh toán";
                                if (this.TinhTrangDon == false)

                                    damua = "<span style='color:red;font-weight:800'>Bị hủy <b class='open_lydo' style='color:blue' onclick='open_lydo(" + this.ID_DONHANG + ")'>Xem</b></span>";
                            }

                            var nguoigiao = this.ID_NGUOIGIAO;
                            var ten_nguoiban = "";
                            var date = this.NgayGiaoDich;
                            var nowDate = new Date(parseInt(date.substr(6)));
                            var result = nowDate.format("dd/mm/yyyy");
                            if (this.TEN_NGUOIBAN != null)

                                ten_nguoiban = this.TEN_NGUOIBAN;

                            if (this.ID_NGUOIGIAO == null)
                                nguoigiao = '<a title="Xem" onclick="clickGetNV(' + this.ID_DONHANG + ')"><img src="/Content/img/icon_warning.png" width="40%" height="auto" /></a>';
                            else
                                nguoigiao = '<img src="/Content/img/icon_success.png" width="40%" height="auto" />';
                            contentTable += '<tr> <td>' + this.ID_DONHANG + '</td> <td>' + ten_nguoiban + '</td><td>' + result + '</td> <td><span id="price">' + formatNumber(this.TONGTIEN, '.', ',') + '</span> VNĐ </td> <td> ' + damua + '  </td> <td width="17%" id="id_nvgiaohang_' + this.ID_DONHANG + '">' + nguoigiao + '</td> <td id="nhapkho"><a title="Xem" onclick="clickView(' + this.ID_DONHANG + ')"><img src="/Content/image/icon_view.png" /></a></td>';
                        });
                        $('.table_change').append(contentTable);

                    }

                }

            });
        }
    } else {
        if (form != "none") {

            $.ajax({
                url: "change_select_donhang",
                data: { form: form },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    if (response.status != null) {
                        $(".tb_ql").find("tr:gt(0)").remove();

                        var contentTable = "";

                        $.each(response.status, function () {
                            var damua = "Đã thanh toán";
                            if (this.Damua == false) {
                                damua = "Chưa thanh toán";
                                if (this.TinhTrangDon == false)

                                    damua = "<span style='color:red;font-weight:800'>Bị hủy <b class='open_lydo' style='color:blue' onclick='open_lydo(" + this.ID_DONHANG + ")'>Xem</b></span>";
                            }

                            var nguoigiao = this.ID_NGUOIGIAO;
                            var ten_nguoiban = "";
                            var date = this.NgayGiaoDich;
                            var nowDate = new Date(parseInt(date.substr(6)));
                            var result = nowDate.format("dd/mm/yyyy");
                            if (this.TEN_NGUOIBAN != null)

                                ten_nguoiban = this.TEN_NGUOIBAN;

                            if (this.ID_NGUOIGIAO == null)
                                nguoigiao = '<a title="Xem" onclick="clickGetNV(' + this.ID_DONHANG + ')"><img src="/Content/img/icon_warning.png" width="40%" height="auto" /></a>';
                            else
                                nguoigiao = '<img src="/Content/img/icon_success.png" width="40%" height="auto" />';
                            contentTable += '<tr> <td>' + this.ID_DONHANG + '</td> <td>' + ten_nguoiban + '</td><td>' + result + '</td> <td><span id="price">' + formatNumber(this.TONGTIEN, '.', ',') + '</span> VNĐ </td> <td> ' + damua + '  </td> <td width="17%" id="id_nvgiaohang_' + this.ID_DONHANG + '">' + nguoigiao + '</td> <td id="nhapkho"><a title="Xem" onclick="clickView(' + this.ID_DONHANG + ')"><img src="/Content/image/icon_view.png" /></a></td>';
                        });
                        $('.table_change').append(contentTable);

                    }

                }

            });
        }
    }

});
function open_lydo(obj) {
    var id_dh = obj;
    $.ajax({
        url: "openLyDo",
        data: { ID_DONHANG: id_dh },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {
                swal("Lý do ", response.status);

            }

        }

    });
}