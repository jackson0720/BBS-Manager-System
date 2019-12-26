function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return dt.getFullYear() + "/" + (dt.getMonth() + 1) + "/" + dt.getDate();
}

function entersearch() {
    var event = window.event || arguments.callee.caller.arguments[0];
    if (event.keyCode == 13) {
        //写需要执行的事件
        if ($("#name").val() == "") {
            alert("请输入你要查找的文章编号");
        } else {
            $.ajax({
                url: '/Posts/ListPostsByPid?pid=' + $("#name").val(),
                method: "get",
                success: function (data) {
                    if (data.P_id == null) {
                        alert("未找到任何信息！");
                        window.location.reload();
                    } else {
                        $('#show tr:not(:first)').remove();
                        var state = data.P_state == 0 ? '正常' : '已删除';
                        $("#show").append(
                            '<tr>' +
                            '<td>' + data.P_id + '</td>' +
                            '<td>' + data.P_theme + '</td>' +
                            '<td>' + data.P_account + '</td>' +
                            '<td>' + ToJavaScriptDate(data.P_time) + '</td>' +
                            '<td>' + data.P_view + '</td>' +
                            '<td>' + state + '</td>' +
                            '<td><button class="btn btn-default checkinfo" type="button">查看</button>&nbsp;&nbsp;<button class="btn btn-default dischange" type="button" data-toggle="modal" data-target=".bs-example-modal-sm">操作</button></td>' +
                            '</tr>'
                        )

                        $(".dischange").on('click', function () {
                            var tr = $(this).closest("tr");
                            $(".OK").on('click', function () {
                                var col1_Data = tr.find("td:eq(0)").html();
                                $.ajax({
                                    url: '/Posts/ChangeOpera?state=' + $('#s1').val() + '&pid=' + col1_Data,
                                    method: "get",
                                    success: function (data) {
                                        if (data == "1") {
                                            alert("操作成功!");
                                        }
                                    }
                                })
                                window.location.reload();
                            })
                        })

                        $(".checkinfo").mouseover(function () {
                            $(".demo").empty();
                            var tr = $(this).closest("tr");
                            var col1_Data = tr.find("td:eq(0)").html();
                            $.ajax({
                                url: '/Posts/GetPostsTextByPid?pid=' + col1_Data,
                                method: "get",
                                success: function (data) {
                                    $(".demo").append(
                                        '<a href="#" id="close">关闭</a>' +
                                        '<div style="padding:20px;margin:10px;">全文：' +
                                        '<div style="overflow:auto;">' +
                                        '<p>' +
                                        '<span style="font-size:15px;"> ' + data.P_text + '</span>' +
                                        '</p>' +
                                        '</div>' +
                                        '</div>'
                                    );
                                    $(".demo").css("display", "block");
                                    $("#close").on('click', function () {
                                        $(".demo").css("display", "none");
                                    })
                                }

                            })
                        });
                    }

                }

            })
        }
    }
}
$(function () {
    $.ajax({
        url: '/Posts/ListPosts',
        method: "get",
        success: function (data) {
            $.each(data, function (index, obj) {
                var state = obj.P_state == 0 ? '正常' : '已删除';
                $("#show").append(
                    '<tr>' +
                    '<td>' + obj.P_id + '</td>' +
                    '<td>' + obj.P_theme + '</td>' +
                    '<td>' + obj.P_account + '</td>' +
                    '<td>' + ToJavaScriptDate(obj.P_time) + '</td>' +
                    '<td>' + obj.P_view + '</td>' +
                    '<td>' + state + '</td>' +
                    '<td><button class="btn btn-default listinfo" type="button">查看</button>&nbsp;&nbsp;<button class="btn btn-default change" type="button" data-toggle="modal" data-target=".bs-example-modal-sm">操作</button></td>' +
                    '</tr>'
                )
            })
            $(".change").on('click', function () {
                var tr = $(this).closest("tr");
                $(".OK").on('click', function () {
                    var col1_Data = tr.find("td:eq(0)").html();
                    $.ajax({
                        url: '/Posts/ChangeOpera?state=' + $('#s1').val() + '&pid=' + col1_Data,
                        method: "get",
                        success: function (data) {
                            if (data == "1") {
                                alert("操作成功!");
                            }
                        }
                    })
                    window.location.reload();
                })
            })
            $(".listinfo").mouseover(function () {
                $(".demo").empty();
                var tr = $(this).closest("tr");
                var col1_Data = tr.find("td:eq(0)").html();
                $.ajax({
                    url: '/Posts/GetPostsTextByPid?pid=' + col1_Data,
                    method: "get",
                    success: function (data) {
                        $(".demo").append(
                            '<a href="#" id="close">关闭</a>' +
                            '<div style="padding:20px;margin:10px;">全文：' +
                            '<div style="overflow:auto;">' +
                            '<p>' +
                            '<span style="font-size:15px;"> ' + data.P_text + '</span>' +
                            '</p>' +
                            '</div>' +
                            '</div>'
                        );
                        $(".demo").css("display", "block");
                        $("#close").on('click', function () {
                            $(".demo").css("display", "none");
                        })
                    }

                })
            });

        }
    })




    $.ajax({
        url: '/Posts/ListCount',
        method: "get",
        success: function (data) {
            //alert(data);
            $("#count").append(
                ' （ ' + data + ' ） '
            )
        }
    })
})