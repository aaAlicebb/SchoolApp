<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findTelent.aspx.cs" Inherits="EmployementUI.findTelent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/research.css" type="text/css"  rel="stylesheet"/>
<script type="text/javascript" src="Scripts/jquery-1.7.1.min.js"></script> 
<script type="text/javascript" src="Scripts/JavaScript1.js"></script> 
<script type="text/javascript">
    $(function () {
        $('.input_test').bind({
            focus: function () {
                if (this.value == this.defaultValue) {
                    this.value = "";
                }
            },
            blur: function () {
                if (this.value == "") {
                    this.value = this.defaultValue;
                }
            }
        });
    })
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
        <div id="city">
            <input type="text" value="可搜索专业、学校、人名" name="keys"   class ="input_test" />
            <%--<input type="button"  value="搜索" id="butt" style="background-color:#0094ff;color:#ffffff"onclick="select()"/>--%>
              <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="butt" OnClick="select"/>
            <div class="demo">        
	            <div>
		            选择专业：<br />
		            <input type="text" class="homecity_name" id="ontrue" onclick="majo()" />
                    <div id="major" style="display:none">
                   <ul class="SeBox1" id="ss">
						<li><asp:LinkButton runat="server" OnClick="whatever">不限</asp:LinkButton></li>
                       <li><a href="findTelent.aspx?Major=计算机科学与技术">计算机科学与技术</a></li>
                        <li><a href="findTelent.aspx?Major=工商管理">工商管理</a></li>
                       <li><a href="findTelent.aspx?Major=会计" ondblclick="ontrue('会计')">会计</a></li>
                       <li><a href="findTelent.aspx?Major=机械制造及自动化"ondblclick="ontrue('机械制造及自动化')" >机械制造及自动化</a></li>
                       <li><a href="Default.aspx?Major=猎头"  onclick="ontrue('幼师')">幼师</a></li>
                       <li><a href="Default.aspx?Major=音乐"  onclick="ontrue('音乐')">音乐</a></li>
                       <li><a href="Default.aspx?Major=其他"  onclick="ontrue('其他')">其他</a></li>
                       <li><a href="Default.aspx?Major=软件"  onclick="ontrue('软件')">软件</a></li>
                       <li><a href="Default.aspx?Major=生物"  onclick="ontrue('生物')">生物</a></li>
                       <li><a href="Default.aspx?Major=制药"  onclick="ontrue('制药')">制药</a></li>
                       <li><a href="Default.aspx?Major=土木"  onclick="ontrue('土木')">土木</a></li>
                       <li><a href="Default.aspx?Major=机械"  onclick="ontrue('机械')">机械</a></li>
                       <li><a href="Default.aspx?Major=电气"  onclick="ontrue('电气')">电气</a></li>
                       <li><a href="Default.aspx?Major=电子"  onclick="ontrue('电子')">电子</a></li>
                       <li><a href="Default.aspx?Major=化工"  onclick="ontrue('化工')">化工</a></li>
                       <li><a href="Default.aspx?id=材料"  onclick="ontrue('材料')">材料</a></li>
                       <li><a href="Default.aspx?id=保险"  onclick="ontrue('保险')">保险</a></li>
                       <li><a href="Default.aspx?id=证券"  onclick="ontrue('证券')">证券</a></li>
                       <li><a href="Default.aspx?id=银行"  onclick="ontrue('银行')">银行</a></li>
                       <li><a href="Default.aspx?id=会展"  onclick="ontrue('会展')">会展</a></li>
                       <li><a href="Default.aspx?id=外贸"  onclick="ontrue('外贸')">外贸</a></li>
                       <li><a href="Default.aspx?id=通信（技术类）"  onclick="ontrue('通信（技术类）')">通信（技术类）</a></li>
                       <li><a href="Default.aspx?id=行政文秘"  onclick="ontrue('行政文秘')">行政文秘</a></li>
                       <li><a href="Default.aspx?id=客服" onclick="ontrue('客服')" >客服</a></li>
                       <li><a href="Default.aspx?id=销售" onclick="ontrue('销售')">销售</a></li>
                       <li><a href="Default.aspx?id=记者/编辑" onclick="ontrue('记者/编辑')">记者/编辑</a></li>
                       <li><a href="Default.aspx?id=投行" onclick="ontrue('投行')">投行</a></li>
                       <li><a href="Default.aspx?id=律师助理/法务" onclick="ontrue('律师助理/法务')">律师助理/法务</a></li>
                       <li><a href="Default.aspx?id=咨询" onclick="ontrue('资讯')">咨询</a></li>
                       <li><a href="Default.aspx?id=物流" onclick="ontrue('物流')">物流</a></li>
                       <li><a href="Default.aspx?id=艺术设计" onclick="ontrue('艺术设计')">艺术设计</a></li>
                       <li><a href="Default.aspx?id=财务" onclick="ontrue('财务')">财务</a></li>
                       <li><a href="Default.aspx?id=通用" onclick="ontrue('通用')">通用</a></li>
                       <li><a href="Default.aspx?id=人力资源" onclick="ontrue('人力资源')">人力资源</a></li>
                       <li><a href="Default.aspx?id=市场营销" onclick="ontrue('市场营销')">市场营销</a></li>
							</ul>
                    </div>  
		            
	            </div>	
	            <div>
		            毕业年份：<br />
		            <input type="text" value="" size="15" class="getcity_name" id="ontrue1" onclick="majo1()" />
                        <div id="major1" style="display:none">
                   <ul class="SeBox1" id="ss1">
						<li><asp:LinkButton runat="server" OnClick="whatever">不限</asp:LinkButton></li>
                       <li><a href="findTelent.aspx?Year=2010" >2010</a></li>
                        <li><a href="findTelent.aspx?Year=2012">2012</a></li>
                       <li><a href="findTelent.aspx?Year2013" >2013</a></li>
                       <li><a href="findTelent.aspx?Year=2014" >2014</a></li>
                        <li><a href="findTelent.aspx?Year=2015" >2015</a></li>
                       <li><a href="findTelent.aspx?Year=2016" >2016</a></li>
                       <li><a href="findTelent.aspx?Year=2017" >2017</a></li>
                        <li><a href="findTelent.aspx?Year=2018" >2018</a></li>
                       <li><a href="findTelent.aspx?Year=2019" >2019</a></li>
                       <li><a href="findTelent.aspx?Year=2020">2020</a></li>
							</ul>
                    </div>  
	            </div>
            </div>
        </div>
    
        <div id="sort">
            <a href="findTelent.aspx?date=1">最新</a>
            <a href="#">企业邀请</a>
            <a href="findTelent.aspx?recommand=1">加推数</a>
        </div>
        <div id="massg">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>
            <div class="box"> 
                <div class="name">
                    <a href="WebMyJianli.aspx?stuName=<%#Eval("StuName").ToString() %>" ><%#Eval("StuName").ToString() %></a>
                    <div class="photo">
                        <img src="InterfacePhoto.aspx?hrid=<%#Eval("StuId").ToString() %>&type=stu" style="width:100px;height:100px;"">
                    </div>
                </div>                
                <div class="infor">
                    <a href="WebMyJianli.aspx?stuName=<%#Eval("StuName") %>"><%#Eval("StuMajor") %></a><br />
                    <a href="WebMyJianli.aspx?stuName=<%#Eval("StuName") %>" style="color:#ff6a00; font-size:20px; font-weight:bold" ><%#Eval("School") %></a><br />
                    <a href="WebMyJianli.aspx?stuName=<%#Eval("StuName") %>" ><%#Eval("JobIntention") %></a><br />
                </div>
                <div class="praise"> 
                    <a href="findTelent.aspx?num=<%#Eval("RdID")%>">给TA加推</a>&nbsp&nbsp<a style="font-size:5px;color:#ff0000">历史加推数</a>(<%#Eval("LookTimes") %>)
                </div>
            </div>
                    </ItemTemplate>              
           <FooterTemplate>  
               <div style="margin-top:910px; margin-left:250px; text-align:center;position:absolute" >  
               共<asp:Label ID="lblpc" runat="server" Text="Label"></asp:Label>页 当前为第  
        <asp:Label ID="lblp" runat="server" Text="Label"></asp:Label>页  
        <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>  
        <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>  
        <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>  
        <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>  
         跳至第  
         <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged" >  
         </asp:DropDownList>页  
                   </div>  
             </FooterTemplate>  
       </asp:Repeater>
               </div> 
       </div>          
    </form>
</body>

</html>
