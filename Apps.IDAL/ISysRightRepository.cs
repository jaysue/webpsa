using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.Models;
using Apps.Models.Sys;

namespace Apps.IDAL
{
    public partial interface ISysRightRepository
    {
        //更新
        int UpdateRight(SysRightOperateModel model);
        int UpdateRoleModule(string Modules, string RoleId);
        //按选择的角色及模块加载模块的权限项
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
        IQueryable<P_Sys_GetModuleByRole_Result> GetModuleByRoleId(string Id, string RoleId);
        List<permModel> GetPermission(string accountid, string controller);
    }
}
