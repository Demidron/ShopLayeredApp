using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.WebAPI.Controllers
{
   
    public class GoodsController : ApiController
    {
        IGenericService<GoodDTO> goodService;

        public GoodsController(IGenericService<GoodDTO> goodService)
        {
            this.goodService = goodService;
        }
        /// <summary>
        /// Получаю список всех товаров
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAll()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, goodService.GetAll());
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить список ВСЕХ товаров");
            }
        }
        /// <summary>
        /// Получаю товар по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var good = goodService.Get(id);
                return (good!=null) ? Request.CreateResponse(HttpStatusCode.OK, good)
                    : Request.CreateResponse(HttpStatusCode.NotFound, $"Не найден товар  c id = {id}"); ;
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Не смогли получить  товар  c id = {id}");
            }
        }
        [HttpPost]
        [ActionName("Find")]
        public HttpResponseMessage Post([FromBody]ViewModelFind vm)
        {
            try
            {
                ViewModelFindExt findExt = new ViewModelFindExt
                {
                    ModelFind = vm
                };
                return Request.CreateResponse(HttpStatusCode.OK, goodService.FindBy(findExt.Predicate));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить список товаров");
            }
        }
        [HttpPost]
        [ActionName("Filter")]
        public HttpResponseMessage Filter([FromBody] ViewModelFind vm)
        {
         
            try
            {
                ViewModelFindExt findExt = new ViewModelFindExt
                {
                    ModelFind = vm
                };
                return Request.CreateResponse(HttpStatusCode.OK, goodService.FindBy(findExt.Predicate));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Не смогли получить список товаров");
            }
        }



















        //[HttpPost]
        ////[Route(Name = "api/Goods/Find")]
        //public HttpResponseMessage FindBy(ViewModelFind vm)
        //{
        //    try
        //    {
        //        var good = goodService.FindBy(vm.Predicate);
        //        return (good != null) ? Request.CreateResponse(HttpStatusCode.OK, good)
        //            : Request.CreateResponse(HttpStatusCode.NotFound, $"Не найден товар  "); ;
        //    }
        //    catch (Exception exc)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, $"Не смогли получить  товар  ");
        //    }
        //}

    }
}
