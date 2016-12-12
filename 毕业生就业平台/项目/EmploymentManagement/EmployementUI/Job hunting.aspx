<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job hunting.aspx.cs" Inherits="EmployementUI.Job_hunting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/Job hunting.css" type="text/css" />
    <script type="text/javascript" src="Scripts/JavaScript job.js"></script>
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
    <div style="background-color:#f5f0f0;width:1350px" >
    <div class="to">
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
                    <div class="middle">       
                        <div class="daohang1">
                            <table class="daohang1t" style="width:1002px;height:45px" border="0">
                                <tr>
                                    <td id="m1"><a href="#" onclick="aa(1)">精选推荐</a></td>
                                    <td id="m2"><a href="#" onclick="aa(2)">行业解析</a></td>
                                    <td id="m3"><a href="#" onclick="aa(3)">求职专题</a></td>
                                    <td id="m4">
                                        <input id="Text1" type="text" style="width:200px; height:20px;"/><input id="Button1" type="button" value="搜索" style="width:40px; height:25px;" /></td>
                                </tr>
                            </table>

                        </div>
                        
                    </div>
                    <div id="s1">  
                            <div class="zo">
                                <div class="zo-xiao"></div>
                                <div class="zo2">
                                    <div class="zo2-totle">
                                        <div class="zo2-totle-zo">
                                            <img src="image/big.png"  width="400px" height="290px"/>
                                        </div>
                                        <div class="zo2-totle-yo">
                                            <table>
                                                <tr><td>&nbsp;</td></tr>
                                                <tr><td class="dz">程序员转型可以做什么</td></tr>
                                                <tr><td class="xz">程序员曾经是一个人人称羡享受高<img src="image/35.png" /></td></tr>
                                                <tr><td class="dz">找工作时，这些面试技巧你</td></tr>
                                                <tr><td class="xz">面试是每个求职者都要迈过的一道<img src="image/35.png" /></td></tr>
                                                <tr><td class="dz">求职信格式有什么要注意的</td></tr>
                                                <tr><td class="xz">求职信是求职者写给用人单位的信<img src="image/35.png" /></td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="zo2-x">
                                        <div class="bai"></div>
                                        <ul>
                                            <li id="hp">简历标题怎么写</li>
                                            <li id="hp">如何选择合适的模板？</li>
                                            <li id="hp">求职简历秘籍</li>
                                            <li id="hp">个人信息改写那些</li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="zo2">
                                    <div class="jp">
                                        <span class="left">简历排版</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="xp">
                                        <div class="jt">
                                            <div class="t"><img src="image/jlpb.png"  width="270px" height="165px"/></div>
                                            <div class="jp1">
                                                <table>
                                                    <tr><td class="dz">简历为什么要一页纸？</td></tr>
                                                    <tr><td class="wsm">
                                                            为什么要一页纸
                                                            无论是中文还是英文简历 ，都尽可能在一页纸里完成，给人简洁精干的感觉。
                                                            有过工作经验的人也许能够长篇累牍的描绘他们的...
                                                            <img src="image/21.png" />
                                                         </td></tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="wz">
                                            <table>
                                                <tr>
                                                    <td>
                                                         <span class="lef">细说英文简历排版</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">排版就像穿衣服，精致美观大方的排版绝对会给招聘官一个好印象。排版就是细节，细节决定成败，马虎</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">细说英文简历排版</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">排版就像穿衣服，精致美观大方的排版绝对会给招聘官一个好印象。排版就是细节，细节决定成败，马虎</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">细说英文简历排版</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">排版就像穿衣服，精致美观大方的排版绝对会给招聘官一个好印象。排版就是细节，细节决定成败，马虎</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="zo2">
                                    <div class="jp">
                                        <span class="left">求职杂说</span>
                                        <a  class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="xp">
                                        <div class="jt">
                                            <div class="t"><img src="image/qzzs.png"  width="270px" height="165px"/></div>
                                            <div class="jp1">
                                                <table>
                                                    <tr><td class="dz">求职简历制作秘笈</td></tr>
                                                    <tr><td class="wsm">
                                                            简历对于求职相当重要，十分重要！极度重要！无比重要！ 简历是网络招聘时代求职者与用人单位的
                                                            <img src="image/21.png" />
                                                         </td></tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="wz">
                                            <table>
                                                <tr>
                                                    <td>
                                                         <span class="lef">操盘手的岗位职责</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">通俗来说，操盘手就是为别人炒股的人。操盘手主要是为大户（投资机构）服务的，他们往往是交易员</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">舞台灯光师的岗位职责</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">舞台灯光师是利用各种专业灯具，根据不同演出艺术风格的需要，创作出各种“光影效果”，运用明暗</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">应聘空姐需要什么条件</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">空姐，泛指民航客机上从事旅客服务的女性工作人员，主要职责是在民航飞机上确保乘客旅途中的安全</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="zo2">
                                    <div class="jp">
                                        <span class="left">简历内容</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="xp">
                                        <div class="jt">
                                            <div class="t"><img src="image/big.png" width="270px" height="165px" /></div>
                                            <div class="jp1">
                                                <table>
                                                    <tr><td class="dz">好求职照应该是什么样子</td></tr>
                                                    <tr><td class="wsm">
                                                            HR通过 简历 求职照获得对你的第一印象。求职照不是选美比赛，但每个人都可以照出最有职业感的照
                                                            <img src="image/21.png" />
                                                         </td></tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="wz">
                                            <table>
                                                <tr>
                                                    <td>
                                                         <span class="lef">无经历如何写好一份简历</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">很多应届生求职的弱点，就在于缺乏工作经历，但是这也同时代表着，这样的求职者具有很强的可塑性。</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">简历不简单——如何让HR认定你为</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">乔布简历是2013年开始与王老师结缘的，“缘”于网上。13年秋天刚开学，王老师正风风火火帮助同学</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">常见证书误区 你入了几个？</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">最近的“资质作废”成为了话题热点，你是否也曾是忙碌的“考证一族”呢？其实，不管是你实际拥有</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="zo2">
                                    <div class="jp">
                                        <span class="left">简历投递</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="xp">
                                        <div class="jt">
                                            <div class="t"><img src="image/jltd.png" style="270px;height:165px" /></div>
                                            <div class="jp1">
                                                <table>
                                                    <tr><td class="dz">别告诉我你会用E-mail投简</td></tr>
                                                    <tr><td class="wsm">
                                                           Email投递简历究竟是用正文发送简历还是附件发送简历可能在一页纸里完成，给人简洁精干的感觉。
                                                            有过工作经验的人也许能够长篇累牍的描绘他们的...
                                                            <img src="image/21.png" />
                                                         </td></tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="wz">
                                            <table>
                                                <tr>
                                                    <td>
                                                         <span class="lef">网申初级指导</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">15年校园招聘已经拉开帷幕，几乎所有的国内外大企业都会通过网申进行第一轮的筛选。不想在第一</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">校园宣讲会 不只是赶过场</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">随着求职季的来临，校园中又开始出现了奔赴宣讲会的忙碌身影。如何在一波波的校园宣讲会中稳住</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">资深HR帮你找工作之：简历联络邮</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">小编废了九牛二虎之力，终于找到了网上红人“藤小曼”针对 简历 中联络邮箱的一些注意事项</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="zo2">
                                    <div class="jp">
                                        <span class="left">简历措辞</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="xp">
                                        <div class="jt">
                                            <div class="t"><img src="image/jlcc.png" style="width:270px;height:165px" /></div>
                                            <div class="jp1">
                                                <table>
                                                    <tr><td class="dz">怎么写好经历</td></tr>
                                                    <tr><td class="wsm">
                                                           具体 通过了简历 筛选，后续的面是英文简历 ，都尽可能在一页纸里完成，给人简洁精干的感觉。
                                                            有过工作经验的人也许能够长篇累牍的描绘他们的...
                                                            <img src="image/21.png" />
                                                         </td></tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="wz">
                                            <table>
                                                <tr>
                                                    <td>
                                                         <span class="lef">英文简历兴趣爱好写法指南</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">有这样一个真实的案例：某公司领导是多年的足球迷，公司也经常和其他公司进行足球比赛，但总是输</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">英文简历技能证书撰写技巧汇总</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">在制作英文简历的时候，哪些技能及证书是必备的？怎样写才会让面试官眼前一亮？如何地道的表达</td></tr>
                                                <tr>
                                                    <td>
                                                         <span class="lef">最易上手的英文简历经历写法指导</span>
                                                         <a class="rig"><img src="image/221.png" /></a>
                                                    </td>
                                                </tr>     
                                                <tr><td class="pp">中文简历的经历交给Google翻译，翻译出的东西有时令人笑cry！ 例如：销售中有个职责是打陌生电话</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="yo">
                                <div class="yo1">
                                    <div class="hymj">大家都在看的行业秘籍</div>
                                    <div>
                                        <ul>
                                            <li class="mj">电商</li>
                                            <li class="mj">影视</li>
                                            <li class="mj">教师</li>
                                            <li class="mj">医护</li>
                                            <li class="mj">猎头</li>
                                            <li class="mj">音乐</li>
                                            <li class="mj">其他</li>
                                            <li class="mj">软件</li>
                                            <li class="mj">生物</li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="yo2">
                                    <div class="ct1">
                                         <span class="left">精彩话题</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/t-1.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                            <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/bh.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">简历真的那么重要吗？？seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/89.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">最近好多同学都在找暑期实习seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/tx.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="yo1-p">
                                    <div class="yo1-s">视频指导</div>
                                    <div class="yo1-kong"></div>
                                    <div class="yo1-x"><img src="image/63203.png" width="250" height="160" /></div>
                                    <div class="yo1-kj"></div>
                                </div>
                            </div>
                    </div>
                    <div id="s2" class="hidden">
                          <div class="zo">
                              <div class="zo-xiao"></div>
                              <div class="zo31">
                                      <ul>
                                           <li class="h4">全部</li>
                                           <li class="h3">电商</li>
                                           <li class="h3">影视</li>
                                           <li class="h3">教师</li>
                                           <li class="h3">医护</li>
                                           <li class="h3">猎头</li>
                               
                                           <li class="h3">音乐</li>
                                           <li class="h3">其他</li>
                                           <li class="h3">软件</li>
                                           <li class="h3">生物</li>
                                           <li class="h3">制药</li>
                                           <li class="h3">土木</li>
                                   
                                           <li class="h3">机械</li>
                                           <li class="h3">电子</li>
                                           <li class="h3">化工</li>
                                           <li class="h3">地理</li>
                                           <li class="h3">政治</li>
                                           <li class="h3">科学</li>
                                 
                                           <li class="h3">航空</li>
                                           <li class="h3">海运</li>
                                           <li class="h3">空运</li>
                                           <li class="h3">管道</li>
                                           <li class="h3">机械</li>
                                           <li class="h3">化工</li>
                                   
                                           <li class="h3">英语</li>
                                           <li class="h3">记者</li>
                                           <li class="h3">探险</li>
                                           <li class="h3">建筑</li>
                                           <li class="h3">管理</li>
                                           <li class="h3">会计</li>
                                     
                                           <li class="h3">纺织</li>
                                           <li class="h3">生产</li>
                                           <li class="h3">保健</li>
                                           <li class="h3">娱乐</li>
                                           <li class="h3">影视</li>
                                           <li class="h3">执照</li>
                                  </ul>
                           </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/1.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">VC行业工作与收入</div>
                                         <div class="zo3-4">
                                          号外号外！VC行业从业人员的内部爆料，包括详细工作内容、收入、利益分配等详情，
                                          大家快来看啊！ 我是VC行业的一名投资经理，算基层员工。基金偏中早期投资，
                                          主要看互联网行业。单纯写一天的工作可能会有失偏颇，我直接把我过去的一周的日历写给你。 ...
                                          </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/2.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">                                     
                                         <div class="left5">HR是怎么看应届生的？！</div> 
                                         <div class="zo3-4">
                                             前网易HR，后离职创业，在大公司和小公司都有较长时间任职经历。
                                              以我这几年的从业经历来看，对每一个应届生还是要具体情况具体分析的。 
                                             （PS：每位HR考察应届生的出发点都不尽相同，声明一下：以下言论只代表我自己以及通过观察周边同事得出的结论...
                                         </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/3.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">猎头告诉你，他喜欢怎样的简历！</div>
                                      <div class="zo3-4">
                                          号外号外！VC行业从业人员的内部爆料，包括详细工作内容、收入、利益分配等详情，大家快来看啊！ 
                                          我是VC行业的一名投资经理，算基层员工。基金偏中早期投资，主要看互联网行业。单纯写一天的工作可能会有失偏颇，我直接把我过去的一周的日历写给你。 ...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/4.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                     <div class="left5">何为运营and如何运营</div>
                                      <div class="zo3-4">
                                          社区运营人员工作相当繁琐，毕竟互联网是个虚拟的，数字化的东西。运作到如火如荼的地步，相当不易。
                                          运营人员好比气功师父：“气溯如潮上，津流若酒醇”，气氛运营的好，社区方能澎湃！
                                          社区运营工作葳蕤繁杂，但修枝剪叶，分花拂柳，其实也有章可循，有法可...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/5.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">社区运营深度解析</div>
                                      <div class="zo3-4">
                                          社区运营人员工作相当繁琐，毕竟互联网是个虚拟的，数字化的东西。运作到如火如荼的地步，相当不易。
                                          运营人员好比气功师父：“气溯如潮上，津流若酒醇”，气氛运营的好，社区方能澎湃！
                                          社区运营工作葳蕤繁杂，但修枝剪叶，分花拂柳，其实也有章可循，有法可...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/6.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">HR是怎么看应届生的？！</div>
                                      <div class="zo3-4">
                                          社区运营人员工作相当繁琐，毕竟互联网是个虚拟的，数字化的东西。运作到如火如荼的地步，相当不易。
                                          运营人员好比气功师父：“气溯如潮上，津流若酒醇”，气氛运营的好，社区方能澎湃！
                                          社区运营工作葳蕤繁杂，但修枝剪叶，分花拂柳，其实也有章可循，有法可...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/7.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">客户经理的客户开发技巧</div>
                                      <div class="zo3-4">
                                          社区运营人员工作相当繁琐，毕竟互联网是个虚拟的，数字化的东西。运作到如火如荼的地步，相当不易。
                                          运营人员好比气功师父：“气溯如潮上，津流若酒醇”，气氛运营的好，社区方能澎湃！
                                          社区运营工作葳蕤繁杂，但修枝剪叶，分花拂柳，其实也有章可循，有法可...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/8.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">优秀的前端工程师</div>
                                      <div class="zo3-4">
                                          中小企业开发想要成功率高，最开始有两个数据要刷上去，一是单位时间内接触客户数量，
                                          二是成功接触客户有权人员数量，再后来才是贷款存款产品转化率问题。 
                                          在开发新客户的时候都会经过如下挣扎和思考： cold call ColdCall：虽然每天能...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/9.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">我为什么选择会计</div>
                                      <div class="zo3-4">
                                          Nicholas C. Zakas 谈怎样才能成为优秀的前端工程师： 昨天，我负责了Yahoo!公司组织的
                                          一次面试活动，感触颇深的是其中的应聘者提问环节。我得说自己对应聘者们提出的大多数
                                          问题都相当失望。我希望听到一些对在Yahoo！工作充...
                                      </div>
                                  </div>
                              </div>
                              <div class="zo3">
                                  <div class="zo3-1">
                                      <img src="image/7.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">
                                      <div class="left5">我的 Android学习之路</div>
                                      <div class="zo3-4">
                                          今天乔布简历小编准备分享的是网友stormzhang的Android自学历程，他曾写过一篇Android自学之路的博文，
                                          在网上被无数人转载（有兴趣的同学可百度）。不过，当他还在大学的时候，
                                          他还是一个什么都不懂得编程菜鸟，那他是如何学成的呢...
                                      </div>
                                  </div>
                              </div>
                          </div>
                        <div class="yo">
                            <div class="you3">
                                <div class="yo3-1">
                                        <span>大家都在申请的职位</span>
                                        
                                 </div>
                                <div class="yo3-2">
                                    <table>
                                        <tr><td class="lan">销售主管</br></td></tr>
                                        <tr><td class="hei">￥4000 - 6000/月</br></td></tr>
                                        <tr><td class="lan">销售实习生（包住+免费培训+晋升）</br></td></tr>
                                        <tr><td class="hei"> ￥3000 - 7000/月</br></td></tr>
                                        <tr><td class="lan">储备干部</br></td></tr>
                                        <tr><td class="hei">￥3000 - 7000/月</br></td></tr>
                                        <tr><td class="lan">省内出差员</br></td></tr>
                                        <tr><td class="hei">￥5000 - 7000/月</br></td></tr>                                   
                                    </table>          
                                </div>
                            </div>
                            <div class="yo3">
                                 <div class="ct1">
                                         <span class="left">精彩话题</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/t-1.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                            <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/bh.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">简历真的那么重要吗？？seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/89.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">最近好多同学都在找暑期实习seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/tx.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                            </div>
                            <div class="y3">
                                    <div class="y34">
                                         <span class="left">推荐模板</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                <div class="y35">
                                    <div class="q">
                                        <img src="image/w1.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w2.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w3.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w4.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="s3" class="hidden">
                             <div class="zo">
                                 <div class="zo-xiao"></div>
                               <div class="zo4">
                                   <div class="zo4-2"></div>
                                   <div class="zo4-1">
                                       <ul>
                                           <li id="b4">全部</li>
                                           <li id="b3">HR怪谈</li>
                                           <li id="b3">简历内容</li>
                                           <li id="b3">简历措辞</li>
                                           <li id="b3">简历投递</li>
                                           <li id="b3">简历排版</li>
                                           <li id="b3">求职杂说</li>
                                       </ul>
                                   </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s1.png" width="260px" height="170px" />
                                    </div>
                                    <div class="zo3-2">    
                                         <div class="left5">如何写出一份有创意的简历</div>
                                         <div class="zo3-4">
                                          求职中，个性突出、特征鲜明的创意简历更容易从众多简历中折射出光芒，吸引招聘官的目光，但在各种 简历模板 ，
                                             写作规则，注意事项前，许多求职者迷失了自我，简历失去了个性，
                                             把简历当成自我吹捧的抒情散文，过于专注自己取得的每一项成就，这些八股文的...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s2.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">求职简历上如何推销自己</div>
                                         <div class="zo3-4">
                                          制作简历是大学生走向职场的第一步，也是职场必修的一门课。虽然有众多的老师和书籍教大学生如何写 简历 ，
                                             但据了解，许多大学生其实并不知道什么样的简历才是适合自己的，
                                             怎样写简历才能把自己“秀”出来。本期乔布 简历 小编将为大家带来的主题就是如...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s3.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">面试必备的基本知识有哪些</div>
                                         <div class="zo3-4">
                                          面试是每一个求职者都会经历的一个过程，面试的表现会直接影响到我们是否能够获得这份工作。那么，
                                          面试有些怎样的必备基本知识呢？下面就跟随着乔布 简历 小编一起来了解一下吧~ 1、接到面试通知做好准备 
                                          当求职者接到公司的电话通知，一定要做好书面....
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s4.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">什么样的人适合做游戏策划</div>
                                         <div class="zo3-4">
                                         游戏策划是电子游戏开发团队中负责设计策划的人员，是游戏开发的核心。主要工作是编写游戏背景故事，制定游戏规则，
                                         设计游戏交互环节，计算游戏公式，以及整个游戏世界的一切细节等。 
                                         如今很多人都开始学习游戏策划，开始步入游戏开发行业，那么什么样的人...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s5.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">解说企业面试流程方案</div>
                                         <div class="zo3-4">
                                          求职者在找工作的过程中，都要经历面试的阶段，许多求职者都对未知的面试有恐惧心理，实际上面试也是有一个基本流程的。
                                          本期小编就将对基本的面试流程做一个总结，
                                          大家不妨先来了解一下~ 1、电话预约。面试以前一定要和去面试的公司电话沟...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s6.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">校园招聘流程你都知道多少</div>
                                         <div class="zo3-4">
                                          一直以来， 校园招聘 都是企业人才招聘的一个重要手段，也是应届毕业生寻找确定工作的一个主要途径。
                                          那么，对于校园招聘的流程，你都知道多少呢？
                                          本期小编将为大家科普的就是校园招聘的流程，小伙伴们快来了解一下吧~ 一般来说，企业进行...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s7.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">面试奇葩问题，你见过多少</div>
                                         <div class="zo3-4">
                                         对于所有在职场打拼的人士来说，几乎没有人可以避免在入职前参加面试。尽管我们都知道自己需要在面试前做足功课，
                                         但对于面试官有可能提出的问题我们根本无法预测，
                                         没有什么比在面试中遇到奇葩问题更糟糕了。 本期乔布 简历 小编为大家在各类奇葩面试题...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s8.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">没工作经验，求职简历怎么写</div>
                                         <div class="zo3-4">
                                          企业发布的职位信息中很多都要求求职者需要有或多或少的工作经验，这对于应届毕业生来说无疑是一大软肋。
                                          而缺乏工作经验也正是应届毕业生在撰写求职简历时最大的困难之一。
                                          面对一份份只是列举出了在校学习课程、自我个性评价、获得奖学金情况的求职简历，H...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s9.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">2015年最新冷门专业就业前景分析</div>
                                         <div class="zo3-4">
                                          冷门，指很少有人注意的或意料不到的事物。实际上，冷门专业和热门专业是相对的，随着就业市场的变化而变化。
                                          大学生入学时追求的热门专业，毕业时可能成了“鸡肋”。
                                          而大学生避而远之的冷门专业，最后却有可能变成了一只成就未来的“金饭碗”。本期乔布 ...
                                          </div>
                                  </div>
                               </div>
                               <div class="zo3">
                                    <div class="zo3-1">
                                      <img src="image/s10.png" width="260px" height="170px" />
                                  </div>
                                  <div class="zo3-2">    
                                         <div class="left5">需求分析师如何分析客户需求</div>
                                         <div class="zo3-4">
                                          需求分析师是作为技术与业务的连接点，对外沟通客户，了解客户的想法、要求、目的，转换为可以用软件实现的流程、方案、界面等。
                                          对内，提出软件的描述和要求，作为测试的依据。
                                          那么，需求分析师是如何分析客户需求的呢？感兴趣的小伙伴们下面就跟随着乔布...
                                          </div>
                                  </div>
                               </div>
                            </div>
                            <div class="yo">
                                <div class="yo3">
                                    <div class="ct1">
                                         <span class="left">精彩话题</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/t-1.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                            <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/bh.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">简历真的那么重要吗？？seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/89.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">最近好多同学都在找暑期实习seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="ct">
                                        <div class="ct2"><img src="image/tx.png" width="60" height="60"/></div>
                                        <div class="ct3">
                                             <table>
                                                <tr><td class="zit">创业导师Nardo带你从简历看职业生涯（简历点评+生涯分析）seanhui 2015-06-10 15:01:44</td></tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="yo3">
                                     <div class="y34">
                                         <span class="left">推荐话题</span>
                                        <a class="right" id="gb">MORE&gt;&gt;</a>
                                    </div>
                                <div class="y35">
                                    <div class="q">
                                        <img src="image/w1.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w2.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w3.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                    <div class="q">
                                        <img src="image/w4.png" / width="142" height="200">
                                        文职类实习岗位简历模板
                                        使用量58046
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div id="s4" class="hidden">
					    
                    </div>
                </div>
            </div>
            </div>
        </form>
    </div>
    <div class="wi">
        <div class="wi1">
            <table>
                <tr>
                    <td class="td">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;个人简历、简历模板、个人简历模板、个人简历表格，简历指导，各行业简历模板，个性化简历范文，让你轻松写出求职必胜的简历
                    </td>
                </tr>
            </table>
        </div>
        <div class="wi2">
            <div class="hm">
                <div class="left0">
                    <div>
                        <ul id="wi4">
                            <li id="wi3">帮助中心</li>
                            <li id="wi3">诚聘英才</li>
                            <li id="wi3">关于我们</li>
                            <li id="wi3">反馈与建议</li>
                            <li id="wi3">网站地图</li>
                            <li id="wi4">电脑版</li>
                             &nbsp;&nbsp;&nbsp;© 2015 All rights reserved. 下载:                          
                        </ul>
                    </div>
                </div>
                <div class="right00"></div>
                <div class="right0"> 
                    毕业生就业管理系统</br>
                    沪ICP备08114117号
                </div>
            </div>
        </div>
    </div>
</div>
</body>
</html>
