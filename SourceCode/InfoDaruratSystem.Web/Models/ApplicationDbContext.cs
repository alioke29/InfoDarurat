using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InfoDaruratSystem.Web.Models
{
    public class ApplicationDbContext : DatabaseContext
    {

        public ApplicationDbContext(DbContextOptions<DatabaseContext> options)
              : base(options)
        {

        }


    }
}
