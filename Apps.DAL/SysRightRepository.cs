﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apps.IDAL;
using Apps.Models;
using Apps.Models.Sys;
using System.Data.Entity;

namespace Apps.DAL
{
    public partial class SysRightRepository
    {
        public int UpdateRight(SysRightOperateModel model)
        {
            //转换
            SysRightOperate rightOperate = new SysRightOperate();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            //判断rightOperate是否存在，如果存在就更新rightOperate,否则就添加一条
            SysRightOperate right = Context.SysRightOperate.Where(a => a.Id == rightOperate.Id).FirstOrDefault();
                if (right != null)
                {
                    right.IsValid = rightOperate.IsValid;
                }
                else
                {
                    Context.SysRightOperate.Add(rightOperate);
                }
                if (Context.SaveChanges() > 0)
                {
                    //更新角色--模块的有效标志RightFlag
                    var sysRight = (from r in Context.SysRight
                                    where r.Id == rightOperate.RightId
                                    select r).First();
                    Context.P_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            return 0;
        }
        public int UpdateRoleModule(string Modules,string RoleId)
        {//此处传过来的只是选中的module值，将选中的赋予权限的同时，把其他模块和子操作的权限清除
            if (Context.P_Sys_UpdateSysRightRight0(Modules, RoleId) > 0)
            { return 1; }
            return 0;
        }
        //按选择的角色及模块加载模块的权限项
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> result = null;
            result = Context.P_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            return result;
        }

        //按角色加载模块
        public IQueryable<P_Sys_GetModuleByRole_Result> GetModuleByRoleId(string Id, string RoleId)
        {
            if (!string.IsNullOrEmpty(RoleId))
            {
                return Context.P_Sys_GetModuleByRole(Id,RoleId).AsQueryable();
            }
            return null;
        }
        /// <summary>
        /// 取角色模块的操作权限，用于权限控制
        /// </summary>
        /// <param name="accountid">acount Id</param>
        /// <param name="controller">url</param>
        /// <returns></returns>
        public List<permModel> GetPermission(string accountid, string controller) 
        {
                List<permModel> rights = (from r in Context.P_Sys_GetRightOperate(accountid, controller)
                                         select new permModel
                                         {
                                             KeyCode = r.KeyCode,
                                             IsValid = r.IsValid
                                         }).ToList();
                return rights;
            }
     
    }
}
