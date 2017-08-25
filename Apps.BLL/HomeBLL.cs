using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Apps.IBLL;
using Apps.Models;
using Apps.IDAL;
using Apps.Models.Sys;
using Apps.BLL.Core;
namespace Apps.BLL
{

    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        [Dependency]
        public ISysModuleBLL SysModuleBll { get; set; }
        public List<SysModuleModel> GetMenuByPersonId(string personId, string moduleId)
        {
            IQueryable<P_Sys_GetModuleByUser_Result> queryData=HomeRepository.GetMenuByPersonId(personId, moduleId);
            return CreateModelList(ref queryData, moduleId);
        }

        private List<SysModuleModel> CreateModelList(ref IQueryable<P_Sys_GetModuleByUser_Result> queryData,string moduleId)
        {
            List<SysModuleModel> list = SysModuleBll.GetList(moduleId);
            List<SysModuleModel> modelList = (from r in queryData
                                              join t in list on r.Id equals t.Id into UserModels where r.Rightflag == true
                                              from ur in UserModels.DefaultIfEmpty()
                                              select new SysModuleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  EnglishName = r.EnglishName,
                                                  ParentId = r.ParentId,
                                                  Url = r.Url,
                                                  Iconic = ur.Iconic,
                                                  Sort = ur.Sort,
                                                  Remark = ur.Remark,
                                                  Enable = r.Enable,
                                                  IsLast = r.IsLast,
                                                  Rightflag = r.Rightflag
                                              }).Distinct().OrderBy(ur => ur.Sort).ToList();
            return modelList;
        }
    }
}
