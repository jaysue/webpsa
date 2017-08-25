using Apps.Common;
using Apps.Models;
using Apps.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.IBLL
{
   public partial interface ISysModuleRightBLL
    {

        IQueryable<P_Sys_GetModuleByUser_Result> GetModuleByUserId(string userId,string Id);
        IQueryable<P_Sys_GetRightByUserAndModule_Result> GetRightByUserAndModule(string UserId, string ModuleId);
        int UpdataOperateRight(SysModuleRightOperate model);
        int UpdateUserModule(string UserId,string  Modules);
    }
}
