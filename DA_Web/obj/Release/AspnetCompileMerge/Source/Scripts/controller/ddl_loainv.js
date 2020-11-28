var ddl_loaisanpham = {
    init: function () {

        ddl_loaisanpham.khoiTaoSuKien();


    },
    //Dropdown list change
    //Đổ dữ liệu theo danh mục con


    khoiTaoSuKien: function () {
        $('#dropdownlist_loainv').change(function () {
            var select = this.options[this.selectedIndex].value;
            $.ajax({
                url: "ChangeLoaiNV",
                data: { ID_LOAINV: select },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    if (response.status != null) {
                        $(".table-bordered").find("tr:gt(0)").remove();

                        var contentTable = "";

                        $.each(response.status, function () {      
                            contentTable += '<tr id=row_' + this.ID_NHANVIEN + '><td>' + this.ID_NHANVIEN + '</td> <td>' + this.HoTen + '</td> <td>' + this.SDT + '</td> <td>' + this.Tenloainhanvien + '</td> <td id ="sua"><a href="ThongTinNhanVien?id_nv=' + this.ID_NHANVIEN + '" title="Xem chi tiết"><img src="/Content/image/icon_view.png" /></a></td> <td id="xoa"><a data-ajax="true" data-ajax-complete="\$(\'#row_' + this.ID_NHANVIEN + '\').remove()" data-ajax-confirm="Bạn có muốn xóa nhân viên ' + this.HoTen + ' không?" data-ajax-method="DELETE" href="/Admin/User/Delete/' + this.ID_NHANVIEN + '"><img alt="Xóa" src="../../Content/image/icon_xoa.png"></a></td>';
                        });
                        $('.table_change').append(contentTable);
                    }
                }
            });

        });
    }

}
ddl_loaisanpham.init();