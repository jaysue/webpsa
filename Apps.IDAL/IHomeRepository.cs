using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.Models;

namespace Apps.IDAL
{
    public interface IHomeRepository
    {
        IQueryable<P_Sys_GetModuleByUser_Result> GetMenuByPersonId(string personId, string moduleId);



    }
}
