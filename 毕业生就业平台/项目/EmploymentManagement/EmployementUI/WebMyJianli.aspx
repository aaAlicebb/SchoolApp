<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMyJianli.aspx.cs" Inherits="EmployementUI.WebMyJianli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/JobAboutcss.css" type="text/css" />
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
        <div class="center1">
            <div class="myjinlititle"><span style="font-weight:bold;font-size:17pt"><%=res.Name %>-云南工商学院-<%=res.stuMajor %>-本科</span></div>
            <div class="myjianlizw">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb1"><span style="font-weight:bold">自我评价</span></td>                                              
                  </tr>                                           
                </table>
                <div class="myjlphoto"><img src="InterfacePhoto.aspx?hrid=<%=StuXh%>&type=stu" style="width:100px;height:100px;" /></div>
                    <div class="myjianlizwtab">
                        <table style="width:600px;height:140px" cellspacing="0px">
                            <tr>
                                <td style="background-color:#d9d4d4;text-align:left"><span style="font-size:15pt;font-weight:bold"><%=res.Name %></span></td>                            
                            </tr>
                             <tr>
                                <td style="text-align:left">☏&nbsp;联系方式：<%=res.RePhone %></td>
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;邮箱：<%=res.ReEmail %></td>                               
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;求职意向:<%=res.JobIntension %></td>
                            </tr>
                             <tr>
                                <td style="text-align:left">■&nbsp;<span style="font-size:10pt">擅长技能:<%=res.SCJN %></span></td>
                            </tr>
                        </table>
                                       
                </div>
            </div>
            <div class="edubc">
                 <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb1"><span style="font-weight:bold">教育背景</span></td>                                              
                  </tr>                                           
                </table>
                <div class="edutime"><span style="font-size:11pt">2011.09 - 2014.06</span></div>
                <div class="edutab">
                    <table style="width:600px;height:140px" cellspacing="0px">
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;学校：云南工商学院</td>                            
                            </tr>
                             <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;专业：<%=res.stuMajor %></td>
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;教育经历：<%=res.JYJL %></td>                               
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;专业课程：零售与连锁经营、连锁企业市场、营销基础管理素质训练、零售业消费者行为、连锁店开发与设计、连锁企业门店营运、电子商务、</td>
                            </tr>                        
                        </table>
                </div>               
            </div>
            <div class="ryjl">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb1"><span style="font-weight:bold">自我介绍</span></td>                                              
                  </tr>                                           
                </table>
                <div class="jlmx">
                    <table style="width:600px;height:110px" cellspacing="0px">
                        <tr>
                            <td style="text-align:left"><%=res.ZWJS %></td>                           
                        </tr>
                        
                    </table>
                </div>
                
            </div>
            <div class="zs">
                    <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb1"><span style="font-weight:bold">技能证书</span></td>                                              
                  </tr>                                           
                    </table>
                <div class="zsmx">
                    <table style="width:600px;height:110px" cellspacing="0px">
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;金蝶ERP认证证书</td>                            
                            </tr>
                             <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;英语三级考试</td>
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;ERP供应链应用师</td>                               
                            </tr>
                            <tr>
                                <td style="text-align:left">■&nbsp;&nbsp;全国计算机等级考试二级</td>
                            </tr>                        
                        </table>
                </div>
                </div>
            <div class="qzqw">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb1"><span style="font-weight:bold">求职期望</span></td>                                              
                  </tr>                                           
                    </table>
                <div class="qzqwtab">
                    <table style="width:600px;height:90px" cellspacing="0px">
                        <tr>
                            <td style="text-align:right">■&nbsp;&nbsp;期望工作地点：</td>
                            <td style="text-align:left">重庆-垫江，广东-中山，广东-广州</td>                           
                        </tr>
                        <tr>
                            <td style="text-align:right">■&nbsp;&nbsp;期望职位性质：</td>
                            <td style="text-align:left">全职</td>                           
                        </tr>
                        <tr>
                            <td style="text-align:right">■&nbsp;期&nbsp;望&nbsp;职&nbsp;位：</td>
                            <td style="text-align:left">行政文秘类-行政助理</td>                           
                        </tr>
                       
                    </table>
                </div>
            </div>
                 <div id="last1">Copyright 1999-2011 云南工商学院 滇ICP备12002265号-1 云教ICP备1206028</div>
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
