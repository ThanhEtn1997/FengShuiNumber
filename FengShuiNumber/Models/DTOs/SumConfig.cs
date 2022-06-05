using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models.DTOs
{
    public class SumConfig
    {
        public virtual int First5DigitsSum { get; set; }
        public virtual int Last5DigitsSum { get; set; }
    }
}
