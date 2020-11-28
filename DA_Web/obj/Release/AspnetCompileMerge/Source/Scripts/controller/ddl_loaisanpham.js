var ddl_loaisanpham = {
    init: function () {

        ddl_loaisanpham.khoiTaoSuKien();


    },
    //Dropdown list change
    //Đổ dữ liệu theo danh mục con


    khoiTaoSuKien: function () {
        $('#dropdownlist_loaisanpham').change(function () {
            var select = this.options[this.selectedIndex].value;
            $.ajax({
                url: "LoaiSanPham/ChangeLoaiSanPham",
                data: { ID_LOAISANPHAM: select },
                datatype: "json",
                type: "POST",
                success: function (response) {
                    if (response.status != null) {
                        $(".table-bordered").find("tr:gt(0)").remove();

                        var contentTable = "";

                        $.each(response.status, function () {

                            if (this.soluonghienco > 0) {
                                contentTable += '<tr id=row_' + this.ID_LOAISANPHAM + '><td>' + this.ID_LOAISANPHAM + '</td> <td>' + this.TenLoaiSanPham + '</td> <td>' + this.soluonghienco + '</td> <td id ="sua"><a href="LoaiSanPham/EditLoaiSP/' + this.ID_LOAISANPHAM + '" title="Sửa"><img src="/Content/image/icon_sua.png" /></a></td> <td><a style="border:none;background:none;cursor:pointer" onclick="clickXoa()"><img src="/Content/image/icon_xoa.png" /></a></td>';

                            } else {
                                contentTable += '<tr id=row_' + this.ID_LOAISANPHAM + '><td>' + this.ID_LOAISANPHAM + '</td> <td>' + this.TenLoaiSanPham + '</td> <td>' + this.soluonghienco + '</td> <td id ="sua"><a href="LoaiSanPham/EditLoaiSP/' + this.ID_LOAISANPHAM + '" title="Sửa"><img src="/Content/image/icon_sua.png" /></a></td><td id="xoa"><a data-ajax="true" data-ajax-complete="\$(\'#row_' + this.ID_LOAISANPHAM + '\').remove()" data-ajax-confirm="Bạn có muốn xóa không?" data-ajax-method="DELETE" href="/Admin/LoaiSanPham/Delete/' + this.ID_LOAISANPHAM + '"><img alt="Xóa" src="../../Content/image/icon_xoa.png"></a></td></tr>'

                            }

                        });





                        $('.table_change').append(contentTable);
                    }

                }

            });

        });
    }

}
ddl_loaisanpham.init();





