<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebLTE.aspx.cs" Inherits="EmployementUI.WebLTE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/cssWebStudent.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/StudentSelfMesJavaScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="big1">
        <div class="daohang">
            <table class="daohangt" style="width:1000px" border="0">
                        <tr>
                            <td class="border"><a href="homepage.aspx">首页</a></td>
                            <td class="border"><a href="#">学生简历</a></td>
                            <td class="border"><a href="#">找工作</a></td>
                            <td class="border"><a href="#">找人才</a></td>
                            <td class="border"><a href="#">企业</a></td>
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
            <div class="lunpic"></div>
            <div class="lunl">
                <table style="width:100px;height:40px">
                    <tr>
                        <td>看帖</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>                   
                </table>
            </div>
            <div class="tie">
        <div class="lunbiaot"><a href="#"><span style="font-size:11pt">论坛标题论坛标题论坛标题论坛标题</span></a></div>
            <input id="Buttonanser" type="button" value="回复" />
        <div class="lunevery">
            <div class="lunname">用户名</div>
            <div class="lunneir">我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容我的论坛内容</div>
            <div class="lunshij">2015-6-23 11:01</div>
        </div>
            <div class="lunevery">
            <div class="lunname">用户名</div>
            <div class="lunneir">我的回复我的回复我的回复我的回复</div>
            <div class="say"><input id="Buttonsay1" type="button" value="我也说一句" /></div>
            <div class="pingl">
                <input id="Text2" type="text" style="width:800px;height:40px" />  
                <input id="Buttonfa" type="button" value="发表" />
            </div>
            <div class="lunshij">2015-6-23 11:01</div>
        </div>
            <div class="lunevery">
            <div class="lunname">用户名</div>
            <div class="lunneir">我的回复我的回复我的回复我的回复我的回复我的回复我的回复我的回复</div>
            <div class="say"><input id="Buttonsay2" type="button" value="我也说一句" /></div>
            <div class="pingl">
                <input id="Text1" type="text" style="width:800px;height:40px" />  
                <input id="Buttonfab" type="button" value="发表" />
            </div>
            <div class="lunshij">2015-6-23 11:01</div>
        </div>
            <div class="huifu">
                <input id="Text8" type="text" style="width:800px;height:200px" />                 
            </div>
            <input id="Buttonfb" type="button" value="发表" style="width:80px;height:30px" /> 
    </div>
            </div>
    </div>
    </form>
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
     <div style="display:none" id="goTopBtn"><img src="image/gotop.png" /></div>    
        <script type="text/javascript">goTopEx();</script>  
</body>
</html>
