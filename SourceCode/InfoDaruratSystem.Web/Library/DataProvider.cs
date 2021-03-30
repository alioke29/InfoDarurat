using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Data.SqlClient;

using InfoDaruratSystem.Web.Models;

using Microsoft.Extensions.Configuration;
using System.Data.Common;

namespace InfoDaruratSystem.Web.Library
{
    public class DataProvider
    {

        public static ApplicationDbContext context;
        public static string connectionStringGlobal { get; set; }


        public DataProvider(ApplicationDbContext _context)
        {
            context = _context;
        }

        public  DbConnection DBConnection()
        {
            string connectionString = context.Database.GetDbConnection().ConnectionString;      

            if (!string.IsNullOrEmpty(connectionString))
                connectionStringGlobal = connectionString;
            else
                connectionString = connectionStringGlobal;

            context.Database.GetDbConnection().ConnectionString = connectionString;
            return context.Database.GetDbConnection();
        }


    }
}
