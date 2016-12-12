<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resumeUp.aspx.cs" Inherits="EmployementUI.resumeUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的简历发布</title>
    <link  href="css/resumeUp.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery.min.js"></script>
    <script>
        $(function () {
            var lanrenzhijia = 1; // 默认值为0，二级菜单向下滑动显示；值为1，则二级菜单向上滑动显示
            if (lanrenzhijia == 1) {
                $('.lanrenzhijia li').hover(function () {
                    $('.second', this).css('top', '30px').show();
                }, function () {
                    $('.second', this).hide();
                });
            } else if (lanrenzhijia == 0) {
                $('.lanrenzhijia li').hover(function () {
                    $('.second', this).css('bottom', '30px').show();
                }, function () {
                    $('.second', this).hide();
                });
            }
        });
        function tpqh() {
            document.getElementById("txscs").style.display = "block";
        }
        function BtnSubmit()
        {
            var name = $("#RName").val();
            var sex = $("#RSex").val();
            var address = $("#RAddress").val();
            var phone = $("#RPhone").val();
            var Email = $("#REmail").val();
            var Political = $("#RPolitical").val();
            var GRJL = $("#RGRJL").val();
            var JYJL = $("#RJYJL").val();
            var QZYX = $("#RQZYX").val();
            var SCJN = $("#RSCJN").val();
            var selfJS = $("#dis").val();
            if(name!=""&& sex!="" && address!="" && phone!="" && Email!=""&& Political!="" && GRJL!="" && JYJL!="" && QZYX!="" && SCJN!="" && selfJS!="")
            {
               
                var AllMes = name + "*" + sex + "*" + address + "*" + phone + "*" + Email + "*" + Political + "*" + GRJL + "*" + JYJL + "*" + QZYX + "*" + SCJN + "*" + selfJS;
                alert(AllMes);
                var url = "CreateResumeControl.ashx?tp=stuRes&mes=" + AllMes;
                $.ajax(url)
                   .done(function (data) {
                       if (data == "OK") {
                           alert("成功");
                           window.location.href = "webStudentSelfMes.aspx";
                       }
                       else {
                           alert("失败，请联系管理员，电话~~~~~~~~~~~");
                       }
                   });
            }
            else
            {
                alert("请将信息填写完整");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="big">
        <div id="daohang">
            <table>   
            <tr>
                <td class="border"><a href="#">首页</a></td>
                <td class="border"><a href="#">学生简历</a></td>
                <td class="border"><a href="#">找工作</a></td>
                <td class="border"><a href="#">找人才</a></td><td class="border"><a href="#">企业</a></td>
                <td class="border1"><a href="#">求职指南</a></td>
            </tr>
        </table>
            <div class="lanrenzhijia">
                    <li>
                        <a href="#">用户名&nbsp;▼</a>
                        <div class="second">
                            <a href="#">通知</a>
                            <a href="#">个人中心</a>
                            <a href="#">我的简历</a>
                            <a href="#">我的求职</a>
                            <a href="#">账户设置</a>
                            <a href="#">退出</a>
                            </div>
                    </li>               
            </div>
        </div>
        <div id="body">
            <div class="center">
                <div id="photo" onclick="tpqh()"><img id="imgid" src="InterfacePhoto.aspx?hrid=<%=stuxh %>&type=stu" style="width:95px;height:140px;"/></div>
                <textarea id="dis" placeholder="自我简述"></textarea>
            </div>
            <div class="center" style="margin-top:20px;">
                <div id="infor">
                    <div class="aa">姓名：<br /><input type="text" id="RName" class="tt"/></div>
                    <div class="aa">性别：<br /><input type="text" id="RSex" class="tt"/></div>
                    <div class="aa">住址：<br /><input type="text" id="RAddress" class="tt" placeholder="xx省xx市xx区(县)"/></div>
                    <div class="aa">电话：<br /><input type="text" id="RPhone" class="tt"/></div>
                    <div class="aa">邮箱：<br /><input type="text" id="REmail" class="tt"/></div>
                    <div class="aa">政治面貌：<br /><input type="text" id="RPolitical" class="tt"/></div>
                </div>
            </div>
            <div class="center" style="margin-top:20px;height:800px;">
                <div class="bb">个人经历<br /><textarea id="RGRJL" class="tx"></textarea></div>
                <div class="bb">教育经历<br /><textarea id="RJYJL" class="tx"></textarea></div>
                <div class="bb">求职意向<br /><textarea id="RQZYX" class="tx" placeholder="10字以内"></textarea></div>
                <div class="bb">擅长技能<br /><textarea id="RSCJN" class="tx"></textarea></div>
            </div>
            <div id="last">
                <input type="button" value="保存" class="bt" onclick="BtnSubmit()" />&nbsp;&nbsp;&nbsp;<input type="button" value="取消" class="bt"/>
            </div>
        </div>
    </div>
    </form>
</body>
</html>