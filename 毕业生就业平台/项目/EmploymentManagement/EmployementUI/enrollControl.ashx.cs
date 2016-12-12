using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;
using EmploymentBLL;

namespace EmployementUI
{
    /// <summary>
    /// enrollControl 的摘要说明
    /// </summary>
    public class enrollControl : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string tp = context.Request.QueryString["tp"];
            switch (tp)
            {
                case "userId":
                    {
                        string userid = context.Request.QueryString["mes"];
                        LoginBLL bll = new LoginBLL();
                        ComLoginMes mes = new ComLoginMes();
                        mes = bll.ComLogn(userid);
                        if (mes != null)
                        {
                            context.Response.Write("NO");
                        }
                        else
                        {
                            context.Response.Write("OK");
                        }
                        break;
                    }
                case "zhuce":
                    {
                        string userId = context.Request.QueryString["userId"];
                        string userPwd = context.Request.QueryString["userPwd"];
                        ComLoginMes lo = new ComLoginMes();
                        lo.ComId = userId;
                        lo.ComPwd = userPwd;
                        string mes = context.Request.QueryString["mes"];
                        char[] sz = { '#', '*' };
                        string[] ass = mes.Split(sz);
                        ComInfo com = new ComInfo();
                        com.ComName = ass[0];
                        com.ComType = ass[1];
                        com.ComJieS = ass[2];
                        com.ComPeople = ass[3];
                        com.ComTel = ass[4];
                        com.ComArea = ass[5];
                        com.ComId = userId;
                        ComInfoBLL bll = new ComInfoBLL();
                        int count = bll.InsertComInfo(com);
                        if (count > 0)
                        {
                            int re = bll.InsertComLogn(lo);
                            if (re > 0)
                            {
                                context.Response.Write("OK");
                            }
                            else
                            {
                                context.Response.Write("CW");
                            }
                        }
                        else
                        {
                            context.Response.Write("NO");
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