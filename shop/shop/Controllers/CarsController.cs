using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using shop.Views.Cars;
using shop.Models.Files;
using Microsoft.EntityFrameworkCore;
using shop.Models.Cars;

namespace shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly shopDbContext _context;
        private readonly ICarService _carService;

        public CarsController(shopDbContext context, ICarService carService)
        {
            _context = context;
            _carService = carService;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsListViewModel
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    Price = x.Price,
                    Amount = x.Amount,
                    Model = x.Model,

                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()

        {
            CarsViewModel model = new CarsViewModel();
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CarsViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Model = model.Model,
                Mark = model.Mark,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
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
               .Select(y => new ExistingFilePathViewModel
               {
                   FilePath = y.FilePath,
                   PhotoId = y.Id
               })
               .ToArrayAsync();

            var model = new CarsViewModel();

            model.Id = cars.Id;
            model.Mark = cars.Mark;
            model.Model = cars.Model;
            model.Amount = cars.Amount;
            model.Price = cars.Price;
            model.ModifiedAt = cars.ModifiedAt;
            model.CreatedAt = cars.CreatedAt;
            model.ExistingFilePaths.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsViewModel model)
        {
            var dto = new CarDto()
            {
                Id = model.Id,
                Mark = model.Mark,
                Model = model.Model,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                    .Select(x => new ExistingFilePathDto
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
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _carService.Delete(id);

            if (cars == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                PhotoId = model.PhotoId
            };
            var image = await _carService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
