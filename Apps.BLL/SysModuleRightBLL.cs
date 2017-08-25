using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.BLL.Core;
using Apps.IBLL;
using Microsoft.Practices.Unity;
using Apps.IDAL;
using Apps.Models.Sys;
using Apps.Common;
using Apps.Models;
using System.Transactions;
using Apps.Locale;

namespace Apps.BLL
{
  public partial   class SysModuleRightBLL
    {

        public IQueryable<P_Sys_GetModuleByUser_Result> GetModuleByUserId(string userId,string Id)
        {
            IQueryable<P_Sys_GetModuleByUser_Result> queryData = m_Rep.GetModuleByUserId(userId,Id) ;
            try
            {
          
                queryData = m_Rep.GetModuleByUserId(userId,Id);
            }
            catch (Exception ex)
            {//写入错误日志
            }
             return queryData;
  
        }
       public IQueryable<P_Sys_GetRightByUserAndModule_Result> GetRightByUserAndModule(string UserId, string ModuleId)
        {
            IQueryable<P_Sys_GetRightByUserAndModule_Result> queryData = m_Rep.GetRightByUserAndModule(UserId, ModuleId);
            try
            {

                queryData = m_Rep.GetRightByUserAndModule(UserId, ModuleId);
            }
            catch (Exception ex)
            {//写入错误日志
            }
            return queryData;
        }
        public int UpdataOperateRight(SysModuleRightOperate model)
        {
            return m_Rep.UpdataOperateRight(model);
        }
        public int UpdateUserModule(string UserId, string Modules)
        {//更新角色模块权限
            return m_Rep.UpdateUserModule(UserId, Modules);

        }
    }
}
