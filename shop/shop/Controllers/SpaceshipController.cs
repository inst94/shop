using Microsoft.AspNetCore.Mvc;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using shop.Models.Spaceship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly shopDbContext _context;
        private readonly ISpaceshipService _spaceshipService;
        public SpaceshipController
            (
                shopDbContext context,
                ISpaceshipService spaceshipService

            )
        {
            _context = context;
            _spaceshipService = spaceshipService;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceship
                .Select(x => new SpaceshipListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Mass = x.Mass,
                    Price = x.Price,
                    Crew = x.Crew,

                });
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _spaceshipService.Delete(id);

            if (product == null)
            {
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Add()

        {
            SpaceshipViewModel model = new SpaceshipViewModel();
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Type = model.Type,
                Name = model.Name,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                Constructed = model.Constructed,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,

            };
            var result = await _spaceshipService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var spaceship = await _spaceshipService.Edit(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var model = new SpaceshipViewModel();
            model.Id = spaceship.Id;
            model.Type = spaceship.Type;
            model.Name = spaceship.Name;
            model.Mass = spaceship.Mass;
            model.Price = spaceship.Price;
            model.Crew = spaceship.Crew;
            model.Constructed = spaceship.Constructed;
            model.ModifiedAt = spaceship.ModifiedAt;
            model.CreatedAt = spaceship.CreatedAt;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipViewModel model)
        {
            var dto = new SpaceshipDto()
            {
                Id = model.Id,
                Type = model.Type,
                Name = model.Name,
                Mass = model.Mass,
                Price = model.Price,
                Crew = model.Crew,
                Constructed = model.Constructed,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt,
            };
            var result = await _spaceshipService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), model);
        }
    }
}
