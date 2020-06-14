using AsteriaApi.AuthUser;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.ContextFolder
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        


        public DataContext() { }


        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             ///Изменить строку подключения
             optionsBuilder.UseSqlServer(
                  @"Server=(LocalDB)\MSSQLLocalDB;
                     DataBase=Asteria2_DB.mdf;
                    Trusted_Connection=True;"
                 );
         }
         
    }

}
