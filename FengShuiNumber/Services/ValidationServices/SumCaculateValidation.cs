using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Services.ValidationServices
{
    public class SumCaculateValidation : IValidation
    {
        public bool Validate(PhoneNumber phoneNumber)
        {
            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return true;

            var num_len = phoneNumber.Number.Length;

            var sumFirst5Digits = CaculateSum(phoneNumber.Number, 0, 4);
            var sumLast5Digits = CaculateSum(phoneNumber.Number, num_len - 5, num_len - 1);

            foreach(var sumCondition in config.SumConditions)
            {
                if (sumFirst5Digits * sumCondition.Last5DigitsSum == sumLast5Digits * sumCondition.First5DigitsSum) 
                    break;
                else
                    return false;
            }

            return true;
        }

        private int CaculateSum(string num, int from, int to)
        {
            int sum = 0;

            if (from <= to) for (int i = from; i <= to; i++) sum += (num[i] - '0');
            else
                for (int i = to; i <= from; i++) sum += (num[i] - '0');

            return sum;
        }
    }

}
