using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmModel
{
    public class ComInfo
    {
         public int ComId { get; set; }
        public string ComName { get; set; }
        public string ComType { get; set; }
        public string ComArea { get; set; }
        public string ComTel { get; set; }
        public string ComInfos { get; set; }
        public string Compeople { get; set; }
        public string FeedbackInfo { get; set; }
        public string ComUser { get; set; }
        public string ComPwd { get; set; }
        public ComInfo() { }
        public ComInfo(int ComId, string ComName, string ComType, string ComArea, string ComTel, string ComInfos, string Compeople, string FeedbackInfo,string ComUser,string ComPwd)
        {
            this.ComId = ComId;
            this.ComName = ComName;
            this.ComType = ComType;
            this.ComArea = ComArea;
            this.ComTel = ComTel;
            this.ComInfos = ComInfos;
            this.Compeople = Compeople;
            this.FeedbackInfo = FeedbackInfo;
            this.ComUser = ComUser;
            this.ComPwd = ComPwd;
        }
  
    }
}
