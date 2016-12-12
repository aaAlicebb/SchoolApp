<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebCompany.aspx.cs" Inherits="EmployementUI.WebCompany" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/cssWebStudent.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/StudentSelfMesJavaScript.js" type="text/javascript"></script>
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
        </script>
    
</head>
<body>  
    <form id="form1" runat="server">
    <div class="big">
        <div class="daohang">
                    <table class="daohangt" style="width:1000px" border="0">
                        <tr>
                            <td class="border"><a href="homepage.aspx">&nbsp;&nbsp;首页&nbsp;&nbsp;</a></td>
                            <td class="border"><a href="#">学生简历</a></td>
                            <td class="border"><a href="#">找工作&nbsp;&nbsp;</a></td>
                            <td class="border"><a href="#">找人才&nbsp;&nbsp;</a></td>
                            <td class="border"><a href="#">&nbsp;&nbsp;企业&nbsp;&nbsp;</a></td>
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
        <div class="middle">
            <div class="search">
                <input id="Textcompany" type="text" /><input id="Buttoncompany" type="button" value="搜索企业" />
                <table class="companys" style="width:950px">
                    <tr>
                        <td><span style="color:#808080;font-size:11pt">企业所属地>&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="color:#316de9;font-size:11pt">不限&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="font-size:11pt;color:black">广东&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  北京&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   上海&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;湖北&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;江苏&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;湖南&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;山东&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;浙江&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;陕西&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;四川&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;河南&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;江西</span></td>                       
                    </tr>                   
                </table>
            </div>
            <div class="companyall">
                <table style="width:650px;height:850px">
                    <tr class="companybox">
                        <td>
                            <div class="name"><a href="#">XXX软件公司</a></div>
                            <div class="companyjob"><a href="#">软件工程师</a></div>
                            <div class="companyplace"><a href="#">云南省昆明市西山区</a></div>
                        </td>                        
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    <tr class="companybox">
                        <td>&nbsp;</td>                       
                    </tr>
                    
                </table>

            </div>
            <div class="companypic"><img src="image/company.png" /></div>
        </div>
        <div style="display:none" id="goTopBtn"><img src="image/gotop.png" /></div>    
        <script type="text/javascript">goTopEx();</script>       
    </form>
</body>
</html>
