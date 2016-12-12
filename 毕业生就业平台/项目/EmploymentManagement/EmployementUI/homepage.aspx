<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="EmployementUI.homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link  href="css/homepage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/JavaScriptHome.js"></script>
    <script src="Scripts/jquery.min.js"></script>  
    <script type="text/javascript">
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
    <div id="big">
        <div id="daohang">
            <table>
            <tr>
                <td class="border"><a href="homepage.aspx">首页</a></td>
                <td class="border"><a href="#">学生简历</a></td>
                <td class="border"><a href="Default.aspx">找工作</a></td>
                <td class="border"><a href="findTelent.aspx">找人才</a></td>
                <td class="border"><a href="Default.aspx">企业</a></td>
                <td class="border"><a href="Job hunting.aspx">求职指南</a></td>
            </tr>
        </table> 
        </div>
        <div id="login" <%=dls %> ><a href="login.aspx">登 录</a></div>
        <div class="lanrenzhijia"  id="xialakuang" <%=xlk%>>
                <li>
                <a href="#">用户名&nbsp;▼</a>
                <div class="second">
                    <a href="#">通知</a>
                    <a href="homepage.aspx?click=selfClick">个人中心</a>
                    <a href="#">我的简历</a>
                    <a href="#">我的求职</a>
                    <a href="#">账户设置</a>
                    <a href="WebLogin.aspx">退出</a>
                    </div>
                </li>                
            </div>
         <div id="body">
            <div id="search"><input type="text" id="t1" /><input type="button" value="搜索" id="butt"/></div>
            <div id="resume">
                <span class="shai">晒简历求offer</span>
                    <a href="WebMyJianli.aspx?stuName=<%= list[0].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                 <span><%= list[0].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[0].stuMajor.ToString()%></span><br />
                                 <span>求职意向<%=list[0].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                     <a href="WebMyJianli.aspx?stuName=<%= list[1].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                 <span><%= list[1].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[1].stuMajor.ToString()%></span><br />
                                 <span>求职意向：<%= list[1].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                     <a href="WebMyJianli.aspx?stuName=<%= list[2].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                 <span><%= list[2].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[2].stuMajor.ToString()%></span><br />
                                 <span>求职意向：<%= list[2].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                     <a href="WebMyJianli.aspx?stuName=<%= list[3].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                <span><%= list[3].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[3].stuMajor.ToString()%></span><br />
                                 <span>求职意向：<%= list[3].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                     <a href="WebMyJianli.aspx?stuName=<%= list[4].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                <span><%= list[4].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[4].stuMajor.ToString()%></span><br />
                                 <span>求职意向：<%= list[4].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                     <a href="WebMyJianli.aspx?stuName=<%= list[5].Name.ToString()%>" >
                         <div class="resumeInfo">
                             <div class="spa">
                                 <span><%= list[5].Name.ToString()%></span><br />
                                 <span>云南工商学院</span><br />
                                 <span>专业：<%= list[5].stuMajor.ToString()%></span><br />
                                 <span>求职意向：<%= list[5].JobIntension.ToString()%></span><br />
                             </div>                           
                         </div>
                     </a>
                 </div>
             <div id="fair">
                 <span class="shai">校园招聘</span>
                 <div id="fair-a">
                     <div class="gallery cf">
                     <div class="Eninfo"><img src="image/job1.png" />
                     </div>
                     <div class="Eninfo"><img src="image/job2.png" />
                     </div>
                     <div class="Eninfo"><img src="image/job3.png" />
                     </div>
                     <div class="Eninfo"><img src="image/job4.png" />
                     </div>
                     <div class="Eninfo"><img src="image/job5.png" />
                     </div>
                     <div class="Eninfo"><img src="image/job6.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job7.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job8.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job9.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job10.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job11.jpg" />
                     </div>
                     <div class="Eninfo"><img src="image/job12.jpg" />
                     </div>
                         </div>
                 </div>
             </div>
             <div id="graduate">
                 <span class="shai">应届生专区</span>
                 <div id="graduate-a">
                        <div id="playBox">
                        <div class="pre"></div>
                        <div class="next"></div>
                        <div class="smalltitle">
                            <ul>
                                <li class="thistitle"></li>
                                <li></li>
                                <li></li>
                                <li></li>
                                <li></li>
                                <li></li>
                            </ul>
                        </div>
                        <ul class="oUlplay">
                            <li><a href="#" target="_blank">
                                <img src="image/home1.png" /></a></li>
                            <li><a href="#" target="_blank">
                                <img src="image/home2.png" /></a></li>
                            <li><a href="#" target="_blank">
                                <img src="image/home3.png" /></a></li>
                            <li><a href="#" target="_blank">
                                <img src="image/home4.png" /></a></li>
                            <li><a href="#" target="_blank">
                                <img src="image/home5.png" /></a></li>
                            <li><a href="#" target="_blank">
                                <img src="image/home6.png" /></a></li>
                        </ul>
                    </div>
                 </div>
             </div>
             <div id="fingerpost">
                 <span class="shai">求职指南</span>
                 <div id="fingerpost-a">
                     <div class="new">
                        <a href="http://cv.qiaobutang.com/knowledge/articles/557aae070cf247057f48ac37" target="_blank">职场新人如何安全度过试用期</a><br />
                        <a href="Job hunting.aspx" target="_blank">没工作经验，求职简历怎么写</a><br />
                        <a href="Job hunting.aspx" target="_blank">美术专业毕业可以从事哪些工作</a><br />
                        <a href="Job hunting.aspx" target="_blank">什么样的人适合做游戏策划</a><br />
                        <a href="Job hunting.aspx" target="_blank">找工作时，这些面试技巧你都会吗</a><br />
                        <a href="Job hunting.aspx" target="_blank">商务经理是做什么的</a><br />
                     </div>
                    <div class="new">
                        <a href="Job hunting.aspx" target="_blank">做财务需要掌握哪些技能</a><br />
                        <a href="Job hunting.aspx" target="_blank">如何写出一份有创意的简历</a><br />
                        <a href="Job hunting.aspx" target="_blank">解说企业面试流程方案</a><br />
                        <a href="Job hunting.aspx" target="_blank">2015年最新冷门专业就业前景分析</a><br />
                        <a href="Job hunting.aspx" target="_blank">求职信格式有什么需要注意的</a><br />
                        <a href="Job hunting.aspx" target="_blank">面试奇葩问题，采购助理的工作内容</a><br />
                    </div>
                     <div class="new">
                         <a href="Job hunting.aspx" target="_blank">护士转行做什么合适</a><br />
                         <a href="Job hunting.aspx" target="_blank">简历上如何推销自己</a><br />
                         <a href="Job hunting.aspx" target="_blank">校园招聘流程你知道多少</a><br />
                         <a href="Job hunting.aspx" target="_blank">需求分析师如何分析客户需求</a><br />
                         <a href="Job hunting.aspx" target="_blank">报考会计师资格证考试时应注意</a><br />
                        <a href="Job hunting.aspx" target="_blank">研发项目经理岗位职责</a><br />
                     </div>
                     <div id="new">
                         <a href="Job hunting.aspx" target="_blank">做仓库管理员日常工作</a><br />
                         <a href="Job hunting.aspx" target="_blank">面试必备基础知识</a><br />
                         <a href="Job hunting.aspx" target="_blank">面试奇葩问题</a><br />
                         <a href="Job hunting.aspx" target="_blank">程序员转型可以做什么</a><br />
                         <a href="Job hunting.aspx" target="_blank">学平面设计需要什么基础</a><br />
                         <a href="Job hunting.aspx" target="_blank">麻醉师的职责</a><br />
                     </div>
                 </div>
             </div>
             <div id="last">Copyright 1999-2011 云南工商学院 滇ICP备12002265号-1 云教ICP备1206028</div>
         </div>
    </div>
        <div style="display:none" id="goTopBtn"><img src="image/gotop.png" /></div>    
        <script type="text/javascript">goTopEx();</script>
    </form>
</body>
</html>
