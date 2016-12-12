using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.BLL
{
    public enum OpResult
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        yes,
        /// <summary>
        /// 记录存在
        /// </summary>
        exist,
        /// <summary>
        /// 操作失败
        /// </summary>
        no
    }
}
