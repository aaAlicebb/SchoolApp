<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebJobAbout.aspx.cs" Inherits="EmployementUI.WebJobAbout" %>
<%@ Import Namespace="EmployementUI" %>
<%@ Import Namespace="EmployementMODEL" %>


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
        
        <div class="center">
            <div class="jobname" id="Position"><%=company1.ComPosition %></div>
            <div class="jobintroduce">
                <table style="width:800px;height:100px" cellspacing="0px" >
                    <tr>
                        <td class="jobin1" >单位名称</td>
                        <td ><%=company1.ComName %></td>
                        <td class="jobin1">工作地点</td>
                        <td><%=company1.ComName %></td>
                    </tr>
                    <tr>
                        <td class="jobin1">职位性质</td>
                        <td><%=company1.PositionAttribute%></td>
                        <td class="jobin1">职位分类</td>
                        <td id="positionType"><%=company1.PositionType%></td>
                    </tr>     
                    <tr>
                        <td class="jobin1">学历要求</td>
                        <td>大专</td>
                        <td class="jobin1">招聘专业</td>
                        <td>不限专业</td>
                    </tr>                                   
                </table>
            </div>
            <div class="jobmoney">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb"><span style="font-weight:bold">我能提供</span></td>                                              
                  </tr>                                           
                </table>
                <div class="jobmoney1">薪资：<span style="color:red">￥<%=company1.FeedbackInfo %>元/月</span></div>
                <div class="jobmoney2">福利待遇：<span style="color:#1485f2"> <%=company1.ComRemark %></span></div>
            </div>
            <div class="zhaopx">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb"><span style="font-weight:bold">招聘详情</span></td>                                              
                  </tr>                                           
                </table>
                <div class="zhaopx1">武汉正合天诚传媒有限公司急招电话销售，办公室兼职</div>
                <div class="zhaopx2">【工作内容】：负责电话联系客户，进行沟通洽谈！</div>  
                <div class="zhaopx3">【薪资待遇】：底薪2000+提成+业绩前三奖励+团队奖励+季度奖 5000不封顶</div>
                <div class="zhaopx4">【招聘要求】：<%=company1.PositionInfo%></div>   
                <div class="zhaopx5">【工作地点】：武汉市洪山区光谷资本大厦对面尖东智能花园4栋302室</div>               
            </div>
            <div class="companyx">
                <table style="width:800px;height:50px">
                  <tr>
                     <td class="borderb"><span style="font-weight:bold">公司信息</span></td>                                              
                  </tr>                                           
                </table>
                <div class="jobname1"><%=company1.ComName %></div>
                <div class="companyx1"><img src="image/xingzhi.png" />
                    <div class="companyx2">性质： <%=company1.ComType %></div>                   
                </div>
                <div class="companyx3"><img src="image/renshu.png" />
                    <div class="companyx4">规模:  <%=company1.Compeople %></div>
                </div>
                <div class="companyx5"><img src="image/jieshao.png" />
                    <div class="companyx6">介绍：</div>                   
                </div>
                <div class="companyx7"><span style="font-size:11pt"><%=company1.ComName %>有限公司</span></div>
                <div class="companjies"><span style="font-size:11pt"><%=company1.ComInfo %></span></div>
            </div>
            <div id="last">Copyright 1999-2011 云南工商学院 滇ICP备12002265号-1 云教ICP备1206028</div>
        
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
