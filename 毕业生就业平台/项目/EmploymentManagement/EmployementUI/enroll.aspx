<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enroll.aspx.cs" Inherits="EmployementUI.enroll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link href="css/enroll.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        function BtnSubmit(){
            var userid = $("#UserId").val();
            var userpwd = $("#UserPwd").val();
            var userqpwd=  $("#UserQPwd").val();
            var name = $("#ComName").val();
            var typr = $("#ComType").val();
            var JieS = $("#ComJieS").val();
            var people = $("#ComPeople").val();
            var Phone = $("#ComPhone").val();
            var address = $("#ComAddress").val();
            if (userpwd != userqpwd) {
                alert("两次输入密码不一致");
            }
            else
            {
                if (userid == "" || name == "" || typr == "" || JieS == "" || people == "" || Phone == "" || address == "") {
                    alert("请将信息填写完整");
                }
                else
                {                   
                    var mes = name + "*" + typr + "*" + JieS + "*" + people + "*" + Phone + "*" + address;
                    var url = "enrollControl.ashx?tp=zhuce&mes=" + mes + "&userId=" + userid + "&userpwd=" + userpwd;
                    alert(url);
                    $.ajax(url)
                   .done(function (data) {
                       if (data == "OK") {
                           alert("成功");
                           window.location.href = "login.aspx";
                       }
                   else if (data == "NO") {
                       alert("失败");
                   }
                   else
                   {
                       alert("请联系管理员");
                   }
                    });
            }
        }
        }
        function TextExist(){
            var url = "enrollControl.ashx?tp=userId&mes=" + $("#UserId").val();
            $.ajax(url)
                .done(function (data) {
                    if (data == "OK") {
                        document.getElementById("Mes").style.display = "None";
                    }
                    else {
                        document.getElementById("Mes").style.display = "block";
                    }
                });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="big">
        <div id="hand">企业注册</div>
        <div id="body">
            <div id="infor">
                <div>账&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;户<input onblur="TextExist()" type="text" id="UserId" class="ts"/><a id="Mes" style="color:#ff0000;display:none;">*该账户已存在</a></div>
                <div>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码<input type="text"id="UserPwd" class="ts"/></div>
                <div>确认密码<input type="text" id="UserQPwd" class="ts"/></div>
                <div>公司名称<input type ="text" id="ComName" class="ts"/></div>
                <div>公司类型
                    <select class="tt" id="ComType">
                        <option>请选择</option>
                        <option>私有</option>
                        <option>国有</option>
                        <option>股份制</option>
                        <option>外企</option>
                        <option>中外合资</option>
                        <option>上市公司</option>
                        <option>事业单位</option>
                        <option>政府机关</option>
                        <option>个人企业</option>
                        <option>非营利机构</option>
                    </select>
                </div> 
                 <div>公司介绍<input type ="text" id="ComJieS" class="ts1"/></div>
                 <div>公司规模<input type ="text" class="ts" id="ComPeople" placeholder="人数：如500人"//></div>
                 <div>公司电话<input type ="text" class="ts" id="ComPhone"/></div>
                 <div>公司地址<input type ="text" class="ts" id="ComAddress" placeholder="详细地址，如一二一大街183号"/></div>   
            <div id="last">
                <input type="button" value="保存" onclick="BtnSubmit()" class="bt"/>&nbsp;&nbsp;&nbsp;<input type="button" value="取消" class="bt"/>
            </div>    
        </div>
            </div>
            <div id="last">Copyright 1999-2011 云南工商学院 滇ICP备12002265号-1 云教ICP备1206028</div>
    
    </div>
    </form>
</body>
</html>