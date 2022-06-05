using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models.DTOs
{
    public class NetWorkConfig
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string[] Prefixies { get; set; }
    }
}
