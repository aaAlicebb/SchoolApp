using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;
using EmploymentBLL;

namespace EmployementUI
{
    /// <summary>
    /// selfMesControl 的摘要说明
    /// </summary>
    public class selfMesControl : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             string tp = context.Request.QueryString["tp"];
             switch (tp)
             {
                 case"stuMesAlter": 
                     {
                         string mes = context.Request.QueryString["mes"];
                         string[] ass = mes.Split(',');
                         StuInfo stu = new StuInfo();
                         stu.stuName = ass[0];
                         stu.stuSex = ass[1];
                         stu.stuAge = int.Parse(ass[2]);
                         stu.stuGride =int.Parse(ass[3]);
                         stu.stuMajir = ass[4];
                         stu.stuEducation = ass[5];
                         stu.stuAddress = ass[6];
                         stu.stuID = Global.StuMes.StuId;
                         stuInfoBLL bll = new stuInfoBLL();
                         int result=bll.updateStuMes(stu);
                         if (result > 0)
                         {
                             context.Response.Write("OK");
                         }
                         else 
                         {
                             context.Response.Write("NO");
                         }
                         break;
                     }
                 case "TeaMesAlter":
                     {
                         string mes = context.Request.QueryString["mes"];
                         string[] ass = mes.Split(',');
                         TeaInfo tea = new TeaInfo();
                         tea.TeaName = ass[0];
                         tea.TeaSex = ass[1];
                         tea.TeaAge = int.Parse(ass[2]);
                         tea.TeaInstitute = ass[3];
                         tea.TeaPhone = ass[4];
                         tea.TeaAddress = ass[5];
                         tea.TeaId = Global.TeaMes.TeaId;
                         TeaInfoBLL bll = new TeaInfoBLL();
                         int result = bll.upDateTeaInfoMes(tea);
                         if (result > 0)
                         {
                             context.Response.Write("OK");
                         }
                         else
                         {
                             context.Response.Write("NO");
                         }
                         break;
                     }
                 case "ComMesAlter":
                     {
                         string mes = context.Request.QueryString["mes"];
                         string[] ass = mes.Split('*');
                         ComInfo com = new ComInfo();
                         com.ComName = ass[0];
                         com.ComType = ass[1];
                         com.ComPeople = ass[2];
                         com.ComJieS = ass[3];
                         com.ComTel = ass[4];
                         com.ComArea = ass[5];
                         com.ComId = Global.ComMes.ComId;
                         ComInfoBLL bll = new ComInfoBLL();
                         int result = bll.alterComInfo(com);
                         if (result > 0)
                         {
                             context.Response.Write("OK");
                         }
                         else
                         {
                             context.Response.Write("NO");
                         }
                         break;
                     }
                 case"stuLoginAlter":
                         {
                             string mes = context.Request.QueryString["pwd"];
                             string[] ass = mes.Split(',');
                             string ymm = ass[0];
                             string newpwd = ass[1];
                             LoginBLL bll = new LoginBLL();
                             StuLoginMes ms = new StuLoginMes();
                             ms = bll.StuLogn(Global.StuMes.StuId.ToString());
                             if (ms.StuPwd.Equals(ymm))
                             {
                                 ms.StuId = Global.StuMes.StuId;
                                 ms.StuPwd = newpwd;
                                 int result=bll.StuPwdAlter(ms);
                                 if (result > 0)
                                 {
                                     context.Response.Write("zq");
                                 }
                                 else 
                                 {
                                     context.Response.Write("cw");
                                 }
                                 
                             }
                             else 
                             {
                                 context.Response.Write("ymme");
                             }

                            break;
                         }
                 case "TeaLoginAlter":
                         {
                             string mes = context.Request.QueryString["pwd"];
                             string[] ass = mes.Split(',');
                             string ymm = ass[0];
                             string newpwd = ass[1];
                             LoginBLL bll = new LoginBLL();
                             TeaLoginMes ms = new TeaLoginMes();
                             ms = bll.TeaLogn(Global.TeaMes.TeaId.ToString());
                             if (ms.TeaId.Equals(ymm))
                             {
                                 ms.TeaId = Global.TeaMes.TeaId;
                                 ms.TeaId = newpwd;
                                 int result = bll.TeaPwdAlter(ms);
                                 if (result > 0)
                                 {
                                     context.Response.Write("zq");
                                 }
                                 else
                                 {
                                     context.Response.Write("cw");
                                 }

                             }
                             else
                             {
                                 context.Response.Write("ymme");
                             }

                             break;
                         }
                 case "comLoginAlter":
                         {
                             string mes = context.Request.QueryString["pwd"];
                             string[] ass = mes.Split(',');
                             string ymm = ass[0];
                             string newpwd = ass[1];
                             LoginBLL bll = new LoginBLL();
                             ComLoginMes ms = new ComLoginMes();
                             ms = bll.ComLogn(Global.ComMes.ComId.ToString());
                             if (ms.ComId.Equals(ymm))
                             {
                                 ms.ComId = Global.ComMes.ComId;
                                 ms.ComPwd = newpwd;
                                 int result = bll.ComPwdAlter(ms);
                                 if (result > 0)
                                 {
                                     context.Response.Write("zq");
                                 }
                                 else
                                 {
                                     context.Response.Write("cw");
                                 }

                             }
                             else
                             {
                                 context.Response.Write("ymme");
                             }

                             break;
                         }
             }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}