using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementMODEL;
using SQLHelper;

namespace EmployementDAL
{
  public  class PresentDAL
    {
      SqlHelper db = new SqlHelper();
      public int Insert(companyInfo company)//发布招聘信息
      {
         // companyInfo company = new companyInfo();
          string comText ="insert into JobInfo(ComName,ComType,ComCity,ComTel,ComInfo,Compeople,FeedbackInfo,Composition,ComRemark,PositionInfo,uploadTime,PositionType,PositionAttribute,ComArea,LinkMan,Comnet,LookTimes,ComLognNum) values(@ComName,@ComType,@ComCity,@ComTel,@ComInfo,@Compeople,@FeedbackInfo,@Composition,@ComRemark,@PositionInfo,@uploadTime,@PositionType,@PositionAttribute,@ComArea,@LinkMan,@Comnet,@LookTime,@num)";
          string[] param = {"@ComName","@ComType","@ComCity","@ComTel","@ComInfo","@Compeople","@FeedbackInfo","@Composition","@ComRemark","@PositionInfo","@uploadTime","@PositionType","@PositionAttribute","@ComArea","@LinkMan","@Comnet","@LookTime","@num"};
          object[] values = {company.ComName,company.ComType,company.ComCity,company.ComTel,company.ComInfo,company.Compeople,"3000-5000",company.ComPosition,company.ComRemark,company.PositionInfo,DateTime.Now,company.PositionType,"全职",company.ComArea,company.LinkMan,company.Comnet,0,company.ComId};
          int row = db.ExecuteNoneQuery(comText, param, values);
          return row;
      }
    }
}
