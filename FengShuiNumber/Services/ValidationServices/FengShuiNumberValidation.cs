using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public class FengShuiNumberValidation : IFengShuiNumberValidation
    {
        private IList<IValidation> validations;
        public void AddRuleValidation(IValidation validation)
        {
            if (this.validations == null)
            {
                this.validations = new List<IValidation>();
            }

            this.validations.Add(validation);
        }

        public bool Validate(PhoneNumber phoneNumber)
        {
            if (this.validations == null || this.validations.Count == 0) return true;

            foreach(var validation in validations)
            {
                if(validation.Validate(phoneNumber)) continue;
                return false;
            }
            return true;
        }
    }
}
