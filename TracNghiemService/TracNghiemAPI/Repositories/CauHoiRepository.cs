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
    public class CauHoiRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static CauHoiResponse allCauHoi;
        private static List<CauHoiModel> cauhoiModel;


        public CauHoiRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<CauHoi, CauHoiModel>());
            mapper = new Mapper(config);
            allCauHoi = new CauHoiResponse();
            cauhoiModel = new List<CauHoiModel>();
        }

        public CauHoiResponse GetAllCauHoi()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<CauHoi> cauhoi = db.CauHois.ToList();
                cauhoiModel = mapper.Map<List<CauHoi>, List<CauHoiModel>>(cauhoi);
            }

            if (cauhoiModel.Count != 0)
            {
                allCauHoi.Data.AddRange(cauhoiModel);
                allCauHoi.StatusCode = (int)HttpStatusCode.OK;
                allCauHoi.Message = Constance.MessageSuccess;
            }
            else
            {
                allCauHoi.StatusCode = (int)HttpStatusCode.NotFound;
                allCauHoi.Message = Constance.MessageFailed;
            }

            return allCauHoi;
        }

        public CauHoiResponse GetCauHoiById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<CauHoi> cauhoi = db.CauHois.Where(m => m.MaCauHoi == id).ToList();
                cauhoiModel = mapper.Map<List<CauHoi>, List<CauHoiModel>>(cauhoi);
            }

            if (cauhoiModel.Count != 0)
            {
                allCauHoi.Data.AddRange(cauhoiModel);
                allCauHoi.StatusCode = (int)HttpStatusCode.OK;
                allCauHoi.Message = Constance.MessageSuccess;
            }
            else
            {
                allCauHoi.StatusCode = (int)HttpStatusCode.NotFound;
                allCauHoi.Message = Constance.MessageFailed;
            }

            return allCauHoi;
        }


        public CauHoiResponse InsertCauHoi(CauHoiModel cauhoiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<CauHoiModel, CauHoi>());
            mapper = new Mapper(config);
            CauHoi cauhoi = new CauHoi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    cauhoi = db.CauHois.Where(m => m.MaCauHoi == cauhoiModel.MaCauHoi).FirstOrDefault();
                    if (cauhoi != null)
                    {
                        allCauHoi.StatusCode = (int)HttpStatusCode.Conflict;
                        allCauHoi.Message = Constance.DuplicateID + cauhoiModel.MaCauHoi;
                        return allCauHoi;
                    }

                    cauhoi = mapper.Map<CauHoiModel, CauHoi>(cauhoiModel);
                    db.CauHois.Add(cauhoi);
                    db.SaveChanges();

                    allCauHoi.StatusCode = (int)HttpStatusCode.Created;
                    allCauHoi.Message = Constance.InsertSuccess;
                }
                catch
                {
                    allCauHoi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allCauHoi.Message = Constance.InsertFailed;
                }
            }

            return allCauHoi;
        }

        public CauHoiResponse UpdateCauHoi(CauHoiModel cauhoiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<CauHoiModel, CauHoi>());
            mapper = new Mapper(config);
            CauHoi cauhoi = new CauHoi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    cauhoi = db.CauHois.Find(cauhoiModel.MaCauHoi);
                    if (cauhoi != null)
                    {
                        allCauHoi.StatusCode = (int)HttpStatusCode.OK;
                        allCauHoi.Message = Constance.UpdateSuccess;

                        cauhoi = mapper.Map<CauHoiModel, CauHoi>(cauhoiModel, cauhoi);
                        db.Set<CauHoi>().Attach(cauhoi);
                        db.Entry<CauHoi>(cauhoi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allCauHoi;
                    }

                    allCauHoi.StatusCode = (int)HttpStatusCode.NotFound;
                    allCauHoi.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allCauHoi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allCauHoi.Message = Constance.UpdateFailed;
                }
            }
            return allCauHoi;
        }

        public CauHoiResponse DeleteCauHoi(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    CauHoi cauhoi = db.CauHois.Find(id);
                    if (cauhoi != null)
                    {
                        db.Entry(cauhoi).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allCauHoi.StatusCode = (int)HttpStatusCode.OK;
                        allCauHoi.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allCauHoi.StatusCode = (int)HttpStatusCode.NotFound;
                        allCauHoi.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allCauHoi.StatusCode = (int)HttpStatusCode.NotFound;
                    allCauHoi.Message = Constance.DeleteFailed;
                }
            }

            return allCauHoi;
        }
    }
}