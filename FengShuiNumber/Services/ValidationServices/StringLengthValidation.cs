using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public class StringLengthValidation : IValidation
    {
        public bool Validate(PhoneNumber phoneNumber)
        {
            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return true;

            if (phoneNumber == null || String.IsNullOrWhiteSpace(phoneNumber.Number)) return false;

            if (phoneNumber.Number.Length != config.StringLength) return false;

            return true;

        }
    }
}
