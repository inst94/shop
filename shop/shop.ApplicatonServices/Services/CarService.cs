using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class CarService : ICarService
    {
        private readonly shopDbContext _context;
        private readonly IFileService _file;
        public CarService
            (
                shopDbContext context,
                IFileService file
            )
        {
            _context = context;
            _file = file;
        }
        public async Task<Cars> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePathCar
               .Where(x => x.CarId == id)
               .Select(y => new ExistingFilePathCarDto
               {
                   CarId = y.CarId,
                   FilePath = y.FilePath,
                   PhotoId = y.Id
               })
               .ToArrayAsync();

            var carId = await _context.Cars
                .Include(x => x.ExistingFilePathsCar)
                .FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
        public async Task<Cars> Add(CarDto dto)
        {
            Cars cars = new Cars();

            cars.Id = Guid.NewGuid();
            cars.Mark = dto.Mark;
            cars.Model = dto.Model;
            cars.Year = dto.Year;
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = DateTime.Now;
            cars.CreatedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, cars);

            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();

            return cars;
        }
        public async Task<Cars> Edit(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Cars> Update(CarDto dto)
        {
            Cars cars = new Cars();

            cars.Id = dto.Id;
            cars.Mark = dto.Mark;
            cars.Model = dto.Model;
            cars.Year = dto.Year;
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = dto.ModifiedAt;
            cars.CreatedAt = dto.CreatedAt;
            _file.ProcessUploadedFile(dto, cars);

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();

            return cars;
        }
    }
}
