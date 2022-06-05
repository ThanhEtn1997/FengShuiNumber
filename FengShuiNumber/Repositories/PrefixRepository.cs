using FengShuiNumber.Models;
using FengShuiNumber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FengShuiNumber.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber, Guid>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(FengShuiNumberDbContext context) : base(context) {
        }
        
    }
}
