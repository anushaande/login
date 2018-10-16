using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrossWalk.Departmentclasses;

namespace CrossWalk.Models
{
    public class AllMethods
    {
        public List<FastDepartment> ListMethodsfast { get; set; }
        public List<GemsDepartment> ListMethodsgems { get; set; }
        public List<CodaDepartment> ListMethodscoda { get; set; }
        public List<EpicDepartment> ListMethodsepic { get; set; }
        public List<BannerDepartment> ListMethodsbanner { get; set; }
        public List<IdxDepartment> ListMethodsidx { get; set; }
        public List<OasisDepartment> ListMethodsoasis { get; set; }
        public List<SamasDepartment> ListMethodssamas { get; set; }

    }
}