using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitBody.WebUI.Entities
{
    public class CustomIdentityContext:IdentityDbContext<CustomIdentityUser, CustomIdentityRole,string>
    {
        public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options) : base(options)
        {

        }
    }
}
