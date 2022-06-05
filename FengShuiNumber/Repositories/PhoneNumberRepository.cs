using FengShuiNumber.Models;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FengShuiNumber.Repositories
{
    public class PrefixRepository : Repository<Prefix, Guid>, IPrefixRepository
    {
        public PrefixRepository(FengShuiNumberDbContext context) : base(context) {
        }
        
    }
}
