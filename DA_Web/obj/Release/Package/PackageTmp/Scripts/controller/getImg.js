// Get the modal
var modal_showIMG = document.getElementById("myModal_showIMG");
// Get the button that opens the modal
var btn_showIMG = document.getElementById("myBtn_showIMG");
var idsp = "";



$('.img_success').on("click", function () {
    var img_click = $(this);
    idsp = img_click.data("id");
    $('.h4-title').html("Thay đổi hình ảnh");
    $('#btn_Change_img').text("Lưu ảnh");
    $('#btn_Delete_img').css("display", "block");
    $('#btn_Delete_img').prop("disabled", false);
    btn_showIMG.click();
});
$('.addImg').on("click", function () {   
   
    $('.h4-title').html("Thêm mới hình ảnh");
    $('#btn_Change_img').text("Tạo mới");
    
    $('#btn_Delete_img').css("display", "none");
    $('#btn_Delete_img').prop("disabled", true);
    $(".body_changeimg").empty();
    var contentTable = "";

    contentTable += '<img class="img-profile " src="/Content/img/chamhoi.png" id="Upload" style="width: 100%; height: 100%; cursor: pointer; "> <input type="text" name="picture2" id="hinh" style="display:none" /> <input type="file" id="fUpload" name="fileUpload2" style="display:none" />'
    $('#btn_Change_img').prop('disabled', true);
    $(".body_changeimg").append(contentTable);
  
    modal_showIMG.style.display = "block";
});
btn_showIMG.onclick = function () {

    $.ajax({
        url: "HinhAnhChange",
        data: { ID_HINHANH: idsp },
        datatype: "json",
        type: "POST",
        success: function (response) {
            if (response.status != null) {

                $(".body_changeimg").empty();
                var contentTable = "";

                contentTable += '<img class="img-profile " src="' + response.status.HINHANH + '" id="Upload" style="width: 100%; height: 100%; cursor: pointer; "> <input type="text" name="picture2" id="hinh" style="display:none" /> <input type="file" id="fUpload" data-id="' + response.status.ID_HINHANH + '" name="fileUpload2" style="display:none" />'
            }
            $(".body_changeimg").append(contentTable);
        }
    });
    $('#btn_Change_img').prop('disabled', true);
    modal_showIMG.style.display = "block";
}
// Get the <span> element that closes the modal
var span_showIMG = document.getElementsByClassName("close_modalimg")[0];

// When the user clicks the button, open the modal

$('#btn_Change_img').click(function ()
{


    var value = $(this).text();
    if (value == "Lưu ảnh")
    {
        var src_img = $('.body_changeimg #hinh').val();
        $.ajax({
            url: '/Admin/Home/ChangeImage_MUCHINH',
            data: { id_ha: idsp, src_img: src_img },
            datatype: "json",
            type: "POST",
            success: function (response) {
                if (response.status != null) {
                    modal_showIMG.style.display = "none";
                    $("#pictureSuccess_" + idsp).attr('src', response.status.HINHANH_N);
                }
            },
            error: function (response) {

                modal_showIMG.style.display = "none";
                $("#pictureSuccess_" + idsp).attr('src', $('.body_changeimg #hinh').val());

            }

        });
    }else if(value == "Tạo mới")
    {
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }



        var src_img = $('.body_changeimg #hinh').val();
       
        $.ajax({
            url: '/Admin/Home/CreateImg',
            data: { id_sp: getUrlVars()["ID_SANPHAM"], src_img: src_img },
            datatype: "json",
            type: "POST",
            success: function (response) {
                location.reload();
            }
        });
    }
   
    
});

$('#btn_Delete_img').click(function () {
 
    var r = confirm("Bạn có chắc muốn xóa hình này không?");
    if (r == true)
    {
        $.ajax({
            url: '/Admin/Home/Delete_MUCHINH',
            data: { id_ha: idsp},
            datatype: "json",
            type: "POST",
            success: function (response) {
                location.reload();
            }

        });
    }
});



$('.body_changeimg').on('click', '#Upload', function () {
    $('#fUpload').trigger('click')
});

$('.body_changeimg').on('change','#fUpload',function () {
    if (window.FormData !== undefined) {
        var fUpload = $(this).get(0);
        var file_hinh = fUpload.files;

        var formData_hinh = new FormData();
        formData_hinh.append('file', file_hinh[0]);
        $.ajax({
            type: 'POST',
            url: 'ProcessUpload',
            contentType: false,
            processData: false,
            data: formData_hinh,

            success: function (urlImage2) {
                $('#btn_Change_img').prop('disabled', false);
                $('.body_changeimg #Upload').attr('src', urlImage2);

                $('.body_changeimg #hinh').val(urlImage2);
            },
            error: function (err) {
                alert('Có lỗi khi upload ảnh: ' + err.statusText);
            }
        });
    }
});
// When the user clicks on <span> (x), close the modal
span_showIMG.onclick = function () {
    modal_showIMG.style.display = "none";
    $(".body_changeimg").empty();
}

// When the user clicks anywhere outside of the modal, close it



//Get modal nhân viên




//// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (modal_showIMG != null) {
        if (modal_showIMG.style.display == "block") {
            if (event.target == modal_showIMG) {
                modal_showIMG.style.display = "none";
                $(".body_changeimg").empty();
            }
        }
    }


}

