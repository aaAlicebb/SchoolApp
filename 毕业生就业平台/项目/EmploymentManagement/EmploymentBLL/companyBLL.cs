using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using EmployementDAL;
using System.Data;
using System.Collections;


namespace EmploymentBLL
{
    public class companyBLL
    {
        public List<companyInfo> ComInfo()
        {
            comPanyDAL companyDao = new comPanyDAL();
            List<companyInfo> compaies = companyDao.selectComInfo();
            return compaies;
        }
        public List<companyInfo> ComInfoByName(string comName)
        {
            comPanyDAL companyDao = new comPanyDAL();
            List<companyInfo> compaies = companyDao.selectComInfoByName(comName);
            return compaies;
        }
        public List<province> ProInfo()
        {
            comPanyDAL ProDAL = new comPanyDAL();
            List<province> pro1 = ProDAL.selectPrvinceByName();
            return pro1;
        }
        public List<province> cityInfo(int index)
        {
            comPanyDAL ProDAL = new comPanyDAL();
            List<province> pro = ProDAL.selectCity(index);
            return pro;
        }
        public List<companyInfo> selectComInfoByPositionType(string  PositionType)
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com1 = company.selectComInfoByPositionType(PositionType);
            return com1;
        }
        public List<companyInfo> selectComInfoByPosition(string Job)
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com2 = company.selectComInfoByPosition(Job);
            return com2;
        }
        public List<companyInfo> selectComInfoByTime()
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com3 = company.selectComInfoByTime();
            return com3;   
        }
        public List<companyInfo> Looktime()
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com4 = company.selectComInfoByLookTime();
            return com4;
        }
        public List<companyInfo> AddLooktime(string ComName)
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com5 = company.Times(ComName);
            return com5;
        }
        public List<companyInfo> workplace(string ComCity)
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com8 = company.selectComInfoByCity(ComCity);
            return com8;
        }
        /// <summary>
        /// 通过账号显示招聘信息
        /// </summary>
        /// <param name="comid"></param>
        /// <returns></returns>
        public List<companyInfo> selectComInfoById(string comid)//通过企业账号显示企业招聘信息
        {
            comPanyDAL company = new comPanyDAL();
            List<companyInfo> com5 = company.selectComInfoById(comid);
            return com5;
        }
        /// <summary>
        /// 通过名称和时间招聘信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uptime"></param>
        /// <returns></returns>
        public int DeleteByTimeAndName(string name, DateTime uptime)
        {
            comPanyDAL bll = new comPanyDAL();
            return bll.DeleteByTimeAndName(name,uptime);
        }
    }
}
