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
    public class QuyenRepository
    {
        private static MapperConfiguration config;
        private static Mapper mapper;
        private static QuyenResponse allQuyen;
        private static List<QuyenModel> quyenModel;

        public QuyenRepository()
        {
            config = new MapperConfiguration(mc => mc.CreateMap<Quyen, QuyenModel>());
            mapper = new Mapper(config);
            allQuyen = new QuyenResponse();
            quyenModel = new List<QuyenModel>();
        }

        public QuyenResponse GetAllQuyen()
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<Quyen> quyen = db.Quyens.ToList();
                quyenModel = mapper.Map<List<Quyen>, List<QuyenModel>>(quyen);
            }

            if (quyenModel.Count != 0)
            {
                allQuyen.Data.AddRange(quyenModel);
                allQuyen.StatusCode = (int)HttpStatusCode.OK;
                allQuyen.Message = Constance.MessageSuccess;
            }
            else
            {
                allQuyen.StatusCode = (int)HttpStatusCode.NotFound;
                allQuyen.Message = Constance.MessageFailed;
            }

            return allQuyen;
        }

        public QuyenResponse GetQuyenById(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                List<Quyen> quyen = db.Quyens.Where(m => m.MaQuyen == id).ToList();
                quyenModel = mapper.Map<List<Quyen>, List<QuyenModel>>(quyen);
            }

            if (quyenModel.Count != 0)
            {
                allQuyen.Data.AddRange(quyenModel);
                allQuyen.StatusCode = (int)HttpStatusCode.OK;
                allQuyen.Message = Constance.MessageSuccess;
            }
            else
            {
                allQuyen.StatusCode = (int)HttpStatusCode.NotFound;
                allQuyen.Message = Constance.MessageFailed;
            }

            return allQuyen;
        }

        public QuyenResponse InsertQuyen(QuyenModel quyenModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<QuyenModel, Quyen>());
            mapper = new Mapper(config);
            Quyen quyen = new Quyen();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    quyen = db.Quyens.Where(m => m.MaQuyen == quyenModel.MaQuyen).FirstOrDefault();
                    if (quyen != null)
                    {
                        allQuyen.StatusCode = (int)HttpStatusCode.Conflict;
                        allQuyen.Message = Constance.DuplicateID + quyenModel.MaQuyen;
                        return allQuyen;
                    }

                    quyen = mapper.Map<QuyenModel, Quyen>(quyenModel);
                    db.Quyens.Add(quyen);
                    db.SaveChanges();

                    allQuyen.StatusCode = (int)HttpStatusCode.Created;
                    allQuyen.Message = Constance.InsertSuccess;
                }
                catch {
                    allQuyen.StatusCode = (int)HttpStatusCode.BadRequest;
                    allQuyen.Message = Constance.InsertFailed;
                }
            }

            return allQuyen;
        }

        public QuyenResponse UpdateQuyen(QuyenModel quyenModel)
        {
            config = new MapperConfiguration(mc => mc.CreateMap<QuyenModel, Quyen>());
            mapper = new Mapper(config);
            Quyen quyen = new Quyen();

            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    quyen = db.Quyens.Find(quyenModel.MaQuyen);
                    if (quyen != null)
                    {
                        allQuyen.StatusCode = (int)HttpStatusCode.OK;
                        allQuyen.Message = Constance.UpdateSuccess;

                        quyen = mapper.Map<QuyenModel, Quyen>(quyenModel, quyen);
                        db.Set<Quyen>().Attach(quyen);
                        db.Entry<Quyen>(quyen).State = System.Data.Entity.EntityState.Modified; 
                        db.SaveChanges();

                        return allQuyen;
                    }

                    allQuyen.StatusCode = (int)HttpStatusCode.NotFound;
                    allQuyen.Message = Constance.UpdateFailed;
                }
                catch(DbEntityValidationException ex)
                {
                    allQuyen.StatusCode = (int)HttpStatusCode.BadRequest;
                    allQuyen.Message = Constance.UpdateFailed;
                }
            }
            return allQuyen;
        }

        public QuyenResponse DeleteQuyen(string id)
        {
            using (TracNghiemDataModel db = new TracNghiemDataModel())
            {
                try
                {
                    Quyen quyen = db.Quyens.Find(id);
                    if (quyen != null)
                    {
                        db.Entry(quyen).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        allQuyen.StatusCode = (int)HttpStatusCode.OK;
                        allQuyen.Message = Constance.DeleteSuccess;
                    }
                    else
                    {
                        allQuyen.StatusCode = (int)HttpStatusCode.NotFound;
                        allQuyen.Message = Constance.DeleteFailed;
                    }
                }
                catch {
                    allQuyen.StatusCode = (int)HttpStatusCode.NotFound;
                    allQuyen.Message = Constance.DeleteFailed;
                }
            }

            return allQuyen;
        }
    }
}