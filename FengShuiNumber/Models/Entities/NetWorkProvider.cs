using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models.Entities
{
    public class NetWorkProvider : BaseEntity
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
    }
}
