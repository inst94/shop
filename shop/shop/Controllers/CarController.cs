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
        [HttpGet]
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
                    Year = x.Year,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.Delete(id);

            if (car == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel model = new CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel mod)
        {
            var dto = new CarDto()
            {
                Id = mod.Id,
                Mark = mod.Mark,
                Model = mod.Model,
                Year = mod.Year,
                Amount = mod.Amount,
                Price = mod.Price,
                ModifiedAt = mod.ModifiedAt,
                CreatedAt = mod.CreatedAt,
                Files = mod.Files,
                Image = mod.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId
                }).ToArray()
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.Edit(id);
            if (car == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabase
               .Where(x => x.CarId == id)
               .Select(m => new ImagesViewModel
               {
                   ImageData = m.ImageData,
                   Id = m.Id,
                   Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(m.ImageData)),
                   ImageTitle = m.ImageTitle,
                   CarId = m.Id
               })
               .ToArrayAsync();

            var model = new CarViewModel();

            model.Id = car.Id;
            model.Mark = car.Mark;
            model.Model = car.Model;
            model.Year = car.Year;
            model.Amount = car.Amount;
            model.Price = car.Price;
            model.ModifiedAt = car.ModifiedAt;
            model.CreatedAt = car.CreatedAt;
            model.Image.AddRange(photos);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel mod)
        {
            var dto = new CarDto()
            {
                Id = mod.Id,
                Mark = mod.Mark,
                Model = mod.Model,
                Year = mod.Year,
                Amount = mod.Amount,
                Price = mod.Price,
                ModifiedAt = mod.ModifiedAt,
                CreatedAt = mod.CreatedAt,
                Image = mod.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.Id,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId
                })
            };
            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), mod);
        }
    }
}