using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Group9_006_iCAREAPP.Models
{
    public class ObjFile
    {

        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public string File { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }

    }
}