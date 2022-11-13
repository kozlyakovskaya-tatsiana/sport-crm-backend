using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SelfFit.Application.Interfaces;
using SelfFit.Domain.Entities;

namespace SelfFit.Persistence.Services
{
    public class SelfFitUserManager: IUserManager
    {
        private readonly UserManager<User> _userManager;

        public SelfFitUserManager(UserManager<User> userManager)
        {
            _userManager=userManager;
        }
    }
}
