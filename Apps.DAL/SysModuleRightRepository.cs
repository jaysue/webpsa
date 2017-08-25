using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.IDAL;
using Apps.Models;
using System.Data;

namespace Apps.DAL
{
    public partial class SysModuleRightRepository
    {
        public IQueryable<P_Sys_GetModuleByUser_Result> GetModuleByUserId(string UserId,string Id)
        {//利用分布类可以扩展model,或者重新定义model或者用存储过程建立操作类model
            ////
            if (!string.IsNullOrEmpty(UserId))
            {
               // var a = Context.P_Sys_GetModuleByUser(UserId).ToList();
                return Context.P_Sys_GetModuleByUser(UserId,Id).AsQueryable();
            }
            return null;
           // return Context.SysModuleRight.Where(a => a.UserId == UserId);
        }
      public  IQueryable<P_Sys_GetRightByUserAndModule_Result> GetRightByUserAndModule(string UserId, string ModuleId)
        {
            if (!string.IsNullOrEmpty(UserId)&&!string.IsNullOrEmpty(ModuleId))
            {
                // var a = Context.P_Sys_GetModuleByUser(UserId).ToList();
                return Context.P_Sys_GetRightByUserAndModule(UserId, ModuleId).AsQueryable();
            }
            return null;
        }

        public int UpdataOperateRight(SysModuleRightOperate model)
        {
            //转换
            SysModuleRightOperate MrightOperate = new SysModuleRightOperate();
            MrightOperate.Id = model.Id;
            MrightOperate.RightId = model.RightId;
            MrightOperate.KeyCode = model.KeyCode;
            MrightOperate.IsValid = model.IsValid;
            MrightOperate.Name = model.Name;
            //判断rightOperate是否存在，如果存在就更新rightOperate,否则就添加一条
            SysModuleRightOperate right = Context.SysModuleRightOperate.Where(a => a.Id == MrightOperate.Id).FirstOrDefault();
            if (right != null)
            {
                right.IsValid = MrightOperate.IsValid;
            }
            else
            {
                Context.SysModuleRightOperate.Add(MrightOperate);
            }
            if (Context.SaveChanges() > 0)
            {
                //更新用户--模块的有效标志RightFlag
                var sysModuleRight = (from r in Context.SysModuleRight
                                where (r.UserId+r.ModuleId)== MrightOperate.RightId
                                select r).First();
                if (sysModuleRight !=null)
                {
                    Context.P_Sys_UpdateSysUserModuleRight(sysModuleRight.ModuleId, sysModuleRight.UserId);
                    return 1;
                }
              
            }
            return 0;
        }
        public int UpdateUserModule(string UserId, string Modules)
        {//更新角色模块权限
            if (Context.P_Sys_UpdateUserModuleRight(Modules, UserId) > 0)
            { return 1; }
            return 0;

        }
    }
}
