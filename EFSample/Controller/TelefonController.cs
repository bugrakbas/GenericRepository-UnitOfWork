using EFSample.Data.Models;
using EFSample.DataAccess.Repository;
using EFSample.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSample.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonController : ControllerBase
    {
        [HttpPost("create")]
        public string Create(Telefon telefon)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Telefon>().Add(telefon);
                    unitOfWork.Save();
                }
                return "Kayıt Başarılı";
            }
            catch (Exception ex)
            {

                return "Kayıt Başarısız : " + ex.Message;
            }
        }
        [HttpGet("getall")]

        public IEnumerable<Telefon> GetAll()
        {

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.GetRepository<Telefon>().GetAll();
            }
        }
        [HttpGet("get/{id}")]
        public Telefon Get(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.GetRepository<Telefon>().GetById(id);
            }
        }
        [HttpDelete("delete")]
        public string Delete(Telefon telefon)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Telefon>().Remove(telefon);
                    unitOfWork.Save();
                }
                return "Silme Başarılı";
            }
            catch (Exception ex)
            {
                return "Silme Başarısız : " + ex.Message;
            }
        }
        [HttpPut("update")]
        public string Put(Telefon telefon)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<Telefon>().Update(telefon);
                    unitOfWork.Save();
                }
                return "Güncelleme Başarılı";
            }
            catch (Exception ex)
            {
                return "Güncelleme Başarısız : " + ex.Message;
            }
        }
    }
}
