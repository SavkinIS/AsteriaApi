using AsteriaApi.ContextFolder;
using AsteriaApi.Interface;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace AsteriaApi.DataFolder
{
    public class Data : IDBContext

    {
        private readonly DataContext context;


        public Data()
        {
            var context = new DataContext();
            this.context = context;
        }


        #region Client
        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return context.Clients.ToList();
        }

        public ActionResult<Client> GetClients(int id)
        {
            var client = context.Clients.Find(id);


            return client;
        }

        public string PutClient(Client newclient,long id)
        {
            try
            {
                var oldClient = context.Clients.Where(cl => (cl.Id == id)).FirstOrDefault();
                if (oldClient.Id == id)
                {
                    oldClient.Id = newclient.Id;
                    oldClient.Name = newclient.Name;
                    oldClient.Phone = newclient.Phone;
                    context.SaveChanges();
                    return "ok";
                }
                else
                {
                    return "NotFound";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(newclient.Id))
                {
                    return "NotFound";
                }
                else
                {
                    throw;
                }
            }
            catch
            {
                return "Cant Change Clients ID";
            }
        }

        public Client DelClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return client;
            }
            try
            {
                context.Clients.Remove(client);
                context.SaveChanges();
                return client;
            }
            catch (Exception e)
            {
                //добавить LOG
                return client;
            }

        }
        private bool ClientExists(int id)
        {
            return context.Clients.Any(e => e.Id == id);
        }


        #endregion

        #region Record
        public void AddRecord(Record record)
        {
            context.Records.Add(record);
            context.SaveChanges();
        }


        public ActionResult<IEnumerable<Record>> GetRecords()
        {
            var rec = context.Records.ToList();
            return rec;
        }
        public ActionResult<Record> GetRecords(int id)
        {
            var rec = context.Records.Find(id);
            return rec;
        }

        public ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date)
        {
            int year, month, day;
            ConvertTodate(date, out year, out month, out day);
            DateTime dt = new DateTime(year, month, day);

            var rec = context.Records.Where(d => (d.Date.ToShortDateString() == dt.ToShortDateString())).ToList();


            var clients = context.Clients.ToList();



            List<RecordsDTO> recod = new List<RecordsDTO>();
            ToRecordsDTO(rec, clients, recod);

            return recod;
        }

        public ActionResult<IEnumerable<RecordsDTO>> GetRecords(string date, int specId)
        {
            int year, month, day;
            ConvertTodate(date, out year, out month, out day);
            DateTime dt = new DateTime(year, month, day);

            var rec = context.Records.Where(s => (s.SpecId == specId))//.ToList();
                                       .Where(d => (d.Date.ToShortDateString() == dt.ToShortDateString())).ToList();


            var clients = context.Clients.ToList();


          
            List<RecordsDTO> recod = new List<RecordsDTO>();
            ToRecordsDTO(rec, clients, recod);

            return recod;
        }

        /// <summary>
        /// Переопределяем содерщимое записей, для лучшей визуализации
        /// </summary>
        /// <param name="rec">Результат запроса</param>
        /// <param name="clients">список клиетнов</param>
        /// <param name="recod">список для переопределения</param>
        private void ToRecordsDTO(List<Record> rec, List<Client> clients, List<RecordsDTO> recod)
        {
            //Переопределяем содерщимое записей, для лучшей визуализации
            foreach (var r in rec)
            {
                recod.Add(
                    new RecordsDTO
                    {
                        Id = r.Id,
                        ClientName = clients.Where(i => (i.Id == r.ClientId)).FirstOrDefault().Name,
                        Clientid = r.ClientId,
                        SpecId = r.SpecId,
                        SpecName = context.Specialists.Where(i => (i.Id == r.SpecId)).FirstOrDefault().Name,
                        Price = r.Price,
                        TypeWork = r.TypeWork,
                        Date = r.Date,
                        Time = r.Time
                    }) ;
            }
        }

        public ActionResult<IEnumerable<Record>> GetRecords(string date, int specId, string time)
        {
            int year, month, day;
            ConvertTodate(date, out year, out month, out day);
            int hour, minutes;
            time = ConvertToTime(time, out hour, out minutes);
            DateTime dt = new DateTime(year, month, day, hour, minutes, 0);

            var rec = context.Records.Where(s => (s.SpecId == specId))//.ToList();
                                       .Where(d => (d.Date.ToShortDateString() == dt.ToShortDateString())).ToList();


            return rec;
        }

        private static string ConvertToTime(string time, out int hour, out int minutes)
        {
            if (time.StartsWith('9') || time.StartsWith('0')) time = "0" + time;
            hour = Convert.ToInt32(time.Substring(0, 2));
            minutes = Convert.ToInt32(time.Substring(3, 2));
            return time;
        }

        /// <summary>
        /// Переводит строку в дату
        /// </summary>
        /// <param name="date"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        private static void ConvertTodate(string date, out int year, out int month, out int day)
        {
            year = Convert.ToInt32(date.Substring(6, 4));
            month = Convert.ToInt32(date.Substring(3, 2));
            day = Convert.ToInt32(date.Substring(0, 2));
        }

        public string PutRecord(Record newRecord, long id)
        {
            try
            {
                var oldRecord = context.Records.Where(cl => (cl.Id == id)).FirstOrDefault();
                if (oldRecord.Id == id)
                {
                    oldRecord.Id = newRecord.Id;
                    oldRecord.ClientId = newRecord.ClientId;
                    oldRecord.SpecId = newRecord.SpecId;
                    oldRecord.Time = newRecord.Time;
                    oldRecord.Date = newRecord.Date;
                    oldRecord.Price = newRecord.Price;
                    oldRecord.TypeWork = newRecord.TypeWork;
                    context.SaveChanges();
                    return "ok";
                }
                else
                {
                    return "NotFound";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(newRecord.Id))
                {
                    return "NotFound";
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                return "Cant Change Record ID";
            }
        }

        public Record DelRecord(int id)
        {
            var record = context.Records.Find(id);
            if (record == null)
            {
                return record;
            }
            try
            {
                context.Records.Remove(record);
                context.SaveChanges();
                return record;
            }
            catch (Exception e)
            {
                //добавить LOG
                return record;
            }

        }
        private bool RecordExists(int id)
        {
            return context.Records.Any(e => e.Id == id);
        }



        #endregion

        #region Specialist
        public void AddSpecialist(Specialist specialist)
        {
            context.Specialists.Add(specialist);
            context.SaveChanges();
        }
        public ActionResult<IEnumerable<Specialist>> GetSpecialists()
        {
            return context.Specialists.ToList();
        }
        public ActionResult<Specialist> GetSpecialists(int id)
        {
            return context.Specialists.Find(id);
        }

        public string PutSpecialist(Specialist newSpecialist, long id)
        {
            try
            {
                var oldSpecialist = context.Specialists.Where(cl => (cl.Id == id)).FirstOrDefault();
                if (oldSpecialist.Id == id)
                {
                     oldSpecialist.Id = newSpecialist.Id;
                     oldSpecialist.Men = newSpecialist.Men;
                     oldSpecialist.Name = newSpecialist.Name;
                     oldSpecialist.Phone = newSpecialist.Phone;
                     oldSpecialist.Women = newSpecialist.Women;
                     oldSpecialist.Specialization = newSpecialist.Specialization;
                     oldSpecialist.SpecAvatar = newSpecialist.SpecAvatar;
                  
                    context.SaveChanges();
                    return "ok";
                }
                else
                {
                    return "NotFound";
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialistExists(newSpecialist.Id))
                {
                    return "NotFound";
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                return "Cant Change Record ID";
            }
        }

        public Specialist DelSpecialist(int id)
        {
            var record = context.Specialists.Find(id);
            if (record == null)
            {
                return record;
            }
            try
            {
                context.Specialists.Remove(record);
                context.SaveChanges();
                return record;
            }
            catch (Exception e)
            {
                //добавить LOG
                return record;
            }

        }
        private bool SpecialistExists(int id)
        {
            return context.Specialists.Any(e => e.Id == id);
        }
        #endregion

       










    }
}
