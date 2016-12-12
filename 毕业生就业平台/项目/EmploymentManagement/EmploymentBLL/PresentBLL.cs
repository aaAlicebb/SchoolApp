using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployementDAL;
using EmployementMODEL;
namespace EmploymentBLL
{
   public class PresentBLL
    {
       public int present(companyInfo companys1)
       { 
          PresentDAL comInfo = new PresentDAL();
          int coms = comInfo.Insert(companys1);
          return coms;
       }
    }
}
