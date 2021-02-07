using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using otec.egory.api.dto;
using otec.egory.api.IO.Base;
using otec.egory.api.IO.Reponse;

namespace otec.egory.api.Controllers
{
    /// <summary>
    /// Контроллер для работы с карточками товаров
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly DataContext context;

        /// <summary>
        /// Контроллер для работы с карточками товаров
        /// </summary>
        /// <param name="context">Контекст данных EF</param>
        public CardController(DataContext context)
        {
            this.context = context;
        }
        
        /// <summary>
        /// Возвращает все карточки товаров
        /// </summary>
        /// <returns>Массив объектов <see cref="CardResponseModel">CardResponseModel</see></returns>
        /// <response code="200">Массив с карточками товаров</response>
        /// <response code="500">Описание ошибки</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CardResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Index()
        {
            try
            {
                var cards = context.Products
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

        /// <summary>
        /// Возвращает каточку товара
        /// </summary>
        /// <returns>Карточка товара</returns>
        /// <param name="id">GUID продукта</param>
        /// <response code="200">Карточка товара</response>
        /// <response code="500">Описание ошибки</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CardResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status500InternalServerError)]
        public IActionResult Index(Guid id)
        {
            try
            {
                var card = context.Products
                    .Where(product => product.IsActive && product.Id == id)
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
                    .Single();

                return new JsonResult(card);
            }
            catch (Exception e)
            {
                var response = new ErrorResult
                {
                    Error = e.InnerException?.Message ?? e.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };

                return new JsonResult(response);
            }
        }
    }
}