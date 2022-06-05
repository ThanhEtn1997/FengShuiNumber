using FengShuiNumber.Models;
using FengShuiNumber.Models.Entities;
using FengShuiNumber.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FengShuiNumber.Repositories
{
    public class NetWorkProviderRepository : Repository<NetWorkProvider, Guid>, INetWorkProviderRepository
    {
        public NetWorkProviderRepository(FengShuiNumberDbContext context) : base(context)
        {
        }


    }
}
