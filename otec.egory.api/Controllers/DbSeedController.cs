using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using otec.egory.api.dto;
using otec.egory.api.dto.Entities;

namespace otec.egory.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbSeedController : ControllerBase
    {
        private readonly DataContext context;

        public DbSeedController(DataContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                if (context.Products.Any())
                {
                    var toRemove = context.Products.AsEnumerable();
                    context.Products.RemoveRange(toRemove);
                    context.SaveChanges();
                }
                if (context.Brands.Any())
                {
                    var toRemove = context.Brands.AsEnumerable();
                    context.Brands.RemoveRange(toRemove);
                    context.SaveChanges();
                }

                var brandNames = new string[] { "Nike", "Raf Simons", "Puma", "Adidas" };

                foreach (var brandName in brandNames)
                {
                    var brand = new Brand
                    {
                        Id = Guid.NewGuid(),
                        Name = brandName,
                        Info = $"This is {brandName}",
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Empty,
                        IsActive = true
                    };
                    context.Brands.Add(brand);
                }

                context.SaveChanges();

                var random = new Random();
                foreach (var brand in context.Brands)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var product = new Product
                        {
                            Id = Guid.NewGuid(),
                            Brand = brand,
                            Name = $"Shoes of {brand.Name} model {i}",
                            Price = Math.Round((decimal)random.NextDouble()) * 1000,
                            CreatedAt = DateTime.Now,
                            CreatedBy = Guid.Empty,
                            IsActive = true
                        };

                        context.Products.Add(product);
                    }
                }

                context.SaveChanges();
                
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}