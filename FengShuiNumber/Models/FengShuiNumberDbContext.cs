using FengShuiNumber.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Models
{
    public partial class FengShuiNumberDbContext: DbContext
    {
        //public FengShuiNumberDbContext(DbContextOptions<FengShuiNumberDbContext> options)
        //    : base(options)
        //{

        //}

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<NetWorkProvider> NetWorkProviders { get; set; }
        public DbSet<Prefix> Prefixes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
