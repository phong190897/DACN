using AutoMapper;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using TracNghiemAPI.Models;
using TracNghiemAPI.Models.ViewModels;
using TracNghiemAPI.Utils;

namespace TracNghiemAPI.Repository
{
    public class MonThiRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static MonThiResponse allMonThi;
        private static List<MonThiModel> monthiModel;


        public MonThiRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<MonThi, MonThiModel>());
            mapper = new Mapper(config);
            allMonThi = new MonThiResponse();
            monthiModel = new List<MonThiModel>();
        }

        public MonThiResponse GetAllMonThi()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<MonThi> monthi = db.MonThis.ToList();
                monthiModel = mapper.Map<List<MonThi>, List<MonThiModel>>(monthi);
            }

            if (monthiModel.Count != 0)
            {
                allMonThi.Data.AddRange(monthiModel);
                allMonThi.StatusCode = (int)HttpStatusCode.OK;
                allMonThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allMonThi.StatusCode = (int)HttpStatusCode.NotFound;
                allMonThi.Message = Constance.MessageFailed;
            }

            return allMonThi;
        }

        public MonThiResponse GetMonThiById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<MonThi> monthi = db.MonThis.Where(m => m.MaMon == id).ToList();
                monthiModel = mapper.Map<List<MonThi>, List<MonThiModel>>(monthi);
            }

            if (monthiModel.Count != 0)
            {
                allMonThi.Data.AddRange(monthiModel);
                allMonThi.StatusCode = (int)HttpStatusCode.OK;
                allMonThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allMonThi.StatusCode = (int)HttpStatusCode.NotFound;
                allMonThi.Message = Constance.MessageFailed;
            }

            return allMonThi;
        }

        public MonThiResponse InsertMonThi(MonThiModel monthiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<MonThiModel, MonThi>());
            mapper = new Mapper(config);
            MonThi monthi = new MonThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    monthi = db.MonThis.Where(m => m.MaMon == monthiModel.MaMon).FirstOrDefault();
                    if (monthi != null)
                    {
                        allMonThi.StatusCode = (int)HttpStatusCode.Conflict;
                        allMonThi.Message = Constance.DuplicateID + monthiModel.MaMon;
                        return allMonThi;
                    }

                    monthi = mapper.Map<MonThiModel, MonThi>(monthiModel);
                    db.MonThis.Add(monthi);
                    db.SaveChanges();

                    allMonThi.StatusCode = (int)HttpStatusCode.Created;
                    allMonThi.Message = Constance.InsertSuccess;
                }
                catch
                {
                    allMonThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allMonThi.Message = Constance.InsertFailed;
                }
            }

            return allMonThi;
        }


        public MonThiResponse UpdateMonThi(MonThiModel monthiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<MonThiModel, MonThi>());
            mapper = new Mapper(config);
            MonThi monThi = new MonThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    monThi = db.MonThis.Find(monthiModel.MaMon);
                    if (monThi != null)
                    {
                        allMonThi.StatusCode = (int)HttpStatusCode.OK;
                        allMonThi.Message = Constance.UpdateSuccess;

                        monThi = mapper.Map<MonThiModel, MonThi>(monthiModel, monThi);
                        db.Set<MonThi>().Attach(monThi);
                        db.Entry<MonThi>(monThi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allMonThi;
                    }

                    allMonThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allMonThi.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allMonThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allMonThi.Message = Constance.UpdateFailed;
                }
            }
            return allMonThi;
        }


        public MonThiResponse DeleteMonThi(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    MonThi monthi = db.MonThis.Find(id);
                    if (monthi != null)
                    {
                        db.Entry(monthi).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allMonThi.StatusCode = (int)HttpStatusCode.OK;
                        allMonThi.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allMonThi.StatusCode = (int)HttpStatusCode.NotFound;
                        allMonThi.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allMonThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allMonThi.Message = Constance.DeleteFailed;
                }
            }
            return allMonThi;
        }

    }
}