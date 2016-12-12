using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployementMODEL;
using EmploymentBLL;

namespace EmployementUI
{
    /// <summary>
    /// CreateResumeControl 的摘要说明
    /// </summary>
    public class CreateResumeControl : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string tp = context.Request.QueryString["tp"];
            switch(tp)
            {
                case"stuRes": 
                    {
                        string mes = context.Request.QueryString["mes"];
                        char[] sz = {'#','*'};
                        string[] ass = mes.Split(sz);
                        stuInfoBLL bll = new stuInfoBLL();
                        StuInfo info = new StuInfo();
                        info = bll.selectByStuID(Global.StuMes.StuId);
                        ResumeInfo res = new ResumeInfo();
                        res.Name=ass[0];
                        res.ReSex=ass[1];
                        res.ReAddress = ass[2];
                        res.RePhone=ass[3];
                        res.ReEmail = ass[4];
                        res.RePolitical = ass[5];
                        res.GRJL = ass[6];
                        res.JYJL = ass[7];
                        res.JobIntension = ass[8];
                        res.SCJN = ass[9];
                        res.ZWJS = ass[10];
                        res.ReSetTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        res.IsPost = "是";
                        res.RequestPozision = "否";
                        res.stuMajor = info.stuMajir;
                        res.StuXH = Global.StuMes.StuId;
                        ResumeInfoBLL blls = new ResumeInfoBLL();
                        int count= blls.insertResume(res);
                        if (count > 0)
                        {
                            context.Response.Write("OK");
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