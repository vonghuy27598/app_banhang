var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function( request, response ) {
                $.ajax( {
                    url: "/Display/ListName",
                    dataType: "json",
                    data: {
                        a: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                } );
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
            

                return false;
            }
        })
    .autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
          .append("<div>" + item.label +  "</div>")
          .appendTo(ul);
    };
    }
}

common.init();

var complete_info = {
    init: function () {
        complete_info.goiy_thongtin();
    },
    goiy_thongtin: function () {
        if ($(".check_cookie") != null)
        {
            $(".check_cookie").autocomplete({
                    minLength: 0,
                    source: function (request, response) {
                        $.ajax({
                            url: "/GioHang/List_info_saved",
                            dataType: "json",
                            data: {
                                a: request.term
                            },
                            success: function (res) {
                                response(res.data);
                            }
                        });
                    },
                    focus: function (event, ui) {
                        
                        $(".check_cookie").val(ui.item.label);
                        var SDT = $(".check_cookie").val();
                        $.ajax({
                            url: "/GioHang/getInfo_byPhone",
                            data: { SDT: SDT },
                            datatype: "json",
                            type: "POST",
                            success: function (response) {
                                if (response.status != null) {
                                    $.each(response.status, function () {
                                    $("#HOTEN").val(this.HoTen);
                                    $("#DIACHI").val(this.DIACHI);
                                   
                                        
                                    })
                                }

                            }

                        });
                       
                    },
                    select: function (event, ui) {
                        $(".check_cookie").val(ui.item.label);
                        
                        return false;
                    }
                })
                //.autocomplete("instance")._renderItem = function (ul, item) {
                //    return $("<li>")
                //      .append("<div>" + item.label + "</div>")
                //      .appendTo(ul);
                //};
        }
        
    }
}

complete_info.init();