﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//	   生成时间 2012-12-11 22:12:11 by App
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using Apps.Common;
using Apps.Models.MIS;

namespace Apps.MIS.IBLL
{
    public partial interface IMIS_Article_CategoryBLL
    {

        List<MIS_Article_CategoryModel> GetList(string parentId);
        List<MIS_Article_CategoryModel> GetListByParentId(string id);
        
    }
}

