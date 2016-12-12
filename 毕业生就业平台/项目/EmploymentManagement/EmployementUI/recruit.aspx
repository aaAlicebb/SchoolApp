<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recruit.aspx.cs" Inherits="EmployementUI.recruit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title>
    <link href="css/recruit.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function majo() {
            var op = document.getElementById("major").style;
            if (op.display == "block") {
                document.getElementById("major").style.display = "none";
            }
            else {
                document.getElementById("major").style.display = "block";
            }

        }
        function ontrue(id) {
            document.getElementById("ontrue").value = id;


        }
    </script>
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
    <form id="form1" runat="server" method="post">
      <div id="big">
        <div id="hand">发布招聘信息填写</div>
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
        <div id="body">
            <div id="infor">
                <div>公司身份<input type="radio"  name="radio" class="ta"/>公司直招<input type="radio"  name="radio"class="ta"/>职业代招</div>
                <div>公司名称<input type ="text" name="comName" class="ts"/></div>
                <div style="margin-left:-5px;">职位类型
                    <div id="major">
                    <ul>
                        <li><a href="#" ondblclick="ontrue('不限')">不限</a></li>
                       <li><a href="#" ondblclick="ontrue('电商')">电商</a></li>
                        <li><a href="#" onclick="ontrue('影视戏剧')">影视戏剧</a></li>
                       <li><a href="#" onclick="ontrue('教师')">教师</a></li>
                       <li><a href="#" onclick="ontrue('医护')" >医护</a></li>
                       <li><a href="#"  onclick="ontrue('猎头')">猎头</a></li>
                       <li><a href="#"  onclick="ontrue('音乐')">音乐</a></li>
                       <li><a href="#"  onclick="ontrue('其他')">其他</a></li>
                       <li><a href="#"  onclick="ontrue('软件')">软件</a></li>
                       <li><a href="#"  onclick="ontrue('生物')">生物</a></li>
                       <li><a href="#"  onclick="ontrue('制药')">制药</a></li>
                       <li><a href="#"  onclick="ontrue('土木')">土木</a></li>
                       <li><a href="#"  onclick="ontrue('机械')">机械</a></li>
                       <li><a href="#"  onclick="ontrue('电气')">电气</a></li>
                       <li><a href="#"  onclick="ontrue('电子')">电子</a></li>
                       <li><a href="#"  onclick="ontrue('化工')">化工</a></li>
                       <li><a href="#"  onclick="ontrue('材料')">材料</a></li>
                       <li><a href="#"  onclick="ontrue('保险')">保险</a></li>
                       <li><a href="#"  onclick="ontrue('证券')">证券</a></li>
                       <li><a href="#"  onclick="ontrue('银行')">银行</a></li>
                       <li><a href="#"  onclick="ontrue('会展')">会展</a></li>
                       <li><a href="#"  onclick="ontrue('外贸')">外贸</a></li>
                       <li><a href="#"  onclick="ontrue('通信（技术类）')">通信（技术类）</a></li>
                       <li><a href="#"  onclick="ontrue('行政文秘')">行政文秘</a></li>
                       <li><a href="#" onclick="ontrue('客服')" >客服</a></li>
                       <li><a href="#" onclick="ontrue('销售')">销售</a></li>
                       <li><a href="#" onclick="ontrue('记者/编辑')">记者/编辑</a></li>
                       <li><a href="#" onclick="ontrue('投行')">投行</a></li>
                       <li><a href="#" onclick="ontrue('律师助理/法务')">律师助理/法务</a></li>
                       <li><a href="#" onclick="ontrue('资讯')">咨询</a></li>
                       <li><a href="#" onclick="ontrue('物流')">物流</a></li>
                       <li><a href="#" onclick="ontrue('艺术设计')">艺术设计</a></li>
                       <li><a href="#" onclick="ontrue('财务')">财务</a></li>
                       <li><a href="#" onclick="ontrue('通用')">通用</a></li>
                       <li><a href="#" onclick="ontrue('人力资源')">人力资源</a></li>
                       <li><a href="#" onclick="ontrue('市场营销')">市场营销</a></li>
                    </ul>
                    </div>   
                    <input type ="text" name="PositionType" class="ts" id="ontrue" onclick="majo();"/>
                </div>
                <div>公司性质
                    <select class="tt" name="comType">
                        <option>请选择</option>
                        <option>私有</option>
                        <option>国有</option>
                        <option>股份制</option>
                        <option>外企</option>
                        <option>中外合资</option>
                        <option>上市公司</option>
                        <option>事业单位</option>
                        <option>政府机关</option>
                        <option>个人企业</option>
                        <option>非营利机构</option>
                    </select>
                </div>
                <div>公司规模
                    <select class="tt" name="scale">
                        <option>请选择</option>
                        <option>1-49</option>
                        <option>50-99</option>
                        <option>100-499</option>
                        <option>500-999</option>
                        <option>1000以上</option> 
                    </select>
                </div>
                <div >公司福利
                     
                    <input type="checkbox" name="btnRadio" value="五险一金"/> 五险一金 
                    <input type="checkbox" name="btnRadio" value="包吃"/> 包吃
                    <input type="checkbox" name="btnRadio" value="包住"/> 包住
                    <input type="checkbox" name="btnRadio" value="餐补"/> 餐补
                     <input type="checkbox" name="btnRadio" value="每周双休"/> 每周双休
                    <input type="checkbox" name="btnRadio" value="年底双薪"/> 年底双薪
                    <input type="checkbox" name="btnRadio" value="房补"/> 房补
                    <input type="checkbox" name="btnRadio" value="话补"/> 话补
                    <input type="checkbox" name="btnRadio" value="交补"/> 交补
                    <input type="checkbox" name="btnRadio" value=" 加班补"/> 加班补
                </div>
                <div>公司简介<textarea id="t6" cols="20" name="S1" rows="1"></textarea></div>
                <div>招聘职位<input type="text" class="ta" name="requestPosition"/></div>
                <div>招聘要求<input type ="text" class="tt" name="request"/></div>
                <div>联 系 人<input type ="text" class="tt" name="linkman"/></div>
                <div>招聘电话<input type ="text" class="ts" name="phone" /></div>
                <div>公司网址<input type ="text" class="ts" name="ComAddress"/>    
                    
                </div>
                <div>公司地址<input type ="text" class="ts" placeholder="详细地址，如一二一大街183号" name="net"/></div>
                <div>所在城市<input type ="text" class="ts" name="city"/></div>
            <div id="last">
                <input type="button" value="保存" runat="server" onserverclick="submits" class="bt"/>&nbsp;&nbsp;&nbsp;<input type="button" runat="server" value="取消" class="bt" onserverclick="disuse"/>
            </div>
        </div>           
    </div>
          </div>
    </form>
</body>
</html>