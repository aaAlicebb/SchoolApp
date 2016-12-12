using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;
using EmploymentBLL;

namespace EmployementUI
{
    /// <summary>
    /// AddResume 的摘要说明
    /// </summary>
    public class AddResume : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request.QueryString["mes"];
            if (Global.StuMes != null)
            {
                ResumeInfoBLL bll = new ResumeInfoBLL();
                string jlid = bll.slelectByStuIds(Global.StuMes.StuId);
                if (jlid != null)
                {
                    int count = bll.InsertMangerResume(name, jlid);
                    if (count > 0)
                    {
                        context.Response.Write("ok");
                    }
                    else
                    {
                        context.Response.Write("nohave");
                    }

                }
                else
                {
                    context.Response.Write("no");
                }

            }
            else
            {
                context.Response.Write("yh");
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