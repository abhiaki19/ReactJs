using ReactJs.Core.Entities;
using ReactJs.Core.Interfaces.IRepositories;
using ReactJs.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactJs.Infrastructure.Repositories
{
    public class ContactUsRepository : BaseRepository<ContactUs>, IContactUsRepository
    {
        public ContactUsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
