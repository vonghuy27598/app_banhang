var ddl = {
    init: function () {
       
        ddl.khoiTaoSuKien();
      
       
    },
    //Dropdown list change
    //Đổ dữ liệu theo danh mục con

   
    khoiTaoSuKien: function () {
        $('#dropdownlist').change(function () {
            var select = this.options[this.selectedIndex].value;
            $.ajax({
                url: "SanPham/ChangeSanPham",
                data: { ID_LOAISANPHAM: select },
                datatype: "json",
                type:"POST",             
                success: function (response) {
                    if (response.status != null) {
                        $(".table-bordered").find("tr:gt(0)").remove();
                       
                        var contentTable = "";
                        
                        $.each(response.status, function () {
                           var row = "$('#row_"+this.ID_SANPHAM+"').remove()"
                            if (this.Ngung == true) {
                                contentTable += '<tr id=row_' + this.ID_SANPHAM + '> <td>' + this.ID_SANPHAM + '</td> <td>' + this.TenSanPham + '</td> <td><span id="price" name="number">' + formatNumber(this.DonGia, '.', ',') + '</span> VNĐ</td> <td>' + this.ChietKhau + '</td><td>' + this.NhaSX + '</td><td> <input type="checkbox" name="check" class="checkN" id="checkNgung" checked="checked" disabled="disabled"  data-id="' + this.ID_SANPHAM + '" /> Ngưng </td><td>' + this.SoLuong + '</td><td id="nhapkho"><a href="NhapKho/NhapKho/' + this.ID_SANPHAM + '" title="Nhập kho"><img src="/Content/image/ic_add.png" /></a></td><td id ="sua"><a href="SanPham/EditSP/' + this.ID_SANPHAM + '" title="Sửa"><img src="/Content/image/icon_sua.png" /></a></td><td id="xoa"><a data-ajax="true" data-ajax-complete="\$(\'#row_' + this.ID_SANPHAM + '\').remove()" data-ajax-confirm="Bạn có muốn xóa không?" data-ajax-method="DELETE" href="/Admin/SanPham/Delete/' + this.ID_SANPHAM + '"><img alt="Xóa" src="../../Content/image/icon_xoa.png"></a></td><td id="quanlyhinhanh"><a href="SanPham/QuanLyHinhAnh?ID_SANPHAM = ' + this.ID_SANPHAM + '" title="Quản lý hình ảnh"><img src="/Content/image/img.png" /></a></td></tr>'

                            } else {
                                contentTable += '<tr id=row_' + this.ID_SANPHAM + '> <td>' + this.ID_SANPHAM + '</td> <td>' + this.TenSanPham + '</td> <td><span id="price" name="number">' + formatNumber(this.DonGia, '.', ',') + '</span> VNĐ</td> <td>' + this.ChietKhau + '</td><td>' + this.NhaSX + '</td><td> <input type="checkbox" name="check" class="checkN" id="checkNgung"  disabled="disabled"  data-id="' + this.ID_SANPHAM + '" /> Ngưng </td><td>' + this.SoLuong + '</td><td id="nhapkho"><a href="NhapKho/NhapKho/' + this.ID_SANPHAM + '" title="Nhập kho"><img src="/Content/image/ic_add.png" /></a></td><td id ="sua"><a href="SanPham/EditSP/' + this.ID_SANPHAM + '" title="Sửa"><img src="/Content/image/icon_sua.png" /></a></td><td id="xoa"><a data-ajax="true" data-ajax-complete="\$(\'#row_' + this.ID_SANPHAM + '\').remove()" data-ajax-confirm="Bạn có muốn xóa không?" data-ajax-method="DELETE" href="/Admin/SanPham/Delete/' + this.ID_SANPHAM + '"><img alt="Xóa" src="../../Content/image/icon_xoa.png"></a></td><td id="quanlyhinhanh"><a href="SanPham/QuanLyHinhAnh?ID_SANPHAM='+ this.ID_SANPHAM +'" title="Quản lý hình ảnh"><img src="/Content/image/img.png" /></a></td></tr>'

                            }
                          
                        });

                        $('.table_change').append(contentTable);
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
        });
    }

}
ddl.init();





