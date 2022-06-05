using FengShuiNumber.Helpers;
using FengShuiNumber.Models.Entities;
using FengShuiNumber.Repositories;
using FengShuiNumber.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FengShuiNumber.Services
{
    public class GenerateDataService : IGenerateDataService
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly INetWorkProviderRepository _netWorkProviderRepository;
        private readonly IPrefixRepository _prefixRepository;

        public GenerateDataService(IPhoneNumberRepository phoneNumberRepository, INetWorkProviderRepository netWorkProviderRepository, IPrefixRepository prefixRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
            _netWorkProviderRepository = netWorkProviderRepository;
            _prefixRepository = prefixRepository;
        }

        public async Task<bool> GenerateData(int phoneSize)
        {

            await GenerateNetWorkProvider();
            await GeneratePrefix();

            if (phoneSize > 10000)
            {
                Console.WriteLine("Size generate less than 10000 phone number !!!!");
                return false;
            }

            await GeneratePhoneNumber(phoneSize - phoneSize / 10);
            await GenerateFengShuiPhoneNumber(phoneSize / 10);

            return true;
        }

        public async Task<string> WriteJsonData()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            phoneNumbers = _phoneNumberRepository.GetAll();

            List<NetWorkProvider> netWorkProviders = new List<NetWorkProvider>();
            netWorkProviders = _netWorkProviderRepository.GetAll();

            List<Prefix> prefixes = new List<Prefix>();
            prefixes = _prefixRepository.GetAll();

            var path = "";

            path += WriteJsonFile.Create(JsonSerializer.Serialize(phoneNumbers), "PhoneNumbers") + Environment.NewLine;
            path += WriteJsonFile.Create(JsonSerializer.Serialize(netWorkProviders), "NetWorkProviders") + Environment.NewLine;
            path += WriteJsonFile.Create(JsonSerializer.Serialize(prefixes), "Prefixies") + Environment.NewLine;

            return path;
        }

        private async Task<bool> GenerateNetWorkProvider()
        {
            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return false;

            // check data
            if (_netWorkProviderRepository.GetAll().Count > 0) return true;

            List<NetWorkProvider> netWorkProviders = new List<NetWorkProvider>();

            config.NetWorks.ForEach(network =>
            {
                NetWorkProvider netWorkProvider = new NetWorkProvider();

                netWorkProvider.Code = network.Code;
                netWorkProvider.Name = network.Name;

                netWorkProviders.Add(netWorkProvider);
            });

            _netWorkProviderRepository.InsertRange(netWorkProviders);

            return true;
        }

        private async Task<bool> GeneratePrefix()
        {
            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return false;

            // check data
            if (_prefixRepository.GetAll().Count > 0) return true;

            List<Prefix> prefixes = new List<Prefix>();

            List<NetWorkProvider> netWorkProviders = _netWorkProviderRepository.GetAll();

            config.NetWorks.ForEach(network =>
            {
                var netWorkId = netWorkProviders.Where(e => e.Code == network.Code).FirstOrDefault().Id;


                foreach (var _pre in network.Prefixies)
                {
                    Prefix prefix = new Prefix();
                    prefix.NetWorkId = netWorkId;
                    prefix.Value = _pre;

                    prefixes.Add(prefix);
                }

            });

            _prefixRepository.InsertRange(prefixes);

            //_prefixRepository.InsertRange(prefixes);

            return true;
        }

        private async Task<bool> GeneratePhoneNumber(int size)
        {

            List<Prefix> prefixes = _prefixRepository.GetAll();

            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();

            for (int i = 0; i < size; i++)
            {
                // random prefix
                var _index = NumberHelper.Random(0, prefixes.Count - 1);

                PhoneNumber phoneNumber = new PhoneNumber();
                phoneNumber.PrefixId = prefixes[_index].Id;
                phoneNumber.Number = prefixes[_index].Value + NumberHelper.RandomStringNumber(7);

                phoneNumbers.Add(phoneNumber);

            }

            _phoneNumberRepository.InsertRange(phoneNumbers);

            return true;
        }

        public async Task<bool> GenerateFengShuiPhoneNumber(int size)
        {

            var config = ReadConfig.GetFengShuiConfig();

            if (config == null) return false;

            List<Prefix> prefixes = _prefixRepository.GetAll();
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            List<string> last2DigitValid = config.ValidLast2Numbers.ToList();

            for (int i = 0; i < size; i++)
            {
                // random prefix
                var _pre_index = NumberHelper.Random(0, prefixes.Count - 1);
                var _last2digit_index = NumberHelper.Random(0, last2DigitValid.Count - 1);

                var _sum_index = NumberHelper.Random(0, config.SumConditions.Count - 1);

                var sum_first_5_digits = config.SumConditions[_sum_index].First5DigitsSum;
                var sum_last_5_digits = config.SumConditions[_sum_index].Last5DigitsSum;

                var sum_prefix = (prefixes[_pre_index].Value[0] - '0') + (prefixes[_pre_index].Value[1] - '0') + (prefixes[_pre_index].Value[2] - '0');
                var sum_Last2Digits = (last2DigitValid[_last2digit_index][0] - '0') + (last2DigitValid[_last2digit_index][1] - '0');

                var number = $"{prefixes[_pre_index].Value}{GenerateSum(2, sum_first_5_digits - sum_prefix)}{GenerateSum(3, sum_last_5_digits - sum_Last2Digits)}{last2DigitValid[_last2digit_index]}";

                PhoneNumber phoneNumber = new PhoneNumber();
                phoneNumber.PrefixId = prefixes[_pre_index].Id;
                phoneNumber.Number = number;

                phoneNumbers.Add(phoneNumber);
            }

            _phoneNumberRepository.InsertRange(phoneNumbers);

            return true;
        }

        // generate random sum of [numLen] number equal [sum]
        private string GenerateSum(int numLen, int sum)
        {
            if (sum > 9 * numLen) return "";
            var num = "";
            for (int i = 0; i < numLen; i++)
            {
                if (sum >= 9)
                {
                    var n = 0;

                    if (sum - 9 * (numLen - i - 1) > 0) n = NumberHelper.Random(sum - 9 * (numLen - i - 1), 9);
                    else
                        n = NumberHelper.Random(0, 9);
                    num += n;
                    sum -= n;
                }
                else
                {
                    var n = NumberHelper.Random(0, sum);

                    if (i == numLen - 1) n = sum;

                    num += n;
                    sum -= n;
                }

            }

            return num;
        }
    }
}
