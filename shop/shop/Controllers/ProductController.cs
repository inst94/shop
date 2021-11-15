using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.Data;
using shop.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly shopDbContext _context;
        public ProductController
            (
                shopDbContext context
                
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Product
                .Select(x => new ProductListViewModel
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    Description = x.Description,

                });
            return View(result);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);
            return RedirectToAction(nameof(Index), product);
        }
    }
}
