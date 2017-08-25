using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Models.Sys
{
    public partial  class SysModuleRightModel
    {

        [Display(Name = "ID")]
        public override string Id { get; set; }
        public  string Name { get; set; }
        public  string EnglishName { get; set; }
        public  string ParentId { get; set; }
        public string Url { get; set; }
        public bool Enable { get; set; }
        public bool IsLast { get; set; }
        public override bool Rightflag { get; set; }
        public string RoleId { get; set; }
        public string RightId { get; set; }
        public string state { get; set; }//treegrid
        //[JsonProperty(PropertyName = "checked", NullValueHandling = NullValueHandling.Ignore)]
        //public bool? Checked { get; set; }
    }
}
