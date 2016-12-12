<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saLogin.aspx.cs" Inherits="EmployementUI.enterprise" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/enterprise.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function LoginYz()
        {
            var url = "LoginControl.ashx?op=Sa&userName=" + $("#userName").val() + "&" + "userPwd=" + $("#password").val();
            $.ajax(url)
               .done(function (data) {
                   if (data == "yes") {
                       alert("ok");
                       window.location.href = 'WebAdmin.aspx';
                   }
                   else if (data == "no") {
                       alert("账号或密码有误");
                   }
                   else {
                       alert("账户不存在");
                   }
               });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="big">
        <span id="p2"><a>返回首页</a>&nbsp|&nbsp<a>帮助</a></span>
            <table>
                <tr>
                    <td ><a href="#">管理员</a></td>
                </tr>
         </table>
        <div id="title">
           <img src="image/123.jpg"/>
        </div>
        <div id="img">
            <img src="image/tu.jpg" />
        </div> 
        <div id="log">
             <span class="img">账户：</span><input type="text" id="userName" class="s1" placeholder="请输入账户"/><br />
             <span class="img">密码：</span><input type="password" id="password" class="s1" placeholder="请输入密码"/><br /><br /><br />
            <div>
                <input type="button" onclick="LoginYz()" value="登     陆"id="bt1"/>
            </div>  
        </div>
    </div>
    </form>
</body>
</html>
