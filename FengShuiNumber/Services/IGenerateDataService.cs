using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FengShuiNumber.Services
{
    public interface IGenerateDataService
    {
        public Task<bool> GenerateData(int phoneSize);
        public Task<bool> GenerateFengShuiPhoneNumber(int size);
        public Task<string> WriteJsonData();
    }
}
