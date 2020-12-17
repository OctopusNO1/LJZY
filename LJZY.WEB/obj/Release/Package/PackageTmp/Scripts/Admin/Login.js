
//$(function () {

//    var url = window.location.href;// 你发送请求的地址
//    console.log(url);
//    var token = getUrlParam("token");//
//    console.log(token);
//    if (token != null) {
//        tokenCheck(token);
//    } else {
//       // $('#loginMain').attr('style','none');
//        $('#loading').fadeOut('normal', function () {
//            $(this).remove();
//        });
//    }

//});
//function tokenCheck(token) {
    
//    console.log(token); 
//    $.ajax({ 
//        url: "http://10.142.33.218:8015/realtime/login/curr-user",
//        method: "GET",
//        dataType: "json", 
//        headers: {
//            'auth': token,
            
//        },
//        success: function (msg) {
//            console.log(msg) 
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
             
//            console.log(XMLHttpRequest);
             
//        },
//        complete: function (XMLHttpRequest, status) { //请求完成后最终执行参数　
//            console.log(XMLHttpRequest, status);
//        }
//    });
//    //logOn();
//}
//function getUrlParam(name) {//封装方法   
//    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
//    //console.log(reg);
//    //构造一个含有目标参数的正则表达式对象    
//    var r = window.location.search.substr(1).match(reg);
//    //console.log(r);
//    //匹配目标参数    
//    if (r != null)
//        return unescape(r[2]);
//    //console.log(unescape(r[2]));
//    return null; //返回参数值
//}

function logOn() {
    var account = $("#txtAccount").val();
    var password = $("#txtPassword").val();
    var flag = "login";
    if (account == "" || password == "") {
        alert("请输入用户名和密码");
        return;
    }
    $.ajax({
        type: "post",
        url: "../../Controllers/LoginController.ashx?action=login",
        dataType: "json",
        data: {
            "account": account,
            "password": password,
        },
        success: function (msg) {
            console.log(1)
            if (msg.IsSuccess == "true") {
                loginLoading();
                window.location.replace("Index.aspx");
                console.log(2)
            }
            else {
                alert("登录失败");
                console.log(2)
            }

        }
    });
}
function loginLoading() {
    //获取浏览器页面可见高度和宽度
    var _PageHeight = document.documentElement.clientHeight,
        _PageWidth = document.documentElement.clientWidth;
    //计算loading框距离顶部和左部的距离（loading框的宽度为215px，高度为61px）
    var _LoadingTop = _PageHeight > 61 ? (_PageHeight - 61) / 2 : 0,
        _LoadingLeft = _PageWidth > 215 ? (_PageWidth - 215) / 2 : 0;
    //在页面未加载完毕之前显示的loading Html自定义内容
    var _LoadingHtml = '<div id="loadingDiv" style="position:absolute;left:0;width:100%;height:' + _PageHeight + 'px;top:0;opacity:1;filter:alpha(opacity=80);z-index:10000;"><div style="position: absolute; cursor1: wait; left: ' + _LoadingLeft + 'px; top:' + _LoadingTop + 'px; width: auto; height: 57px; line-height: 40px; padding-left: 50px; padding-right: 5px; background:url(../../Image/loading-1.gif) no-repeat; color: #696969; font-family:\'Microsoft YaHei\';">正在加载中...</div> </div>';
    //呈现loading效果
    $("#maskContainer").css("display", "block").html(_LoadingHtml);

    window.onload = function () {
        var loadingMask = document.getElementById('loadingDiv');
        loadingMask.parentNode.removeChild(loadingMask);
    };

    //监听加载状态改变
    document.onreadystatechange = completeLoading;

    //加载状态为complete时移除loading效果
    function completeLoading() {
        if (document.readyState == "complete") {
            var loadingMask = document.getElementById('loadingDiv');
            loadingMask.parentNode.removeChild(loadingMask);
            $("#maskContainer").css("display", "none;")
        }
    }
}
function keyLogin() {
    if (event.keyCode == 13) {  //回车键的键值为13
        document.getElementById("loginBtn").click(); //调用登录按钮的登录事件
    }
}
