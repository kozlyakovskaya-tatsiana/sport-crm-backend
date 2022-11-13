using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFit.Domain.Entities;

namespace SelfFit.Application
{
    public abstract class SelfFitDbContextBase : IdentityDbContext<User>
    {
        protected SelfFitDbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}
