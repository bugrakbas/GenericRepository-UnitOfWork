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
    public class OrderController : ControllerBase
    {      
        [HttpPost("create")]
        public string Create(OrderModel orderModel)
        {
            try
            {
                using (UnitOfWork unitOfWork= new UnitOfWork())
                {
                    unitOfWork.OrderRepository.Add(orderModel);
                    unitOfWork.Save();
                }
                return "Kayıt Başarılı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [HttpGet("getall")]
        public IEnumerable<OrderModel> GetAll()
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.OrderRepository.GetAll();
            }


        }
        [HttpGet("get/{id}")]
        public OrderModel Get(int id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                return unitOfWork.OrderRepository.GetById(id);
            }
            
        }

        [HttpDelete("delete")]
        public string Delete(OrderModel orderModel)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrderRepository.Remove(orderModel);
                    unitOfWork.Save();
                }
                return "Silme Başarılı";
            }
            catch (Exception ex)
            {

                return "Silme Başarısız : " + ex.Message;
            }
            
        }
        // try-catch koyulacak hepsine
        [HttpPut("put")]
        public string Put(OrderModel orderModel)
        {

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.GetRepository<OrderModel>().Update(orderModel);
                    unitOfWork.Save();
                }
                return "Güncelleme Başarılı";
            }
            catch (Exception ex)
            {
                return "Silme Başarısız : " + ex.Message;
                
            }
        }

    }
}
