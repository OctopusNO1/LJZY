<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LJZY.WEB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title> 
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    
    
    <style>
        html {
            background: url(/Image/newbg.png) no-repeat center center fixed;
            background-size: cover;
        }

        /*.left_image {
            background-image: url(/Image/xiangzi.png);
            background-size: 100% 100%;
            width: 797px;
            height: 664px;
            float: left;
            margin-top: -30px;
           
        }*/

        #login {
            background-image: url(/Image/newdenglukuang.png);
            background-size: 100% 100%;
            position: relative;
        }

        .usrnamebox {
            width: 325px;
            height: 40px;
            /* border: 1px solid #ccc; */
            margin: 0 auto;
            position: absolute;
            top: 70px;
            left: 47px;
            background: url(/Image/newuser.png);
            background-size: 325px 40px;
        }

        .passwordbox {
            width: 325px;
            height: 40px;
            /* border: 1px solid #ccc; */
            margin: 0 auto;
            position: absolute;
            top: 124px;
            left: 47px;
            background: url(/Image/newpassword.png);
            background-size: 325px 40px;
        }

        /*.checkB {
            height: 30px;
            margin: 0 auto;
            position: absolute;
        }*/

        input[type="checkbox"] {
            -webkit-appearance: none;
            background: #fff url(/Image/kuang.png);
            height: 22px;
            vertical-align: middle;
            width: 22px;
            margin-top: 305px;
            margin-left: 41px;
        }

        /*.wjmm {
            color: white;
            height: 30px;
            width: 100px;
            margin-left: 82px;
            margin-top: -26px;
            font-size: 16px;
        }*/

        .loginbox {
            width: 325px;
            height: 42px;
            border: none;
            margin: 0 auto;
            position: absolute;
            top: 182px;
            left: 45px;
            background: url(/Image/newloginbtn.png);
            background-size: 325px 42px;
            cursor: pointer;
        }
        .loginbox:focus {
            outline:none;
        }
        .loginbox:active {
            opacity:0.8
        }

        .logininput {
            height: 35px;
            width: 255px;
            background-color: transparent;
            border: none;
            padding: 3px 5px 0 25px;
            margin-left: 12%;
            color: #0a4696;
            font-size: 16px;
        }
        .logininput:focus{
            outline:0;
        }

        .login-icons {
            position: absolute;
            top: 0;
            left: 0;
        }

        .logininput::-webkit-input-placeholder { /* WebKit browsers */
            color: #0a4696;
        }

        .logininput::-moz-placeholder { /* Mozilla Firefox 4 to 18 */
            color: #0a4696;
        }

        .logininput::-moz-placeholder { /* Mozilla Firefox 19+ */
            color: #0a4696;
        }

        .logininput::-ms-input-placeholder { /* Internet Explorer 10+ */
            color: #0a4696;
        }
    </style>
        <script>
        $.parser.parse(); // 解析整个页面
        var pc;
        $.parser.onComplete = function () {
            if (pc) clearTimeout(pc);
            pc = setTimeout(closes, 500);
        }

        function closes() {
            $('#loading').fadeOut('normal', function () {
                $(this).remove();
            });
        }

</script>
    
</head>
<body onkeydown="keyLogin();">
    <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">Loading....</font></h3>
        </div>
    <div style="width: 100%;height:100%; margin: 0 auto; padding-top: 6%;position:relative;" >
        <%--    <div class="left_image"></div>--%>
        <div style="width: 426px; height: 267px; position:absolute;right:10%;top:400%;" id="login">
            <div class="usrnamebox">
                <input type="text" class="logininput" id="txtAccount" placeholder="请输入用户名" value="admin" />
            </div>
            <div class="passwordbox">
                <input type="password" class="logininput" id="txtPassword" placeholder="请输入密码" value="123" />
            </div>
            <%--            <div class="checkB">
                <input type="checkbox" class="check" /><p class="wjmm">忘记密码</p>
            </div>--%>


            <input id="loginBtn" class="loginbox" type="button" onclick="logOn()" />

        </div>
    </div>
    <div id="maskContainer" style="width:100%;height:100%;z-index:1;display:none;"></div>
      
</body>
</html>
<script src="Scripts/Admin/Login.js"></script>

