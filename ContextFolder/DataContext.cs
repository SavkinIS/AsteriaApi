using AsteriaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<TimeSheets> Sheetcs { get; set; }

        

        public DataContext()
        {
        }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             ///Изменить строку подключения
             optionsBuilder.UseSqlServer(
                  @"Server=(LocalDB)\MSSQLLocalDB;
                     DataBase=Asteria_DB.mdf;
                    Trusted_Connection=True;"
                 );
         }
         
    }

}
