using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFit.Domain.Entities;

namespace SelfFit.Application
{
    public abstract class SelfFitDbContextBase : IdentityDbContext<SelfFitUser, SelfFitRole, Guid>
    {
        protected SelfFitDbContextBase(DbContextOptions options) : base(options)
        {

        }
    }
}
