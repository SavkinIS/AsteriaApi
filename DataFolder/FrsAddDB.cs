using AsteriaApi.AuthUser;
using AsteriaApi.ContextFolder;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsteriaApi.DataFolder
{

    /// <summary>
    /// Класс при первом запуске добавляет тестовые значения в БД
    /// </summary>
    public class FrsAddDB
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Specialists.Any()) return;

            var spets = new List<Specialist>()
            {
                new Specialist{Name = "Алла",  Specialization = "hairdresser", SpecAvatar = "1", Child= true, Men = true, Women = true, Phone = "79031234560"   },
                new Specialist{Name = "Инга",  Specialization = "hairdresser", SpecAvatar = "2", Child= true, Men = true, Women = true, Phone = "79161234565"   },
                new Specialist{Name = "Мария",  Specialization = "hairdresser", SpecAvatar = "3", Child= true, Men = true, Women = true, Phone = "79261234567"   }
            };

            var clients = new List<Client>()
            {
                new Client{Name = "Bob", Phone = "79264091142"},
                new Client{Name = "Marta", Phone = "79264095548"},
                new Client{Name = "Kate", Phone = "79264097796"}
            };

            var record = new List<Record>()
            {   
                new Record{ClientId = 1, SpecId = 1, Date = DateTime.Now, 
                    Price = 1500, Time = new TimeSpan(10,0, 0), TypeWork = "painhair"},
                new Record{ClientId = 1, SpecId = 1, Date = DateTime.Now,
                    Price = 0, Time = new TimeSpan(10,30, 0), TypeWork = "painhair"},
                new Record{ClientId = 3, SpecId = 1, Date = DateTime.Now,
                    Price = 1000, Time = new TimeSpan(10,0, 0), TypeWork = "haircut"},
            };

            

            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var item in spets) context.Specialists.Add(item);
                foreach (var item in clients) context.Clients.Add(item);
                foreach (var item in record) context.Records.Add(item);
               

                context.SaveChanges();
                
                trans.Commit();
            }


        }
    }
}
