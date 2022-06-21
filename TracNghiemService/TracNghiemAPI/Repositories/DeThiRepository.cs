using AutoMapper;
using System;
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
    public class DeThiRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static DeThiResponse allDeThi;
        private static List<DeThiModel> dethiModel;

        
        public DeThiRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<DeThi, DeThiModel>());
            mapper = new Mapper(config);
            allDeThi = new DeThiResponse();
            dethiModel = new List<DeThiModel>();
        }

        public DeThiResponse GetAllDeThi()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<DeThi> dethi = db.DeThis.ToList();
                dethiModel = mapper.Map<List<DeThi>, List<DeThiModel>>(dethi);
            }

            if (dethiModel.Count != 0)
            {
                allDeThi.Data.AddRange(dethiModel);
                allDeThi.StatusCode = (int)HttpStatusCode.OK;
                allDeThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allDeThi.StatusCode = (int)HttpStatusCode.NotFound;
                allDeThi.Message = Constance.MessageFailed;
            }

            return allDeThi;
        }

        public DeThiResponse GetDeThiById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<DeThi> dethi = db.DeThis.Where(m => m.MaDe == id).ToList();
                dethiModel = mapper.Map<List<DeThi>, List<DeThiModel>>(dethi);
            }

            if (dethiModel.Count != 0)
            {
                allDeThi.Data.AddRange(dethiModel);
                allDeThi.StatusCode = (int)HttpStatusCode.OK;
                allDeThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allDeThi.StatusCode = (int)HttpStatusCode.NotFound;
                allDeThi.Message = Constance.MessageFailed;
            }

            return allDeThi;
        }

        public DeThiResponse InsertDeThi(DeThiModel dethiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<DeThiModel, DeThi>());
            mapper = new Mapper(config);
            DeThi dethi = new DeThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    dethi = db.DeThis.Where(m => m.MaDe == dethiModel.MaDe).FirstOrDefault();
                    if (dethi != null)
                    {
                        allDeThi.StatusCode = (int)HttpStatusCode.Conflict;
                        allDeThi.Message = Constance.DuplicateID + dethiModel.MaDe;
                        return allDeThi;
                    }

                    dethi = mapper.Map<DeThiModel, DeThi>(dethiModel);
                    db.DeThis.Add(dethi);
                    db.SaveChanges();

                    allDeThi.StatusCode = (int)HttpStatusCode.Created;
                    allDeThi.Message = Constance.InsertSuccess;
                }
                catch
                {
                    allDeThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allDeThi.Message = Constance.InsertFailed;
                }
            }

            return allDeThi;
        }


        public DeThiResponse UpdateDeThi(DeThiModel dethiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<DeThiModel, DeThi>());
            mapper = new Mapper(config);
            DeThi dethi = new DeThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    dethi = db.DeThis.Find(dethiModel.MaDe);
                    if (dethi != null)
                    {
                        allDeThi.StatusCode = (int)HttpStatusCode.OK;
                        allDeThi.Message = Constance.UpdateSuccess;

                        dethi = mapper.Map<DeThiModel, DeThi>(dethiModel, dethi);
                        db.Set<DeThi>().Attach(dethi);
                        db.Entry<DeThi>(dethi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allDeThi;
                    }

                    allDeThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allDeThi.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allDeThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allDeThi.Message = Constance.UpdateFailed;
                }
            }
            return allDeThi;
        }

        public DeThiResponse DeleteDeThi(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    DeThi dethi = db.DeThis.Find(id);
                    if (dethi != null)
                    {
                        db.Entry(dethi).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allDeThi.StatusCode = (int)HttpStatusCode.OK;
                        allDeThi.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allDeThi.StatusCode = (int)HttpStatusCode.NotFound;
                        allDeThi.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allDeThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allDeThi.Message = Constance.DeleteFailed;
                }
            }

            return allDeThi;
        }

    }
}