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
                ExistingFilePathsCar = mod.ExistingFilePaths
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

            var photos = await _context.ExistingFilePath
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
            model.ExistingFilePaths.AddRange(photos);

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
                Files = mod.Files,
                ExistingFilePathsCar = mod.ExistingFilePaths
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

            return RedirectToAction(nameof(Index), mod);
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