using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FengShuiNumber.Models.Entities
{
    public class PhoneNumber: BaseEntity
    {
        public virtual string Number { get; set; }
        public virtual Guid PrefixId { get; set; }
        public virtual Prefix Prefix { get; set; }
    }
}
