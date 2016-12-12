<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webadmin.aspx.cs" Inherits="EmployementUI.WebAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/JSadmin.js"></script>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="box">
            <div class="topbox">
                <span class="top">大学生就业管理系统</span>
                <div class="showbox">
                    <div class="me top1" id="top1" onclick="show(1);change(1)">用户管理</div>
                    <div class="me top2" id="top2" onclick="show(2);change(2);">教师信息</div>
                    <div class="me top3" id="top3" onclick="show(3);change(3);">学生信息</div>
                    <div class="me top4" id="top4" onclick="show(4);change(4);">企业信息</div>
                    <div class="me top5" id="top5" onclick="show(5);change(5);">招聘信息</div>
                    <div class="me top6" id="top6" onclick="show(6);change(6);">班级信息</div>
                    <div class="me admin">当前账户</div>
                </div>

            </div>
            <div class="middlebox">
                <div class="item" id="toleft">
                    <div class="item1">
                        <div class="qiehuan" id="change">+&nbsp &nbsp 用户管理</div>
                    </div>
                    <div class="item2" onclick="changestu();" id="item2">
                        学生管理
                    </div>
                    <div class="item3" onclick="changeem();" id="item3">
                        就业管理
                    </div>
                    <div class="item4" onclick="changetea();" id="item4">
                        教师管理
                    </div>
                    <div class="item5" onclick="changecom();" id="item5">
                        企业管理
                    </div>
                    <div class="item5" onclick="changeuser();" id="item6">
                        用户管理
                    </div>
                      <div class="item5" onclick="changeclass();" id="item7">
                        班级管理
                    </div>
                </div>
                <div class="suo" onclick="toleft();" id="kkleft">
                </div>
                <div class="tobig" onclick="toright();" id="kkright">
                </div>
                <div class="text" id="tobig">
                    <div class="wwitem">
                        <span style="padding-top: 10px; position: absolute;" id="showtext">网站主列表</span>
                    </div>
                    <div class="wwtext">
                        <div class="stuAdd">
                            <select name="xuan">  
                              <option value ="1">请选择条件</option>  
                              <option value ="2">学生姓名</option>  
                              <option value="3">学号</option>  
                              <option value="4">年龄</option>  
                            </select>
                            <input type="text" name="search" id="search" /><asp:Button ID="Button6" runat="server" Text="检索" OnClick="Button6_Click" style="height: 21px" /></div>
                        <div class="stuInfo" id="stuInfo">
                             <asp:UpdatePanel runat="server">
                               <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" ShowFooter="false" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="编号" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="学号" ItemStyle-CssClass="controlwidth120">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("stuID") %>' CssClass="controlwidth120"></asp:TextBox>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>

                                        <ItemStyle CssClass="controlwidth120"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码" ItemStyle-CssClass="controlwidth80">

                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("stuPwd") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名" ControlStyle-CssClass="controlwidth80">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("stuName") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("stuSex") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年龄">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("stuAge") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年级">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("stuGrade") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="专业" ControlStyle-CssClass="controlwidth120" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("stuMajor") %>' CssClass="controlwidth120"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox16" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth120"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="就业状态" ControlStyle-CssClass="controlwidth80">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("stuStatus") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox17" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="身份证号" ControlStyle-CssClass="controlwidth120">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("IDnumber") %>' CssClass="controlwidth120"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox18" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth120"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属班级" ControlStyle-CssClass="controlwidth80">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox19" runat="server" Text='<%# Eval("Class") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox20" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth80"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                        <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="添加">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button1" CommandName="Button1_Click" runat="server" Text="添加" OnClick="Button1_Click1" CssClass="footcolor" OnClientClick="return confirm('确认添加?');" />

                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#006699" Font-Bold="True" CssClass="footstyle"  />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                            </asp:GridView>
                            </ContentTemplate>
                                 </asp:UpdatePanel>
                        </div>
                        <div class="emInfo" id="emInfo">
                             <asp:UpdatePanel runat="server">
                               <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowEditing="GridView2_RowEditing" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating" ShowFooter="false" OnRowDataBound="GridView2_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="编号" />
                                    <asp:TemplateField HeaderText="学号" ItemStyle-CssClass="controlwidth">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("stuID") %>' CssClass="controlwidth120"></asp:TextBox>

                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>

                                        <ItemStyle CssClass="controlwidth"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">

                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("stuName") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司编号">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("ComID") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司名称">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("ComName") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="入职时间">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("Injobtime") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="工资">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("Wage") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="反馈信息">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("FeedbackInfo") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox17" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="反馈时间">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("Feedbacktime") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox18" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                        <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="添加">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button2" CommandName="Button2_Click" runat="server" Text="添加" OnClick="Button2_Click" OnClientClick="return confirm('确认添加?');" />

                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#006699" Font-Bold="True" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                            </asp:GridView>
                                   </ContentTemplate>
                                 </asp:UpdatePanel>
                        </div>
                        <div class="teaInfo" id="teaInfo">
                             <asp:UpdatePanel runat="server">
                               <ContentTemplate>
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowEditing="GridView3_RowEditing" OnRowCancelingEdit="GridView3_RowCancelingEdit" OnRowDeleting="GridView3_RowDeleting" OnRowUpdating="GridView3_RowUpdating" ShowFooter="false" OnRowDataBound="GridView3_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="编号" />
                                    <asp:TemplateField HeaderText="教师工号" ItemStyle-CssClass="controlwidth">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("TeaID") %>' CssClass="controlwidth120"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>


                                        <ItemStyle CssClass="controlwidth"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="姓名">

                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("TeaName") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("TeaPwd") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="性别">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("TeaSex") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="年龄">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("TeaAge") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="省份证号">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("IDnumber") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                        <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="添加">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="Button3" CommandName="Button3_Click" runat="server" Text="添加" OnClick="Button3_Click" OnClientClick="return confirm('确认添加?');" />

                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#006699" Font-Bold="True" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                            </asp:GridView>
                                   </ContentTemplate>
                                 </asp:UpdatePanel>
                        </div>

                        <div class="comInfo" id="comInfo">
                            <asp:UpdatePanel runat="server">
                               <ContentTemplate>
                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowEditing="GridView4_RowEditing" OnRowCancelingEdit="GridView4_RowCancelingEdit" OnRowDeleting="GridView4_RowDeleting" OnRowUpdating="GridView4_RowUpdating" ShowFooter="true" OnRowDataBound="GridView4_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="公司编号" ItemStyle-CssClass="controlwidth80">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("ComId") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>


                                        <ItemStyle CssClass="controlwidth80"></ItemStyle>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用户名" ControlStyle-CssClass="controlwidth120">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("ComUser") %>' CssClass="controlwidth120"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="controlwidth120"></asp:TextBox>
                                        </FooterTemplate>
                                        <ItemStyle CssClass="controlwidth120"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="密码">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("ComPwd") %>' CssClass="controlwidth80"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="controlwidth80"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司名称">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("ComName") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司类型">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("ComType") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="地址">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("ComArea") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox15" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="电话">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("ComTel") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox16" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司简介">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("ComInfos") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox17" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="公司规模">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("Compeople") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox18" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="反馈信息">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox19" runat="server" Text='<%# Eval("FeedbackInfo") %>' CssClass="controlwidth40"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox20" runat="server" CssClass="controlwidth40"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                        <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="添加">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                             <asp:Button ID="Button4" CommandName="Button4_Click" runat="server" Text="添加" OnClick="Button4_Click" OnClientClick="return confirm('确认添加?');"  />
                                                 
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#006699" Font-Bold="True" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                            </asp:GridView>
                            </ContentTemplate>
                             </asp:UpdatePanel>
                        </div>
                        <div class="classInfo" id="classInfo">
                            <asp:UpdatePanel runat="server">
                               <ContentTemplate>
                            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnRowEditing="GridView5_RowEditing" OnRowCancelingEdit="GridView5_RowCancelingEdit" OnRowDeleting="GridView5_RowDeleting" OnRowUpdating="GridView5_RowUpdating" ShowFooter="true" OnRowDataBound="GridView5_RowDataBound" OnPageIndexChanging="GridView5_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ID" HeaderText="编号" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="班级名称" ControlStyle-CssClass="controlwidth160">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("ClassName") %>' CssClass="controlwidth160"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox11" runat="server" CssClass="controlwidth160"></asp:TextBox>
                                        </FooterTemplate>
                                        <ControlStyle CssClass="controlwidth160" />
                                        <ItemStyle CssClass="controlwidth160"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="所属老师"  ControlStyle-CssClass="controlwidth160">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("ClassTeacher") %>' CssClass="controlwidth160"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="controlwidth160"></asp:TextBox>
                                        </FooterTemplate>
                                         <ControlStyle CssClass="controlwidth160" />
                                         <ItemStyle CssClass="controlwidth120"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="毕业年级"  ControlStyle-CssClass="controlwidth160">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("ClassGride") %>' CssClass="controlwidth160"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="controlwidth160"></asp:TextBox>
                                        </FooterTemplate>
                                        <ControlStyle CssClass="controlwidth160" />
                                        <ItemStyle CssClass="controlwidth160"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="班级专业"  ControlStyle-CssClass="controlwidth160">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("ClassMajor") %>' CssClass="controlwidth160"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="TextBox14" runat="server" CssClass="controlwidth160"></asp:TextBox>
                                        </FooterTemplate>
                                        <ControlStyle CssClass="controlwidth160" />
                                        <ItemStyle CssClass="controlwidth160"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="编辑" ShowEditButton="true" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>

                                        <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ControlStyle-Width="20px">
                                        <ControlStyle Width="20px"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="添加">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                             <asp:Button ID="Button5" CommandName="Button5_Click" runat="server" Text="添加" OnClick="Button5_Click" OnClientClick="return confirm('确认添加?');"  />
                                                 
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerTemplate>
                                    共<asp:Label ID="Label1" runat="server" Text="<%#callist.Count%>" />
                                    条记录 第<asp:Label ID="lblPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>" />
                                    页 共/<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>" />
                                    页 
                                    <asp:LinkButton ID="lbnFirst" runat="Server" CommandArgument="First" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Text="首页"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnPrev" runat="server" CommandArgument="Prev" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>" Text="上一页"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnNext" runat="Server" CommandArgument="Next" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>" Text="下一页"></asp:LinkButton>
                                    <asp:LinkButton ID="lbnLast" runat="Server" CommandArgument="Last" CommandName="Page" Enabled="<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>" Text="尾页"></asp:LinkButton>
                                    <asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>" Width="20px" />
                                    <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" />
                                </PagerTemplate>
                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                            </asp:GridView>
                            </ContentTemplate>
                             </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </div>
            <div class="bottombox">
            </div>
        </div>
    </form>
</body>

</html>
