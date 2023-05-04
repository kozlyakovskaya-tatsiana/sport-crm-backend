using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfFit.Application.Repositories;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Repositories
{
    public class SportPlaygroundRepository : Repository<SportPlayground>, ISportPlaygroundRepository
    {
        public SportPlaygroundRepository(SelfFitDbContext context) : base(context)
        {
        }
    }
}
