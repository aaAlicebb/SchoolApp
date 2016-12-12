using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementDAL;
using EmployementMODEL;

namespace EmploymentBLL
{
   public class TelentBLL
    {
       public List<telents> findtelent()
       {
           telentDAL telents = new telentDAL();
           List<telents> telents1 = telents.selectTelent();
           return telents1;
       }
       public List<telents> findtelents(string key)
       {
           telentDAL telents = new telentDAL();
           List<telents> telents2 = telents.selectTelents(key);
           return telents2;
       }
       public List<telents> findtelentByClass(string Class)
       {
           telentDAL telents = new telentDAL();
           List<telents> telents3 = telents.selectByClass(Class);
           return telents3;
       }
       public List<telents> findtelentByYear(string GraduateYear)
       {
           telentDAL telents = new telentDAL();
           List<telents> telents4 = telents.selectByYear(GraduateYear);
           return telents4;
       }
       public List<telents> introduce(string ReID)
       {
           telentDAL telents = new telentDAL();
           List<telents> telents5 = telents.Recommand(ReID);
           return telents5;
       }
       public List<telents>orderBy()
       {
           telentDAL telents = new telentDAL();
           List<telents> telents6 = telents.order();
           return telents6;
       }
       public List<telents> orderByRecommand()
       {
           telentDAL telents = new telentDAL();
           List<telents> telents7 = telents.orderByRecommand();
           return telents7;
       }
    }
}
