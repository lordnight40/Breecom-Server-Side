using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using otec.egory.api.dto;
using otec.egory.api.IO;
using otec.egory.api.IO.Base;
using otec.egory.api.IO.Reponse;

namespace otec.egory.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private DataContext _context;

        public CardController(DataContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Возвращает все карточки товаров
        /// </summary>
        /// <returns>Массив объектов</returns>
        [HttpGet]
        public JsonResult Index()
        {
            try
            {
                var cards = _context.Products
                    .Where(product => product.IsActive)
                    .Select(product => new CardResponseModel
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Brand = new BrandResponseModel
                        {
                            Info = product.Brand.Info,
                            Name = product.Brand.Name
                        }
                    })
                    .AsEnumerable();

                var response = new SuccessResultWithData<IEnumerable<CardResponseModel>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = cards
                };
            
                return new JsonResult(cards);
            }
            catch (Exception e)
            {
                var response = new ErrorResult()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Error = e.InnerException?.Message ?? e.Message
                };
                
                return new JsonResult(response);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            return Ok();
        }
    }
}