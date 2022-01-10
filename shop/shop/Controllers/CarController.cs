using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using shop.Models.Files;
using Microsoft.EntityFrameworkCore;
using shop.Models.Car;

namespace shop.Controllers
{
    public class CarController : Controller
    {
        private readonly shopDbContext _context;
        private readonly ICarService _carService;

        public CarController
            (
                shopDbContext context,
                ICarService carService
            )
        {
            _context = context;
            _carService = carService;

        }

        public IActionResult Index()
        {
            var result = _context.Car
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    Price = x.Price,
                    Amount = x.Amount,
                    Model = x.Model,

                });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _carService.Delete(id);

            if (cars == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}