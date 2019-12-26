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
    }
}
$(function () {
    $.ajax({
        url: '/Admin/ListAdmin',
        method: "get",
        success: function (data) {
            $.each(data, function (index, obj) {
                var state = obj.A_state == 0 ? '正常' : '已删除';
                $("#show").append(
                    '<tr>' +
                    '<td>' + obj.A_uid + '</td>' +
                    '<td>' + obj.A_account + '</td>' +
                    '<td>' + obj.A_name + '</td>' +
                    '<td>' + state + '</td>' +
                    '<td><button class="btn btn-default add" type="button">新增</button>&nbsp;&nbsp;<button class="btn btn-default operation" type="button" data-toggle="modal" data-target=".bs-example-modal-sm">操作</button></td>' +
                    '</tr>'
                )
            })

            $(".operation").on('click', function () {
                var tr = $(this).closest("tr");
                var col1_Data = tr.find("td:eq(0)").html();
                var col2_Data = tr.find("td:eq(1)").html();
                $(".OK").on('click', function () {
                    if (col2_Data == "admin") {
                        alert("超级管理员无法删除！")
                        window.location.reload();
                    } else {
                        $.ajax({
                            url: "/Admin/ChangeOpera?state=" + $("#s1").val() + '&cno=' + col1_Data,
                            method: "get",
                            success: function (data) {
                                if (data = 1) {
                                    alert("操作成功！");
                                    window.location.reload();
                                }
                            }
                        })
                    }

                })
            })

            $(".add").on('click', function () {
                if ($(".demo").css("display") == 'block') {
                    alert("无法打开多个窗口！");
                } else {
                    $(".demo").empty();
                    $(".demo").append(
                        '<div style="padding-left:60px;margin:40px;">' +
                        '<div>' +
                        '<p>' +
                        '<span style="font-size:15px;"><input type="text" style="width:300px;" class="form-control" id="account" placeholder="请输入需要新增的管理员账号"></span>' +
                        '</p>' +
                        '</div>' +
                        '<div>' +
                        '<p>' +
                        '<span style="font-size:15px;" ><input type="text" style="width:300px;" class="form-control" id="password" placeholder="请输入需要新增的管理员密码"></span>' +
                        '</p>' +
                        '</div>' +
                        '<div>' +
                        '<p>' +
                        '<span style="font-size:15px;"><input type="text" style="width:300px;" class="form-control" id="name" placeholder="请输入需要新增的管理员姓名"></span>' +
                        '</p>' +
                        '</div>' +
                        '<div>' +
                        '<p>' +
                        '<span style="font-size:15px;"><button class="btn btn-default Confirm">确    定</button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<button class="btn btn-default Close">关     闭</button></span>' +
                        '</p>' +
                        '</div>' +
                        '</div>'
                    );
                    $(".demo").css("display", "block");

                    $(".Confirm").on('click', function () {
                        var loginfo = {
                            "account": $("#account").val(),
                            "password": $("#password").val(),
                            "name": $("#name").val()
                        };
                        $.ajax({
                            url: "/Admin/AddAdmin",
                            data: loginfo,
                            type: "post",
                            async: false,
                            success: function (data) {
                                if (data = 1) {
                                    alert("新增成功！");
                                    window.location.reload();
                                }
                            }
                        })
                    })
                    $(".Close").on('click', function () {
                        $(".demo").css("display", "none");
                    })
                }

            })

        }
    })

    $.ajax({
        url: '/Admin/Count',
        method: "get",
        success: function (data) {
            //alert(data);
            $("#count").append(
                ' （ ' + data + ' ） '
            )
        }
    })
})