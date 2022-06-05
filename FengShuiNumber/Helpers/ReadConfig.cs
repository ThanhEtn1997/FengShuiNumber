using FengShuiNumber.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FengShuiNumber.Helpers
{
    public class ReadConfig
    {
        public static FengShuiConfig GetFengShuiConfig()
        {

            var contextPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (contextPath == null)
            {
                return null;
            }

            string path = Path.Combine(contextPath, @"fengshuiconfig.json");
            var rawConfig = File.ReadAllText(path);

            if (rawConfig == null)
            {
                return null;
            }

            var fengshuiConfig = JsonConvert.DeserializeObject<FengShuiConfig>(rawConfig);

            return fengshuiConfig;
        }
    }
}
