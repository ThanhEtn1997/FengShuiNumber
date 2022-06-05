using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public interface IValidation
    {
        bool Validate(PhoneNumber phoneNumber);
    }
}
