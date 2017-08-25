using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.Common;
using Apps.Models.Sys;

namespace Apps.IBLL
{
   public partial interface ISysRightBLL
    {
        int UpdateRight(SysRightOperateModel model);
        int UpdateRoleModule(string Modules, string RoleId);
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
        IQueryable<P_Sys_GetModuleByRole_Result> GetModuleListByRole(string Id, string RoleId);
    }
}
