<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EmployementUI.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>XXX简历平台</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function Stuchange() {
            document.getElementById("ID").style.display = "block"; 
            document.getElementById("workID").style.display = "none";
            document.getElementById("account").style.display = "none";
            document.getElementById("zhuce").style.display = "none";
            document.getElementById("Radio1").checked = true;
        }
        function Taechange() {
            document.getElementById("workID").style.display = "block";
            document.getElementById("ID").style.display = "none";
            document.getElementById("account").style.display = "none";
            document.getElementById("zhuce").style.display = "none";
            document.getElementById("Radio2").checked = true;
        }
        function Enterchange() {
            document.getElementById("account").style.display = "block";
            document.getElementById("workID").style.display = "none";
            document.getElementById("ID").style.display = "none";
            document.getElementById("zhuce").style.display = "block";
            document.getElementById("Radio3").checked = true;l
        }
        function LoginYZ() {
            var url;
            if (document.getElementById("Radio1").checked == true) {          
                url = "LoginControl.ashx?op=Stu&userName=" + $("#StuNumber").val() + "&" + "userPwd=" + $("#password").val();
                $.ajax(url)
                .done(function (data) {
                    if (data == "yes") {
                        window.location.href = 'homepage.aspx';
                    }
                    else if (data == "no"){
                        alert("账号或密码有误");
                    }
                    else {
                        alert("账户不存在");
                    }
                });
            }
            else if (document.getElementById("Radio2").checked == true) {
          
                url = "LoginControl.ashx?op=Tea&userName=" + $("#TeaNumber").val() + "&" + "userPwd=" + $("#password").val();
                $.ajax(url)
                .done(function (data) {
                    if (data == "yes") {
                        window.location.href = 'homepage.aspx';
                    }
                    else if (data == "no") {
                        alert("账号或密码有误");
                    }
                    else {
                        alert("账户不存在");
                    }
                });
            }
            else if (document.getElementById("Radio3").checked == true) {
              
                url = "LoginControl.ashx?op=Emp&userName=" + $("#EmployeNumber").val() + "&" + "userPwd=" + $("#password").val();
                $.ajax(url)
                .done(function (data) {
                    if (data == "yes") {                       
                        window.location.href = 'homepage.aspx';
                    }
                    else if (data == "no") {
                        alert("账号或密码有误");
                    }
                    else {
                        alert("账户不存在");
                    }
                });
            }
            else {
                alert("未进入判断");
            }
        }
        function alterMesBTqd() {
            if ($("#Text1").val() != "" && $("#Text1y").val() != "" && $("#Text1m").val() != "" && $("#Text1ym").val() != "" && $("#Text3").val() != "" && $("#Text4").val() != "" && $("#Text5").val() && $("#Text2").val() != "") {
                var gs = $("#Text1").val() + "," + $("#Text1y").val() + "," + $("#Text1m").val() + "," + $("#Text1ym").val() + "," + $("#Text3").val() + "," + $("#Text4").val() + "," + $("#Text5").val();
                alert(gs.toString());
                var url = "selfMesControl.ashx?tp=TeaMesAlter&mes=" + gs;
                $.ajax(url)
                    .done(function (data) {
                        if (data == "OK") {
                            alert("更新成功");
                        }
                        else {
                            alert("失败，请联系管理员，电话~~~~~~~~~~~");
                        }
                    });
            }
            else {
                alert("信息不能为空，请填写完整！");
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="big">
        <div id="body">
            <img src="image/123.jpg" style="background-color:#d6ebf1;"/>
            <img src="image/456.jpg" />
            <ul>
                <li id="student" onclick="Stuchange();"><a>学生登录</a></li>
                <li id="teacher" onclick="Taechange();"><a>教师登录</a></li>
                <li id="enterprise" onclick="Enterchange();"><a>企业登录</a></li>
            </ul>
            <div id="login">
            </div>
             <div id="log">
                <div id="ID">学号：<input type="text" id="StuNumber" class="s1" placeholder="请输入学号"/><br /><br /><br /></div>
                <div id="workID">工号：<input type="text" id="TeaNumber" class="s1" placeholder="请输入工号"/><br /><br /><br /></div>
                <div id="account">账户：<input type="text" id="EmployeNumber" class="s1" placeholder="请输入账户"/><br /><br /><br /></div>
                <input id="Radio1" style="display:none" name="radios" checked="checked"  type="radio" /><input id="Radio2" style="display:none" name="radios"  type="radio" /><input id="Radio3" style="display:none" name="radios" type="radio" />
                <span>密码：</span><input type="password" class="s1" id="password" placeholder="请输入密码"/><br /><br /><br />
                <div id="foot">
                    <a href="enroll.aspx" id="zhuce">企业注册</a><br />
                </div> 
                <input type="button" value="登     陆"id="bt1" onclick="LoginYZ()"/>
                <a href="#" id="pwd">忘记密码？</a>
            </div>
                <div id="last">Copyright 1999-2011 云南工商学院 滇ICP备12002265号-1 云教ICP备1206028</div>

        </div>
    </div>
    </form>
</body>
</html>

