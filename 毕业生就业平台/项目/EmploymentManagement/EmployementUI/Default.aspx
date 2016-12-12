<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployementUI._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
    <link href="css/StyleSheet1.css" rel="Stylesheet" type="text/css"/>
    <meta http-equiv="refresh" content="20"/>
  <%-- <link href="qq.css" rel="Stylesheet" type="text/css"/>--%>
    <script src="Scripts/JavaScript1.js" type="text/javascript"></script>
      <script src="Scripts/JS2.js" type="text/javascript"></script>   
    <script type="text/javascript">
       
        $(function () {
            $(window).scroll(function () {
                if ($(window).scrollTop() > 100) {  //距顶部多少像素时，出现返回顶部按钮
                    $("#side-bar .gotop").fadeIn();
                }
                else {
                    $("#side-bar .gotop").hide();
                }
            });
            $("#side-bar .gotop").click(function () {
                $('html,body').animate({ 'scrollTop': 0 }, 500); //返回顶部动画 数值越小时间越短
            });
        });
    </script>  
     
    <style type="text/css">
        #Select1 {
            width: 329px;
            margin-left: 0px;
            top: 0px;
            left: 2px;
        }
        #Select2 {
            width: 329px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" method="post">
    <div id="header">    
    </div>
        <div class="pagecontent">
            <div class="head">
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
            <div class="left1">
               <ul>
                <li class="left3" id="left2" onclick=" changeleft()"><a href="#">企业直招</a></li>
                 <li class="left3" onclick="change()"><a href="#">精品职位</a></li>
                </ul> 
                <div id="Bhidden" class="box42"></div>
            </div>
                
                    <div class="search">
                        <input id="txtName" name="txtName"  type="text"class="search1"  value="请输入企业名称进行查找" onblur="if(this.value==''){this.value='请输入企业名称进行查找'" onfocus="if(this.value=='请输入企业名称进行查找'){this.value=''}"/>
                       <%--<input id="Button1" type="submit" class="select" value="找工作"  runat="server"/>--%>
                        <asp:Button ID="Button1" runat="server" Text="找工作" CssClass="select" OnClick="Button1_Click"/>
                    </div>
               </div>
                <div class="box3" id="B3">
                    <div class="left4">
                            <div class="left41">
                                 <asp:Label ID="Label1" CssClass="B3lable" runat="server" Text="职位分类"></asp:Label>
                                <input type="text" class="select1" id="ontrue" onclick="majo()"/> 
                         <div id="major" style="display:none">
                   <ul class="SeBox1" id="ss">
						<li><asp:LinkButton runat="server" OnClick="Click">不限</asp:LinkButton></li>
                       <li><a href="Default.aspx?id=电商" ondblclick="ontrue('电商')">电商</a></li>
                        <li><a runat="server" href="Default.aspx?id=影视戏剧" onclick="ontrue('影视戏剧')">影视戏剧</a></li>
                       <li><a href="Default.aspx?id=教师" ondblclick="ontrue('教师')">教师</a></li>
                       <li><a href='Default.aspx?id="医护"'ondblclick="ontrue('医护')" >医护</a></li>
                       <li><a href="Default.aspx?id=猎头"  onclick="ontrue('猎头')">猎头</a></li>
                       <li><a href="Default.aspx?id=音乐"  onclick="ontrue('音乐')">音乐</a></li>
                       <li><a href="Default.aspx?id=其他"  onclick="ontrue('其他')">其他</a></li>
                       <li><a href="Default.aspx?id=软件"  onclick="ontrue('软件')">软件</a></li>
                       <li><a href="Default.aspx?id=生物"  onclick="ontrue('生物')">生物</a></li>
                       <li><a href="Default.aspx?id=制药"  onclick="ontrue('制药')">制药</a></li>
                       <li><a href="Default.aspx?id=土木"  onclick="ontrue('土木')">土木</a></li>
                       <li><a href="Default.aspx?id=机械"  onclick="ontrue('机械')">机械</a></li>
                       <li><a href="Default.aspx?id=电气"  onclick="ontrue('电气')">电气</a></li>
                       <li><a href="Default.aspx?id=电子"  onclick="ontrue('电子')">电子</a></li>
                       <li><a href="Default.aspx?id=化工"  onclick="ontrue('化工')">化工</a></li>
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
                            <div class="left42">
                                 <asp:Label ID="Label2" CssClass="B3lable" runat="server" Text="职位性质"></asp:Label>
                                    <div class="left42a">
                                        <a  href="Default.aspx?name=全职&id=电商" runat="server" class="left42b">全职</a>
                                         <a href="Default.aspx?name=实习&id=影视戏剧" runat="server"  class="left42b">实习</a>
                                         <a href="Default.aspx?name=兼职&id=电商" runat="server" class="left42b">兼职</a>
                                    </div> 
                            </div>
                     </div>

                        <div class="B3work">     
                            <asp:Label ID="Label4" CssClass="B3lable" runat="server" Text="工作地点"></asp:Label>
                            <div class="B3city">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                  
                                </asp:DropDownList> 
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="select2" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                   
                                </asp:DropDownList> 
                                &nbsp;</div>
                        </div>         
                </div>
            
                <div class="box4" id="b4">
                    <div class="box41">
                       <a href="Default.aspx?Looktime=1" title="根据浏览次数显示">最热</a>
                       <a href="Default.aspx?time=1" title="根据最新日期显示">最新</a>
                    </div>
                </div> 
                <div class="box42" id="Bshow">  
                    
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                <ItemTemplate>
                                     <div class="box43">  
                        <div class="box43left">
                                    <p><a href="WebJobAbout.aspx?comname=<%# Eval("ComName")%>"class="com1"  ><%# Eval("ComName")%></a><span class="comSpan">[<%# Eval("ComCity")%>]</span></p> 
                                    <p class="salary"><a href="WebJobAbout.aspx?comname=<%# Eval("ComName")%>"><%# Eval("ComPosition")%></a></p>
                                    <p><%# Eval("ComType")%><span>/<%# Eval("Compeople")%>人</span></p>
                                    <p class="salary"><%# Eval("FeedbackInfo")%></p>
                                    <p><a href="WebJobAbout.aspx?comname=<%# Eval("ComName")%>" class="remark"><%# Eval("ComRemark")%></a></p>
                                     <input id="Hidden1" type="hidden"  value="<%# Eval("PositionType")%>"/>
                                     <input id="Hidden2" type="hidden"  value="<%# Eval("PositionAttribute")%>"/>
                                    <br/> <br/>
                        </div>
                        <div class="box43right">
                            <div class="box43_title">职位描述：
                                    <p style="color:#808080"><%# Eval("PositionInfo")%></p>         
                            </div>
                                <div class="box43_btn"><a href="#">投递简历</a></div>
                            <div class="box43_date">  
                                    <span class="box43_time"><%# Eval("uploadTime")%></span>
    						       <span><a href="WebJobAbout.aspx?comname=<%# Eval("ComName")%>" class="more1">查看更多»</a></span>
								</div>
                            </div>
                                 </div>         
                        </ItemTemplate>  
                    <FooterTemplate>  
                    <div style="margin-top:100px;text-align:center;position:relative; height:100px;">  
               共<asp:Label ID="lblpc" runat="server" Text="Label"></asp:Label>页 当前为第  
        <asp:Label ID="lblp" runat="server" Text="Label"></asp:Label>页  
        <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>  
        <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>  
        <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>  
        <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>  
         跳至第  
         <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged" >  
         </asp:DropDownList>页  
                        </FooterTemplate>  
                          </asp:Repeater> 
            </div>   
                   <div class="end">
                            <h4 style="float:left;position:relative;margin-top:-5px;">友情链接:</h4>
                            <ul class="endUl">
                                <li>
                                    <a href="http://www.eduei.com/ctbu/" target="_blank">重庆工商大学在职研究生</a>
                                </li>
                                <li>
                                <a href="http://www.yingmoo.com/lishui/" target="_blank">丽水户外广告</a>

                                </li>
                                <li><a href="http://www.hunt007.com/yangzhou/" target="_blank">扬州人才网</a></li>
                                <li><a href="http://www.xygmed.com/Oral/" target="_blank">口腔执业医师考试</a></li>
                                <li><a href="http://www.instrument.com.cn/job/" target="_blank">仪器人才网</a></li>
                                <li><a href="http://yuedu.mipang.com/fanwen/jianli/" target="_blank">个人简历范文</a></li>
                                <li><a href="/help/link" target="_blank">更多友情链接</a></li>
                            </ul>
                        </div>   
                                
   <%--<ul id="side-bar" class="side-pannel side-bar">
      <a href="javascript:;" class="gotop" style="display:none;"><s class="g-icon-top"></s></a>
      <a href="http://wpa.qq.com/msgrd?v=3&uin=123456789&site=qq&menu=yes" target="_blank" class="text"><s class="g-icon-qq1"></s><span>在线咨询</span></a>
      <a href="http://weibo.com/u/2556500765" target="_blank" class="text weibo"><s class="g-icon-weibo1"></s><span>微博</span></a>
      <a href="javascript:;" class="qr"><s class="g-icon-qr1"></s><i></i></a>
      <a href="http://koubei.baidu.com/s/lanrentuku.com" class="text survey" target="_blank"><s class="g-icon-survey1"></s><span>百度口碑</span></a>
</ul>          
            --%>        </div>
                 
    </form>
</body>
</html>
