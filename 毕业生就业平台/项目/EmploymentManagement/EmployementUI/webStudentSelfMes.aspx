<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webStudentSelfMes.aspx.cs" Inherits="EmployementUI.webStudentSelfMes" %>
<%@ Import Namespace="EmployementMODEL" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/cssWebStudent.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/StudentSelfMesJavaScript.js" type="text/javascript"></script>
     <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
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
        function alterMesBTqd()
        {
            if ($("#Text1").val() != "" && $("#Text1y").val() != "" && $("#Text1m").val() != "" && $("#Text1ym").val() != "" && $("#Text3").val() != "" && $("#Text4").val() != "" && $("#Text5").val() && $("#Text2").val()!="") {
                var gs = $("#Text1").val() + "," + $("#Text1y").val() + "," + $("#Text1m").val() + "," + $("#Text1ym").val() + "," + $("#Text3").val() + "," + $("#Text4").val() + "," + $("#Text5").val();
                alert(gs.toString());
                var url = "selfMesControl.ashx?tp=stuMesAlter&mes=" + gs;
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
            else
            {
                alert("信息不能为空，请填写完整！");
            }
            
        }
        function alterLoginMes()
        {
            if ($("#txtYmm").val() != "" && $("#txtNewPwd").val() && $("#txtQePwd").val()) {
                if ($("#txtNewPwd").val() == $("#txtQePwd").val()) {
                    var mm = $("#txtYmm").val() + "," + $("#txtNewPwd").val() + "," + $("#txtQePwd").val();
                    var url = "selfMesControl.ashx?tp=stuLoginAlter&pwd=" + mm;
                    $.ajax(url)
                     .done(function (data) {
                         if (data == "zq") {
                             alert("密码更改成成功");
                         }
                         else if (data == "ymme") {
                             alert("原密码错误");
                         }
                         else if(data=="cw")
                         {
                             alert("密码更改失败，请联系管理员");
                         }
                         else
                         {
                             alert("未知的错误");
                         }
                     });
                }
                else
                {
                    alert("两次输入密码不相同，请重新输入");
                    document.getElementById("txtQePwd").value = "";
                }
            }
            else
            {
                alert("密码不能为空，请填写完整！");
            }
        }
        </script>
</head>
<body>   
    <div class="big">
        <form id="form1" runat="server">
           
            <div>
                <div class="daohang">
                    <table class="daohangt" style="width:1000px" border="0">
                        <tr>
                            <td class="border"><a href="homepage.aspx">首页</a></td>
                <td class="border"><a href="#">学生简历</a></td>
                <td class="border"><a href="Default.aspx">找工作</a></td>
                <td class="border"><a href="findTelent.aspx">找人才</a></td>
                <td class="border"><a href="Default.aspx">企业</a></td>
                <td class="border"><a href="Job hunting.aspx">求职指南</a></td>
                        </tr>
                    </table>
                        <div class="lanrenzhijia">
                <li>
                <a href="#">用户名&nbsp;<span style="font-size:8pt">▼</span> </a>
                <div class="second">
                    <a href="#">通知</a>
                    <a href="#">个人中心</a>
                    <a href="#">我的简历</a>
                    <a href="#">我的求职</a>
                    <a href="#">账户设置</a>
                    <a href="login.aspx">退出</a>
                   
                </div> </li>
            </div>

                    <div class="middle">
                        <div class="picture">
                            <div class="touxiang" onclick="tpqh()">
                         <img src="InterfacePhoto.aspx?hrid=<%=stu.stuID.ToString() %>&type=stu" style="width:100px;height:100px;" id="tp"/>
                            </div>
                            <div id="txsc">
                                <asp:FileUpload ID="FileUpload1" runat="server" Height="37px" Width="173px" />
                                <asp:Button ID="Button3" runat="server" Text="上传" OnClick="Button3_Click" />
                            </div>
                        </div>
                        <div class="daohang1">
                            <table class="daohang1t" style="width:1002px;height:45px" border="0">
                                <tr>
                                    <td id="m1" onclick="aa(1)"><a href="#">学生个人中心</a></td>
                                    <td id="m2" onclick="aa(2)"><a href="#">我的简历</a></td>
                                    <td id="m3" onclick="aa(3)"><a href="#">我的求职</a></td>
                                    <td id="m4" onclick="aa(4)"><a href="#">&nbsp;&nbsp;通知&nbsp;&nbsp;</a></td>
                                    <td id="m5" onclick="aa(5)"><a href="#">账户设置</a></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="s1">
                        <div class="mymes">
                            <table style="width:600px;height:50px">
                               <tr>
                                   <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;我投递的简历</span></td>                                              
                               </tr>                                           
                             </table>
                            <table style="width:600px;height:200px">
                <tr>
                    <td class="box"> 
                        <div class="name">
                    <a href="#" ><%=res.Name.ToString() %></a>
                    <div><input type="text" class="te1"/></div>
                </div> 
                <div class="infor">
                    <a href="#" >计算机软件</a><br />
                    <a href="#" ><%= res.stuMajor.ToString()%></a><br />
                    <a href="#" >求职：<%=res.JobIntension.ToString() %></a><br />
                </div>
                <div class="praise">
                    <a href="#">给TA加推</a>
                </div>
                    </td>
                    <td class="box1">
                        <div class="b1"><span style="color:#827e7e">您还没有投递过简历</span></div>
                        <div class="b2"><span style="color:#827e7e">现在就去投递</span><a href="#">投递</a></div>
                    </td>                                     
                </tr>
            </table>
                        </div>
                        <div class="jobget">
                             <table style="width:370px;height:50px">
                               <tr>
                                   <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;推荐的职位</span></td>                                              
                               </tr>                                           
                             </table>
                            <table style="width:350px;height:300px">
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
                </tr>                
            </table>
                        </div>
                    </div>
                    <div id="s2" class="hidden">
                        <div class="left1">
                            <div class="newj"><img src="image/newj.png" onclick="location='resumeUp.aspx'"/></div>
                            <div class="myj">
                                <table class="myjt" style="width:212px;height:180px">
                                    <tr>
                                        <td id="p1" onclick="cc(1)"><a href="#">&nbsp;创建的简历&nbsp;</a></td>                                      
                                    </tr>
                                    <tr>
                                        <td id="p2" onclick="cc(2)"><a href="#">&nbsp;收藏的模板&nbsp;</a></td>                                       
                                    </tr>
                                    <tr>
                                        <td id="p3" onclick="cc(3)"><a href="#">个人档案主页</a></td>                                     
                                    </tr>
                                </table>
                                <div id="u1">
                                    <div class="mynj1">
                                        <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;我创建的简历</span></td>                                                                                         
                                            </tr>                                           
                                        </table>
                                       
                                        <div class="mycjl1"> 
                                             <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="True">
            <ContentTemplate>                                  
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" PageIndex="1" >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="序号" InsertVisible="False">
                                                        <ItemTemplate> 
                                                        <%#Container.DataItemIndex+1%> 
                                                        </ItemTemplate> 
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Name" HeaderText="姓名" />
                                                    <asp:BoundField DataField="JobIntension" HeaderText="求职意向" />
                                                    <asp:BoundField DataField="stuMajor" HeaderText="专业" />
                                                    <asp:BoundField DataField="ReSetTime" HeaderText="发布时间" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                        <asp:Button runat="server" id="BtnDelete" OnClick="BtnDeletes" Text="删除" />
                                                         </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView> 
                                             </ContentTemplate>
        </asp:UpdatePanel>                                                   
                                        </div>                                                                                           
                                    </div>
                                </div>
                                <div id="u2" class="hidden">
                                    <div class="mynj">
                                        <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;我收藏的模板</span></td>                                              
                                            </tr>                                                                                    
                                        </table>
                                            <div class="mycjl">
                                                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                                            </div>                                            
                                    </div>
                                </div>
                                <div id="u3" class="hidden">
                                    <div class="mynj">
                                         <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;我的档案</span></td>                                              
                                            </tr>                                                                                    
                                        </table>
                                        <div class="datouxiang" onclick="tpqh()">
                                             <img src="InterfacePhoto.aspx?hrid=<%=stu.stuID.ToString() %>&type=stu" style="width:100px;height:100px;"/></div>
                                             <div class="dauser">李可豪</div>
                                             <div class="dabj"><img src="image/bjda.png" /></div>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="s3" class="hidden">
                        <div class="left2">
                            <div class="job"><img src="image/myj.png" /></div>
                            <div class="myj">
                             <table class="myjt" style="width:212px;height:180px">
                                    <tr>
                                        <td id="q1" onclick="ee(1)"><a href="#">&nbsp;已投递的职位&nbsp;</a></td>                                      
                                    </tr>
                                    <tr>
                                        <td id="q2" onclick="ee(2)"><a href="#">&nbsp;已收藏&nbsp;</a></td>                                       
                                    </tr>
                                    <tr>
                                        <td id="q3" onclick="ee(3)"><a href="#">推荐的职位</a></td>                                     
                                    </tr>
                                </table>
                                </div>
                       
                    </div>
                     <div id="w1">
                                    <div class="mynjob"></div>
                                </div>
                     <div id="w2" class="hidden">
                                    <div class="mynjob"></div>
                                </div>
                     <div id="w3" class="hidden">
                         
                                    <div class="mynjob">
                                        <table style="width:300px;height:40px">
                                            <tr>
                                                <td class="jobtd">来自企业</td>
                                                <td class="jobtd">来自老师</td>
                                            </tr>                                         
                                        </table>                                        
                                    </div>
                                </div>
                       
                     </div>
                    <div id="s4" class="hidden">
                        <div class="left2">
                            <div class="tz"><img src="image/tz.png" /></div>
                            <div class="myj">
                             <table class="myjt" style="width:212px;height:180px">
                                    <tr>
                                        <td id="v1" onclick="ff(1)"><a href="#">邀请推荐</a></td>                                      
                                    </tr>
                                    <tr>
                                        <td id="v2" onclick="ff(2)"><a href="#">求职反馈</a></td>                                       
                                    </tr>
                                    <tr>
                                        <td id="v3" onclick="ff(3)"><a href="#">社交中心</a></td>                                     
                                    </tr>
                                  <tr>
                                        <td id="v4" onclick="ff(4)"><a href="#">系统通知</a></td>                                     
                                    </tr>
                                </table>
                                </div>
                        </div>
                         <div id="r1">
                                    <div class="mynjob">
                                        <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;通知</span></td>                                              
                                            </tr>                                           
                                        </table>
                                    </div>
                                </div>
                     <div id="r2" class="hidden">
                                    <div class="mynjob">
                                         <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;通知</span></td>                                              
                                            </tr>                                           
                                        </table>
                                    </div>
                                </div>
                        <div id="r3" class="hidden">
                                    <div class="mynjob">
                                         <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;通知</span></td>                                              
                                            </tr>                                           
                                        </table>
                                    </div>
                                </div>
                     <div id="r4" class="hidden">
                                    <div class="mynjob">
                                        <table style="width:760px;height:50px">
                                            <tr>
                                                <td class="borderb"><span style="color:#0c50ae">&nbsp;&nbsp;通知</span></td>                                              
                                            </tr>                                           
                                        </table>
                                    </div>
                                </div>
                    </div>
                    <div id="s5" class="hidden">
                        <div>
                            <div class="left2">
                                <table class="user" style="width:150px;height:200px">
                                    <tr>
                                        <td id="n1" onclick="bb(1)"><a href="#">个人信息</a></td>
                                    </tr>
                                    <tr>
                                        <td id="n2" onclick="bb(2)"><a href="#">信息修改</a></td>
                                    </tr>
                                    <tr>
                                        <td id="n3" onclick="bb(3)"><a href="#">修改密码</a></td>
                                    </tr>
                                    <tr>
                                        <td id="n4" onclick="bb(4)"><a href="#">&nbsp;求职照&nbsp;</a></td>
                                    </tr>
                                </table>
                            </div>
                            <div id="x1">
                                <div class="userinfo">
                                   <div class="xinxi">
                                       <ul>
                                           <li>姓名:&nbsp;&nbsp;<a href="#"><%=stu.stuName.ToString() %></a></li>
                                           <li>性别:&nbsp;&nbsp;<a href="#"><%=stu.stuSex.ToString() %></a></li>
                                           <li>年龄:&nbsp;&nbsp;<a href="#"><%=stu.stuAge.ToString() %></a></li>
                                           <li>年级:&nbsp;&nbsp;<a href="#"><%=stu.stuGride.ToString() %></a></li>
                                            <li>学校:&nbsp;&nbsp;<a href="#">云南工商学院</a></li>
                                            <li>专业:&nbsp;&nbsp;<a href="#"><%=stu.stuMajir.ToString() %></a></li>
                                            <li>学历:&nbsp;&nbsp;<a href="#"><%=stu.stuEducation.ToString() %></a></li>
                                            <li>地址:&nbsp;&nbsp;<a href="#"><%=stu.stuAddress.ToString() %></a></li>
                                       </ul>
                                       <ul>
                                           <li><input id="Buttonxiugai" type="button" value="修改" />&nbsp;&nbsp;&nbsp;&nbsp;<input id="Buttonquxiao" type="button" value="取消" /></li>
                                       </ul>
                                   </div>
                                </div>
                            </div>
                            <div id="x2" class="hidden">
                                <div class="userinfo">
                                    <table style="width:600px;height:500px">
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>姓名</td>
                                            <td>
                                                <input class="t11" id="Text1" type="text" value="<%=stu.stuName.ToString() %>" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>性别</td>
                                            <td>
                                                <input class="t11" id="Text1y" type="text" value="<%=stu.stuSex.ToString() %>"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>年龄</td>
                                             <td>
                                                <input class="t11" id="Text1m" type="text" value="<%=stu.stuAge.ToString() %>"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>年级</td>
                                             <td>
                                                <input class="t11" id="Text1ym" type="text" value="<%=stu.stuGride.ToString() %>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>学校</td>
                                            <td>
                                                <input class="t11" id="Text2" type="text" value="云南工商学院"/></td>
                                            </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>专业</td>
                                            <td>
                                                <input class="t11" id="Text3" type="text" value="<%=stu.stuMajir.ToString() %>" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t1">学历</td>
                                            <td>
                                                <input class="t11" id="Text4" type="text" value="<%=stu.stuEducation.ToString() %>" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t1">地址</td>
                                            <td>
                                                <input class="t11" id="Text5" type="text" value="<%=stu.stuAddress.ToString() %>" /></td>
                                        </tr>
                                        <tr class="t33">
                                            <td class="t3">
                                                <input id="Buttonyes" type="button" value="确定" onclick="alterMesBTqd()" /></td>
                                            <td class="t3">
                                                <input id="Buttonno" type="button" value="取消" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="x3" class="hidden">
                                <div class="userinfo">
                                    <table class="userinfot1" style="width:500px;height:300px">
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>当前密码</td>
                                            <td>
                                                <input class="t11" id="txtYmm" type="password" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>新密码</td>
                                            <td>
                                                <input class="t11" id="txtNewPwd" type="password" /></td>
                                        </tr>
                                        <tr>
                                            <td class="t1"><span style="color: red">*</span>确认密码</td>
                                            <td>
                                                <input class="t11" id="txtQePwd" type="password" /></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <input id="Buttonpwd" type="button" value="修改密码" onclick="alterLoginMes()"/></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="x4" class="hidden">
                                <div class="userinfo">
                                    <table class="zzhaopian" style="width:400px;height:200px">
                                        <tr>
                                            <td><span style="color: red">*</span>添加照片</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 
                                                  <asp:FileUpload ID="FileUpload2" runat="server" Height="37px" Width="173px" />
                                            </td> 
                                                               
                                        </tr>
                                        <tr>
                                            <td>为什么上传求职照：</td>
                                        </tr>
                                        <tr>
                                            <td>1、上传正式的求职照，体现你的职场专业度</td>
                                        </tr>
                                         <tr>
                                            <td>2、晒简历，HR更青睐信息完善的求职者。</td>
                                        </tr>
                                        <tr>
                                            <td>                                               
                                                 <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="photosf"><img src="image/photo1.png" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div> 
            <div style="display:none" id="goTopBtn"><img src="image/gotop.png" /></div>    
            <script type="text/javascript">goTopEx();</script>
        </form>
    </div>
    <script type="text/javascript">
        document.getElementById("s1").style.display = "block"; //内容的样式
        document.getElementById("m1").className = "c_" + 1 + " c_1"; //头部的样式
    </script>
</body>
</html>
