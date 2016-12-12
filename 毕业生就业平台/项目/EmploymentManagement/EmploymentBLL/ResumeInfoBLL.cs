using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using EmployementDAL;
using System.Collections;

namespace EmploymentBLL
{
    public class ResumeInfoBLL
    {
        /// <summary>
        /// 取发布的简历前五条放到主界面。
        /// </summary>
        /// <returns></returns>
        public List<ResumeInfo> ResumeSelect()
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.ResumeSelect();
        }
        /// <summary>
        /// 通过学号查询我发布的简历
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResumeInfo seletByStuId(string id)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.selectByStuId(id);
        }
        /// <summary>
        /// 通过ID查询一批简历
        /// </summary>
        /// <returns></returns>
        public List<ResumeInfo> selectListById(string id)
        {
            List<ResumeInfo> list = new List<ResumeInfo>();
            ResumeOpera dal = new ResumeOpera();
            return dal.selectListById(id);
        }
        /// <summary>
        /// 通过姓名和学号删除简历
        /// </summary>
        /// <param name="times"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int deleteByNameAndTime(DateTime times, string name)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.deleteByNameAndTime(times, name);
        }

        /// <summary>
        /// 创建一个简历
        /// </summary>
        /// <returns></returns>
        public int insertResume(ResumeInfo res)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.insertResume(res);
        }
        /// <summary>
        /// 通过姓名查询
        /// </summary>
        /// <returns></returns>
        public ResumeInfo selectByStuName(string name)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.selectByStuName(name);
        }
        /// <summary>
        /// 通过公司名和简历id插入企业收藏表
        /// </summary>
        /// <param name="Comname"></param>
        /// <param name="JlId"></param>
        /// <returns></returns>
        public int InsertMangerResume(string Comname, string JlId)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.InsertMangerResume(Comname, JlId);
        }
        /// <summary>
        /// 取一条简历Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string slelectByStuIds(string id)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.slelectByStuIds(id);
        }
        /// <summary>
        /// 通过企业名查询信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ResumeManner> selectByComName(string name)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.selectByComName(name);
        }
        /// <summary>
        /// 通过简历编号查询
        /// </summary>
        /// <returns></returns>
        public ResumeInfo selectByRecID(string id)
        {
            ResumeOpera DAL = new ResumeOpera();
            return DAL.selectByRecID(id);
        }
        /// <summary>
        /// 删除企业简历管理表里的简历
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deltByRecIds(string id)
        {
            ResumeOpera dal = new ResumeOpera();
            return dal.deltByRecIds(id);
        }

    }
}
