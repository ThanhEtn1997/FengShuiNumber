using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    class Last2DigitsValidation : IValidation
    {
        public bool Validate(PhoneNumber phoneNumber)
        {
            var config = ReadConfig.GetFengShuiConfig();
            if (config == null) return true;

            var last2Digits = $"{phoneNumber.Number[phoneNumber.Number.Length - 2]}{phoneNumber.Number[phoneNumber.Number.Length - 1]}";

            return config.ValidLast2Numbers.Where(e => e == last2Digits).Count() > 0 ? true : false;

        }
    }
}
