using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public interface IFengShuiNumberValidation
    {
        bool Validate(PhoneNumber phoneNumber);
        void AddRuleValidation(IValidation validation);
    }
}
