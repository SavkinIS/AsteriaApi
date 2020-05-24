using AsteriaApi.ContextFolder;
using AsteriaApi.Interface;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            catch(Exception e)
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

        #region TimeSheets
        public ActionResult<IEnumerable<TimeSheets>> GetTimeSheets()
        {
            try
            {
                var dN = DateTime.Now;
                var dnd = dN.ToShortDateString();
                var timSheet = context.Sheetcs.Where(d => (d.Date.ToShortDateString() == dnd)).ToList();
               
                return timSheet;
            }
            catch
            {
                return new List<TimeSheets>();
            }
            /**/
        }

        public ActionResult<TimeSheets> GetTimeSheets(int id)
        {
            var res = context.Sheetcs.Find(id);
         
            return res;
        }

        public ActionResult<IEnumerable<TimeSheets>> GetTimeSheets( string date, int specID)
        {
            return context.Sheetcs.Where(d => (d.Date.ToShortDateString() == date.Replace("-",".")))
                                   .Where(s =>(s.SpecID ==specID)).ToList();
        }
        public void AddTimeSheets(TimeSheets timeSheets)
        {
            context.Sheetcs.Add(timeSheets);
            context.SaveChanges();
        }

        public string PutTimeSheets(TimeSheets newSheet, long id)
        {
            try
            {
                var oldSheet = context.Sheetcs.Where(cl => (cl.Id == id)).FirstOrDefault();
                if (oldSheet.Id == id)
                {
                    oldSheet.SpecID = newSheet.Id;
                    oldSheet.T9m00 = newSheet.T9m00;
                    oldSheet.T9m30 = newSheet.T9m30;

                    oldSheet.T10m00 = newSheet.T10m00;
                    oldSheet.T10m30 = newSheet.T10m30;

                    oldSheet.T11m00 = newSheet.T11m00;
                    oldSheet.T11m30 = newSheet.T11m30;

                    oldSheet.T12m00 = newSheet.T12m00;
                    oldSheet.T12m30 = newSheet.T12m30;

                    oldSheet.T13m00 = newSheet.T13m00;
                    oldSheet.T13m30 = newSheet.T13m30;
                    
                    oldSheet.T14m00 = newSheet.T14m00;
                    oldSheet.T14m30 = newSheet.T14m30;

                    oldSheet.T15m00 = newSheet.T15m00;
                    oldSheet.T15m30 = newSheet.T15m30;

                    oldSheet.T16m00 = newSheet.T16m00;
                    oldSheet.T16m30 = newSheet.T16m30;

                    oldSheet.T17m00 = newSheet.T17m00;
                    oldSheet.T17m30 = newSheet.T17m30;

                    oldSheet.T18m00 = newSheet.T18m00;
                    oldSheet.T18m30 = newSheet.T18m30; 

                    oldSheet.T19m00 = newSheet.T19m00;
                    oldSheet.T19m30 = newSheet.T19m30;


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
                if (!SheetExists(newSheet.Id))
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

        public TimeSheets DelSheetcs(int id)
        {
            var sheet = context.Sheetcs.Find(id);
            if (sheet == null)
            {
                return sheet;
            }
            try
            {
                context.Sheetcs.Remove(sheet);
                context.SaveChanges();
                return sheet;
            }
            catch (Exception e)
            {
                //добавить LOG
                return sheet;
            }

        }
        private bool SheetExists(int id)
        {
            return context.Sheetcs.Any(e => e.Id == id);
        }
        #endregion










    }
}
