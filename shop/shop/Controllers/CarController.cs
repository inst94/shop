using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using shop.Models.Files;
using Microsoft.EntityFrameworkCore;
using shop.Models.Cars;

namespace shop.Controllers
{
    public class CarController : Controller
    {
        private readonly shopDbContext _context;
        private readonly ICarService _carService;
        private readonly IFileService _file;
        public CarController
            (
                shopDbContext context,
                ICarService carService,
                IFileService file
            )
        {
            _context = context;
            _carService = carService;
            _file = file;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarListViewModel
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    Price = x.Price,
                    Amount = x.Amount,
                    Model = x.Model,
                    Year = x.Year,

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

        [HttpGet]
        public IActionResult Add()
        {
            CarViewModel model = new CarViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Mark = model.Mark,
                Model = model.Model,
                Year = model.Year,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePathsCar = model.ExistingFilePathsCar
                    .Select(x => new ExistingFilePathCarDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };

            var result = await _carService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cars = await _carService.Edit(id);
            if (cars == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePathCar
               .Where(x => x.CarId == id)
               .Select(y => new ExistingFilePathCarViewModel
               {
                   FilePath = y.FilePath,
                   PhotoId = y.Id
               })
               .ToArrayAsync();

            var model = new CarViewModel();

            model.Id = cars.Id;
            model.Mark = cars.Mark;
            model.Model = cars.Model;
            model.Year = cars.Year;
            model.Amount = cars.Amount;
            model.Price = cars.Price;
            model.ModifiedAt = cars.ModifiedAt;
            model.CreatedAt = cars.CreatedAt;
            model.ExistingFilePathsCar.AddRange(photos);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Mark = model.Mark,
                Model = model.Model,
                Year = model.Year,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePathsCar = model.ExistingFilePathsCar
                    .Select(x => new ExistingFilePathCarDto
                    {
                        PhotoId = x.PhotoId,
                        FilePath = x.FilePath,
                        CarId = x.CarId
                    }).ToArray()
            };
            var result = await _carService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathCarViewModel model)
        {
            var dto = new ExistingFilePathCarDto()
            {
                FilePath = model.FilePath
            };

            var image = await _file.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}