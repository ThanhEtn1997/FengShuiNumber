using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models.DTOs
{
    public class FengShuiConfig
    {
        public virtual int StringLength { get; set; }
        public virtual string[] ValidLast2Numbers { get; set; }
        public virtual string[] InValidLast2Numbers { get; set; }
        public virtual List<NetWorkConfig> NetWorks { get; set; }
        public virtual List<SumConfig> SumConditions { get; set; }
    }
}
