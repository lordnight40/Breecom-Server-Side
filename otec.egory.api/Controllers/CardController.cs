using System.Linq;
using Microsoft.AspNetCore.Mvc;
using otec.egory.api.dto;
using otec.egory.api.IO;
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
        public IActionResult Index()
        {
            var cards = _context.Products.ToArray();
            return new JsonResult(new CardsResponse { Success = true, Error = null, Data = cards });
        }
    }
}