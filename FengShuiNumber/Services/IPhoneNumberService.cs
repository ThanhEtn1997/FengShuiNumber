using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FengShuiNumber.Services
{
    public interface IPhoneNumberService
    {
        Task<string> GetAllFengShuiNumberToDocx();
    }
}
