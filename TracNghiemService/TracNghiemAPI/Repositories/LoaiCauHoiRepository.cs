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
    public class LoaiCauHoiRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static LoaiCauHoiResponse allloaicauhoi;
        private static List<LoaiCauHoiModel> loaicauhoiModel;

        public LoaiCauHoiRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<LoaiCauHoi, LoaiCauHoiModel>());
            mapper = new Mapper(config);
            allloaicauhoi = new LoaiCauHoiResponse();
            loaicauhoiModel = new List<LoaiCauHoiModel>();
        }

        public LoaiCauHoiResponse GetAllLoaiCauHoi()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<LoaiCauHoi> loaicauhoi = db.LoaiCauHois.ToList();
                loaicauhoiModel = mapper.Map<List<LoaiCauHoi>, List<LoaiCauHoiModel>>(loaicauhoi);
            }

            if (loaicauhoiModel.Count != 0)
            {
                allloaicauhoi.Data.AddRange(loaicauhoiModel);
                allloaicauhoi.StatusCode = (int)HttpStatusCode.OK;
                allloaicauhoi.Message = Constance.MessageSuccess;
            }
            else
            {
                allloaicauhoi.StatusCode = (int)HttpStatusCode.NotFound;
                allloaicauhoi.Message = Constance.MessageFailed;
            }

            return allloaicauhoi;
        }

        public LoaiCauHoiResponse GetLoaiCauHoiById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<LoaiCauHoi> loaicauhoi = db.LoaiCauHois.Where(m => m.MaLoaiCauHoi == id).ToList();
                loaicauhoiModel = mapper.Map<List<LoaiCauHoi>, List<LoaiCauHoiModel>>(loaicauhoi);
            }

            if (loaicauhoiModel.Count != 0)
            {
                allloaicauhoi.Data.AddRange(loaicauhoiModel);
                allloaicauhoi.StatusCode = (int)HttpStatusCode.OK;
                allloaicauhoi.Message = Constance.MessageSuccess;
            }
            else
            {
                allloaicauhoi.StatusCode = (int)HttpStatusCode.NotFound;
                allloaicauhoi.Message = Constance.MessageFailed;
            }

            return allloaicauhoi;
        }

        public LoaiCauHoiResponse InsertLoaiCauHoi(LoaiCauHoiModel loaicauhoiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<LoaiCauHoiModel, LoaiCauHoi>());
            mapper = new Mapper(config);
            LoaiCauHoi loaicauhoi = new LoaiCauHoi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    loaicauhoi = db.LoaiCauHois.Where(m => m.MaLoaiCauHoi == loaicauhoiModel.MaLoaiCauHoi).FirstOrDefault();
                    if (loaicauhoi != null)
                    {
                        allloaicauhoi.StatusCode = (int)HttpStatusCode.Conflict;
                        allloaicauhoi.Message = Constance.DuplicateID + loaicauhoiModel.MaLoaiCauHoi;
                        return allloaicauhoi;
                    }

                    loaicauhoi = mapper.Map<LoaiCauHoiModel, LoaiCauHoi>(loaicauhoiModel);
                    db.LoaiCauHois.Add(loaicauhoi);
                    db.SaveChanges();

                    allloaicauhoi.StatusCode = (int)HttpStatusCode.Created;
                    allloaicauhoi.Message = Constance.InsertSuccess;
                }
                catch
                {
                    allloaicauhoi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allloaicauhoi.Message = Constance.InsertFailed;
                }
            }

            return allloaicauhoi;
        }


        public LoaiCauHoiResponse UpdateLoaiCauHoi(LoaiCauHoiModel loaicauhoiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<LoaiCauHoiModel, LoaiCauHoi>());
            mapper = new Mapper(config);
            LoaiCauHoi loaicauhoi = new LoaiCauHoi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    loaicauhoi = db.LoaiCauHois.Find(loaicauhoiModel.MaLoaiCauHoi);
                    if (loaicauhoi != null)
                    {
                        allloaicauhoi.StatusCode = (int)HttpStatusCode.OK;
                        allloaicauhoi.Message = Constance.UpdateSuccess;

                        loaicauhoi = mapper.Map<LoaiCauHoiModel, LoaiCauHoi>(loaicauhoiModel, loaicauhoi);
                        db.Set<LoaiCauHoi>().Attach(loaicauhoi);
                        db.Entry<LoaiCauHoi>(loaicauhoi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allloaicauhoi;
                    }

                    allloaicauhoi.StatusCode = (int)HttpStatusCode.NotFound;
                    allloaicauhoi.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allloaicauhoi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allloaicauhoi.Message = Constance.UpdateFailed;
                }
            }
            return allloaicauhoi;
        }

        public LoaiCauHoiResponse DeleteLoaiCauHoi(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    LoaiCauHoi loaicauhoi = db.LoaiCauHois.Find(id);
                    if (loaicauhoi != null)
                    {
                        db.Entry(loaicauhoi).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allloaicauhoi.StatusCode = (int)HttpStatusCode.OK;
                        allloaicauhoi.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allloaicauhoi.StatusCode = (int)HttpStatusCode.NotFound;
                        allloaicauhoi.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allloaicauhoi.StatusCode = (int)HttpStatusCode.NotFound;
                    allloaicauhoi.Message = Constance.DeleteFailed;
                }
            }

            return allloaicauhoi;
        }
    }
}