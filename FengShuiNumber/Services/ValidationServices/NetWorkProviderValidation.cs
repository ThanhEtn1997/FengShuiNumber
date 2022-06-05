using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public class NetWorkProviderValidation : IValidation
    {
        public bool Validate(PhoneNumber phoneNumber)
        {
            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return true;

            var prefix = $"{phoneNumber.Number[0]}{phoneNumber.Number[1]}{phoneNumber.Number[2]}";

            if (config.NetWorks.Where(e => e.Code == phoneNumber.Prefix.NetWork.Code).Count() == 0) return false;
            if(config.NetWorks.Where(e => e.Prefixies.Contains(prefix)).Count() == 0) return false;

            return true;
        }
    }
}
