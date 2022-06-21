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

namespace TracNghiemAPI.Repositories
{
    public class TaiKhoanRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;

        private static TaiKhoanResponse allTaiKhoan;
        private static List<TaiKhoanModel> TaiKhoanModel;


        public TaiKhoanRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<TaiKhoan, TaiKhoanModel>());
            mapper = new Mapper(config);
            allTaiKhoan = new TaiKhoanResponse();
            TaiKhoanModel = new List<TaiKhoanModel>();
        }

        public TaiKhoanResponse GetAllTaiKhoan()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<TaiKhoan> taikhoan = db.TaiKhoans.ToList();
                TaiKhoanModel = mapper.Map<List<TaiKhoan>, List<TaiKhoanModel>>(taikhoan);
            }

            if (TaiKhoanModel.Count != 0)
            {
                allTaiKhoan.Data.AddRange(TaiKhoanModel);
                allTaiKhoan.StatusCode = (int)HttpStatusCode.OK;
                allTaiKhoan.Message = Constance.MessageSuccess;
            }
            else
            {
                allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                allTaiKhoan.Message = Constance.MessageFailed;
            }

            return allTaiKhoan;
        }

        public TaiKhoanResponse GetTaiKhoanById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<TaiKhoan> taikhoan = db.TaiKhoans.Where(m => m.TenTaiKhoan == id).ToList();
                TaiKhoanModel = mapper.Map<List<TaiKhoan>, List<TaiKhoanModel>>(taikhoan);
            }

            if (TaiKhoanModel.Count != 0)
            {
                allTaiKhoan.Data.AddRange(TaiKhoanModel);
                allTaiKhoan.StatusCode = (int)HttpStatusCode.OK;
                allTaiKhoan.Message = Constance.MessageSuccess;
            }
            else
            {
                allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                allTaiKhoan.Message = Constance.MessageFailed;
            }

            return allTaiKhoan;
        }


        public TaiKhoanResponse InsertTaiKhoan(TaiKhoanModel taikhoanModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<TaiKhoanModel, TaiKhoan>());
            mapper = new Mapper(config);
            TaiKhoan taiKhoan = new TaiKhoan();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    taiKhoan = db.TaiKhoans.Where(m => m.TenTaiKhoan == taikhoanModel.TenTaiKhoan).FirstOrDefault();
                    if (taiKhoan != null)
                    {
                        allTaiKhoan.StatusCode = (int)HttpStatusCode.Conflict;
                        allTaiKhoan.Message = Constance.DuplicateID + taikhoanModel.TenTaiKhoan;
                        return allTaiKhoan;
                    }

                    taiKhoan = mapper.Map<TaiKhoanModel, TaiKhoan>(taikhoanModel);
                    db.TaiKhoans.Add(taiKhoan);
                    db.SaveChanges();

                    allTaiKhoan.StatusCode = (int)HttpStatusCode.Created;
                    allTaiKhoan.Message = Constance.InsertSuccess;
                }
                catch
                {
                    allTaiKhoan.StatusCode = (int)HttpStatusCode.BadRequest;
                    allTaiKhoan.Message = Constance.InsertFailed;
                }
            }

            return allTaiKhoan;
        }


        public TaiKhoanResponse UpdateTaiKhoan(TaiKhoanModel taiKhoanModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<TaiKhoanModel, TaiKhoan>());
            mapper = new Mapper(config);
            TaiKhoan taikhoan = new TaiKhoan();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    taikhoan = db.TaiKhoans.Find(taiKhoanModel.TenTaiKhoan);
                    if (taikhoan != null)
                    {
                        allTaiKhoan.StatusCode = (int)HttpStatusCode.OK;
                        allTaiKhoan.Message = Constance.UpdateSuccess;

                        taikhoan = mapper.Map<TaiKhoanModel, TaiKhoan>(taiKhoanModel, taikhoan);
                        db.Set<TaiKhoan>().Attach(taikhoan);
                        db.Entry<TaiKhoan>(taikhoan).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        return allTaiKhoan;
                    }

                    allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                    allTaiKhoan.Message = Constance.UpdateFailed;
                }
                catch (DbEntityValidationException ex)
                {
                    allTaiKhoan.StatusCode = (int)HttpStatusCode.BadRequest;
                    allTaiKhoan.Message = Constance.UpdateFailed;
                }
            }
            return allTaiKhoan;
        }


        public TaiKhoanResponse DeleteTaiKhoan(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    TaiKhoan taikhoan = db.TaiKhoans.Find(id);
                    if (taikhoan != null)
                    {
                        db.Entry(taikhoan).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allTaiKhoan.StatusCode = (int)HttpStatusCode.OK;
                        allTaiKhoan.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                        allTaiKhoan.Message = Constance.DeleteFailed;
                    }
                }
                catch
                {
                    allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                    allTaiKhoan.Message = Constance.DeleteFailed;
                }
            }

            return allTaiKhoan;
        }

        public TaiKhoanResponse Login(string Tk, string Mk)
        {

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {

                List<TaiKhoan> taiKhoan = db.TaiKhoans.Where(c => c.TenTaiKhoan == Tk && c.MatKhau == Mk).ToList();
                TaiKhoanModel = mapper.Map<List<TaiKhoan>, List<TaiKhoanModel>>(taiKhoan);

                if (taiKhoan.Count != 0)
                {

                    //Do something when login
                    allTaiKhoan.Data.AddRange(TaiKhoanModel);
                    allTaiKhoan.StatusCode = (int)HttpStatusCode.OK;
                    allTaiKhoan.Message = Constance.LoginSuccess;
                }
                else
                {
                    allTaiKhoan.StatusCode = (int)HttpStatusCode.NotFound;
                    allTaiKhoan.Message = Constance.LoginFailed;
                }
            }

            return allTaiKhoan;
        }

    }

}