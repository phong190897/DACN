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
    public class BaiThiRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static BaiThiResponse allBaiThi;
        private static List<BaiThiModel> baithiModel;

        public BaiThiRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<BaiThi, BaiThiModel>());
            mapper = new Mapper(config);
            allBaiThi = new BaiThiResponse();
            baithiModel = new List<BaiThiModel>();
        }

        public BaiThiResponse GetAllBaiThi()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<BaiThi> baithi = db.BaiThis.ToList();
                baithiModel = mapper.Map<List<BaiThi>, List<BaiThiModel>>(baithi);
            }

            if (baithiModel.Count != 0)
            {
                allBaiThi.Data.AddRange(baithiModel);
                allBaiThi.StatusCode = (int)HttpStatusCode.OK;
                allBaiThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                allBaiThi.Message = Constance.MessageFailed;
            }

            return allBaiThi;
        }

        public BaiThiResponse GetBaiThiById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<BaiThi> baithi = db.BaiThis.Where(m => m.MaBaiThi == id).ToList();
                baithiModel = mapper.Map<List<BaiThi>, List<BaiThiModel>>(baithi);
            }

            if (baithiModel.Count != 0)
            {
                allBaiThi.Data.AddRange(baithiModel);
                allBaiThi.StatusCode = (int)HttpStatusCode.OK;
                allBaiThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                allBaiThi.Message = Constance.MessageFailed;
            }

            return allBaiThi;
        }


        public BaiThiResponse GetAllBaiThiByTaiKhoan(string TaiKhoan)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<BaiThi> baithi = db.BaiThis.Where(m => m.TaiKhoan == TaiKhoan).ToList();
                baithiModel = mapper.Map<List<BaiThi>, List<BaiThiModel>>(baithi);
            }

            if (baithiModel.Count != 0)
            {
                allBaiThi.Data.AddRange(baithiModel);
                allBaiThi.StatusCode = (int)HttpStatusCode.OK;
                allBaiThi.Message = Constance.MessageSuccess;
            }
            else
            {
                allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                allBaiThi.Message = Constance.MessageFailed;
            }

            return allBaiThi;
        }


        public BaiThiResponse InsertBaiThi(BaiThiModel baithiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<BaiThiModel, BaiThi>());
            mapper = new Mapper(config);
            BaiThi baithi = new BaiThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    baithi = db.BaiThis.Where(m => m.MaBaiThi == baithiModel.MaBaiThi).FirstOrDefault();
                    if (baithi != null)
                    {
                        allBaiThi.StatusCode = (int)HttpStatusCode.Conflict;
                        allBaiThi.Message = Constance.DuplicateID + baithiModel.MaBaiThi;
                        return allBaiThi;
                    }

                    baithi = mapper.Map<BaiThiModel, BaiThi>(baithiModel);
                    db.BaiThis.Add(baithi);
                    db.SaveChanges();

                    allBaiThi.StatusCode = (int)HttpStatusCode.Created;
                    allBaiThi.Message = Constance.InsertSuccess;
                }
                catch(DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                    allBaiThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allBaiThi.Message = Constance.InsertFailed;
                }
            }

            return allBaiThi;
        }

        public BaiThiResponse UpdateBaiThi(BaiThiModel baithiModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<BaiThiModel, BaiThi>());
            mapper = new Mapper(config);
            BaiThi baithi = new BaiThi();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    baithi = db.BaiThis.Find(baithiModel.MaBaiThi);
                    if (baithi != null)
                    {
                        allBaiThi.StatusCode = (int)HttpStatusCode.OK;
                        allBaiThi.Message = Constance.UpdateSuccess;

                        baithi = mapper.Map<BaiThiModel, BaiThi>(baithiModel, baithi);
                        db.Set<BaiThi>().Attach(baithi);
                        db.Entry<BaiThi>(baithi).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allBaiThi;
                    }

                    allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allBaiThi.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allBaiThi.StatusCode = (int)HttpStatusCode.BadRequest;
                    allBaiThi.Message = Constance.UpdateFailed;
                }
            }
            return allBaiThi;
        }

        public BaiThiResponse DeleteBaiThi(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    BaiThi baithi = db.BaiThis.Find(id);
                    if (baithi != null)
                    {
                        db.Entry(baithi).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allBaiThi.StatusCode = (int)HttpStatusCode.OK;
                        allBaiThi.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                        allBaiThi.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allBaiThi.StatusCode = (int)HttpStatusCode.NotFound;
                    allBaiThi.Message = Constance.DeleteFailed;
                }
            }

            return allBaiThi;
        }

    }
}