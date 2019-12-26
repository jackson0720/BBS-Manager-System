history.go(1);
$(function () {
    var mydate = new Date();
    var t = mydate.toLocaleDateString();
    $("#time").text(t);
    $("#go").click(function () {
        var loginfo = {
            "name": $("#name").val(),
            "password": $("#password").val()
        };
        $.ajax({
            url: "/Login/Login",
            type: "post",
            data: loginfo,
            async: false,
            success: function (data) {
                if (data == "用户账号不存在或密码错误！") {
                    alert(data);
                    window.location.reload();
                } else {
                    var msg = data;
                    $.ajax({
                        url: '/Login/State',
                        method: "get",
                        success: function (data) {
                            if (data == "1") {
                                alert("账号不可用。请联系超级管理员！")
                            } else {
                                $.ajax({
                                    url: '/Operationlog/InsertOperalog?log_admin=' + $("#name").val() + '&log_text=' + $("#name").val() + "在" + mydate.toLocaleString() + "登入了系统！",
                                    method: "get",
                                    async: false,
                                    success: function (data) {
                                        //alert(data);
                                    }
                                })
                                alert(msg);
                                window.location.replace('index.html');
                                //window.history.forward(1);
                            }

                        }
                    })

                }

            }
        })
    })
})