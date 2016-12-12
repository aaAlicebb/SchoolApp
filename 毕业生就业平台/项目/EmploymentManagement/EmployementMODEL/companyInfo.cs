using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
    public class companyInfo
    {
      public int ComId { get; set; }
      public  string ComName { get; set; }
      public   string ComType { get; set; }
      public   string ComArea { get; set; }
      public   string ComTel { get; set; }
      public   string ComInfo { get; set; }
      public   string Compeople { get; set; }
      public   string FeedbackInfo { get; set; }
      public   string ComPosition { get; set; }
      public   string PositionInfo { get; set; }
      public    string ComRemark { get; set; }
      public DateTime uploadTime { get; set; }
      public string PositionType { get; set; }
      public string PositionAttribute { get; set;}
      public string ComCity { get; set; }
      public int LookTime { get; set; }
      public string LinkMan{ get; set; }
      public string Comnet{ get; set; }
      public companyInfo() { }
      public companyInfo(string ComName, string ComType, string ComArea, string ComTel, string ComInfo, string Compeople, string FeedbackInfo, string ComPosition, string PositionInfo, string ComRemark, DateTime uploadTime, int ComId, string PositionType, string PositionAttribute,int LookTime,string ComCity,string LinkMan,string Comnet)
      {
          this.ComName = ComName;
          this.ComType = ComType;
          this.ComArea = ComArea;
          this.ComTel = ComTel;
          this.ComInfo = ComInfo;
          this.Compeople = Compeople;
          this.FeedbackInfo = FeedbackInfo;
          this.ComPosition = ComPosition;
          this.PositionInfo = PositionInfo;
          this.ComRemark = ComRemark;
          this.uploadTime = uploadTime;
          this.ComId = ComId;
          this.PositionType=PositionType;
          this.PositionAttribute = PositionAttribute;
          this.LookTime = LookTime;
          this.ComCity = ComCity;
          this.LinkMan = LinkMan;
          this.Comnet = Comnet;
      }
     
    }
}
    
 
