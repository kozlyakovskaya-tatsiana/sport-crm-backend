using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfFit.Application;
using SelfFit.Application.Interfaces;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence
{
    public class SelfFitDbContext : SelfFitDbContextBase
    {
        public SelfFitDbContext(DbContextOptions<SelfFitDbContext> options) : base(options)
        {

        }
    }
}
