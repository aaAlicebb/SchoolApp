using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;
using EmploymentBLL;
using SQLHelper;
using System.Web.SessionState;

namespace EmployementUI
{
    /// <summary>
    /// LoginControl 的摘要说明
    /// </summary>
    public class LoginControl : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string op = context.Request.QueryString["op"];
            switch (op)
            {
                case "Stu":
                    {
                        string userName = context.Request.QueryString["userName"].ToString();
                        string userPwd = context.Request.QueryString["userPwd"].ToString();
                        if (userName != null)
                        {
                            StuLoginMes user = new StuLoginMes();
                            user = Stumes(userName);
                            if (user != null)
                            {
                                if (userName ==user.StuId && userPwd == user.StuPwd)
                                {

                                    Global.StuMes = user;
                                    context.Session["index"] = "stu";
                                    context.Response.Write("yes");
                                }
                                else
                                {
                                    context.Response.Write("no");
                                }
                            }
                            else
                            {
                                context.Response.Write("noexis");
                            }

                        }
                        else
                        {
                            context.Response.Write("no");
                        }
                        break;
                    }
                case "Tea":
                    {
                        string userName = context.Request.QueryString["userName"];
                        string userPwd = context.Request.QueryString["userPwd"];
                        if (userName != null)
                        {
                            TeaLoginMes user = new TeaLoginMes();
                            user = Teames(userName);
                            if (user != null)
                            {
                                if (userName == user.TeaId && userPwd == user.TeaPwd)
                                {
                                    Global.TeaMes = user;
                                    context.Session["index"] = "tea";
                                    context.Response.Write("yes");
                                }
                                else
                                {
                                    context.Response.Write("no");
                                }
                            }
                            else
                            {
                                context.Response.Write("noexis");
                            }

                        }
                        else
                        {
                            context.Response.Write("no");
                        }
                        break;
                    }
                case "Emp":
                    {
                        string userName = context.Request.QueryString["userName"];
                        string userPwd = context.Request.QueryString["userPwd"];
                        if (userName != null)
                        {
                            ComLoginMes user = new ComLoginMes();
                            user = Commes(userName);
                            if (user != null)
                            {
                                if (userName == user.ComId && userPwd == user.ComPwd)
                                {
                                    Global.ComMes = user;
                                    context.Session["index"] = "emp";
                                    context.Response.Write("yes");
                                }
                                else
                                {
                                    context.Response.Write("no");
                                }
                            }
                            else
                            {
                                context.Response.Write("noexis");
                            }
                        }
                        else
                        {
                            context.Response.Write("no");
                        }
                        break;
                    }
                case "Sa":
                    {
                        string userName = context.Request.QueryString["userName"];
                        string userPwd = context.Request.QueryString["userPwd"];
                        if (userName != null)
                        {
                            SaLoginMes user = new SaLoginMes();
                            user = Sames(userName);
                            if (user != null)
                            {
                                if (userName == user.SaId && userPwd == user.SaPwd)
                                {
                                    Global.SsMes = user;
                                    context.Session["index"] = "sa";
                                    context.Response.Write("yes");
                                }
                                else
                                {
                                    context.Response.Write("no");
                                }
                            }
                            else
                            {
                                context.Response.Write("noexis");
                            }

                        }
                        else
                        {
                            context.Response.Write("no");
                        }
                        break;
                    }


            }
        }
        private StuLoginMes Stumes(string username)
        {
            LoginBLL bll = new LoginBLL();
            return bll.StuLogn(username);
        }
        private TeaLoginMes Teames(string username)
        {
            LoginBLL bll = new LoginBLL();
            return bll.TeaLogn(username);
        }
        private ComLoginMes Commes(string username)
        {
            LoginBLL bll = new LoginBLL();
            return bll.ComLogn(username);
        }
        private SaLoginMes Sames(string username)
        {
            LoginBLL bll = new LoginBLL();
            return bll.SaLogn(username);
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