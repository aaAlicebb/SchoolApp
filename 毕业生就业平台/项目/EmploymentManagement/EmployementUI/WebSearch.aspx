<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSearch.aspx.cs" Inherits="EmployementUI.WebSearch" %>

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
    <div>
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
            <asp:DropDownList ID="DropDownListsearch" runat="server"></asp:DropDownList>
            <input id="Textsearch" type="text" />
            <asp:Button ID="Button1" runat="server" Text="搜索" />
            
        </div>
    </div>
        <div class="student">
            <table style="width:1000px;height:400px">
                <tr>
                    <td class="boxx"> 
                        <div class="name">
                    <a href="#" >高娟</a>
                    <div><input type="text" class="te1"/></div>
                </div> 
                <div class="infor">
                    <a href="#" >计算机软件</a><br />
                    <a href="#" >软件学院</a><br />
                    <a href="#" >求职：.net,java</a><br />
                </div>
                <div class="praise">
                    <a href="#">给TA加推</a>
                </div>
                    </td>
                    <td class="boxx">&nbsp;</td>
                    <td class="boxx">&nbsp;</td>
                </tr>
                <tr>
                    <td class="boxx">&nbsp;</td>
                    <td class="boxx">&nbsp;</td>
                    <td class="boxx">&nbsp;</td>
                </tr>
                
            </table>
        </div>
        <div class="job1">
            <table style="width:1000px;height:380px">
                <tr>
                    <td class="jobbox1">
                     <div class="name">
                    <a href="#" >软件工程师</a>                    
                </div> 
                <div class="praise">
                    <a href="#" >北京XX公司</a><br />                   
                </div>
                </td>
                    <td class="jobbox1">&nbsp;</td>
                    <td class="jobbox1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="jobbox1">&nbsp;</td>
                    <td class="jobbox1">&nbsp;</td>
                    <td class="jobbox1">&nbsp;</td>
                </tr>
                <tr>
                    <td class="jobbox1">&nbsp;</td>
                    <td class="jobbox1">&nbsp;</td>
                    <td class="jobbox1">&nbsp;</td>
                </tr>
            </table>
        </div>
        </div>
        <div style="display:none" id="goTopBtn"><img src="image/gotop.png" /></div>    
        <script type="text/javascript">goTopEx();</script>
    </form>
</body>
</html>
