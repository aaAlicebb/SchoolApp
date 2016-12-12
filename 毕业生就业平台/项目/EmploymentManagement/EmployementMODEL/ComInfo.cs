using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployementMODEL
{
    public class ComInfo
    {
        /// <summary>
        /// 公司账号
        /// </summary>
        public string ComId { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string ComName { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        public string ComType { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string ComArea { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string ComTel { get; set; }
        /// <summary>
        /// 公司介绍
        /// </summary>
        public string ComJieS { get; set; }
        /// <summary>
        /// 公司规模
        /// </summary>
        public string ComPeople { get; set; }
        public ComInfo() { }
        public ComInfo(string id, string name, string type, string area, string tel, string jieshao, string people)
        {
            this.ComId = id;
            this.ComName = name;
            this.ComType = type;
            this.ComArea = area;
            this.ComTel = tel;
            this.ComJieS = jieshao;
            this.ComPeople = people;
        }
    }
}
