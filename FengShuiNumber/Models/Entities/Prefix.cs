using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models.Entities
{
    public class Prefix: BaseEntity
    {
        public virtual string Value { get; set; }
        public virtual Guid NetWorkId { get; set; }
        public virtual NetWorkProvider NetWork { get; set; }
    }
}
