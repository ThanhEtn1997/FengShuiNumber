using FengShuiNumber.Models;
using FengShuiNumber.Repositories;
using FengShuiNumber.Repositories.IRepositories;
using FengShuiNumber.Services;
using FengShuiNumber.Services.ValidationServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace FengShuiNumber
{
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start !!!");

                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                IConfiguration configuration = configurationBuilder.Build();
                var connectionString = configuration.GetConnectionString("Default");

                var host = CreateHostBuilder(args, connectionString).Build();

                var entryPoint = host.Services.GetRequiredService<RunClass>();

                entryPoint.Run().Wait();

                Console.WriteLine("Finish !!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
            {
                services.AddDbContext<FengShuiNumberDbContext>();
                
                services.AddScoped<IPhoneNumberService, PhoneNumberService>();
                services.AddScoped<IGenerateDataService, GenerateDataService>();

                services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
                services.AddScoped<INetWorkProviderRepository, NetWorkProviderRepository>();
                services.AddScoped<IPrefixRepository, PrefixRepository>();

                services.AddScoped<IFengShuiNumberValidation, FengShuiNumberValidation>();

                services.AddTransient<RunClass>();
            });

    }
    public class RunClass
    {
        private readonly IPhoneNumberService _phoneNumberService;
        private readonly IGenerateDataService _generateDataService;

        public RunClass(IPhoneNumberService phoneNumberService, IGenerateDataService generateDataService)
        {
            _phoneNumberService = phoneNumberService;
            _generateDataService = generateDataService;
        }

        public async Task Run()
        {
            var check = true;
            while (check)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What do you want to do ???");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Check all FengShui number in database write to .docx file");
                Console.WriteLine("2. Generate testing data in database");
                Console.WriteLine("3. Write data to .json file");
                Console.WriteLine("4. Exit");
                Console.WriteLine("------------------------------------------");

                var index = Console.ReadLine();

                if(index == "1")
                {
                    var res = await _phoneNumberService.GetAllFengShuiNumberToDocx();

                    Console.WriteLine("File path generated: " + res);
                }

                if(index == "2")
                {
                    Console.WriteLine("------------------------------------------");
                    Console.Write("Enter phone number generate size (limit 10000): ");
                    var phoneSize_text = Console.ReadLine();
                    var phoneSize = 0;

                    Int32.TryParse(phoneSize_text, out phoneSize);
                    if(phoneSize > 0)
                    {
                        var res = await _generateDataService.GenerateData(phoneSize);
                        if(res) Console.WriteLine("Generate data success !!!");
                        else
                            Console.WriteLine("Generate data failure !!!");
                    }
                    else
                    {
                        Console.WriteLine("InValid Input !!!");
                    }


                }

                if(index == "3")
                {
                    var res = await _generateDataService.WriteJsonData();
                    Console.WriteLine("File path generated: " + Environment.NewLine + res);
                }

                if (index == "4") check = false;


                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Continue");
                Console.WriteLine("2. Exit");
                Console.WriteLine("------------------------------------------");
                var index2 = Console.ReadLine();
                if (index2 == "2") check = false;
            }
        }
    }
}
    