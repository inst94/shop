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
        public CarService
            (
                shopDbContext context
            )
        {
            _context = context;
        }
        public async Task<Cars> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
        public async Task<Cars> Add(CarDto dto)
        {
            Cars cars = new Cars();
            FileToDatabase file = new FileToDatabase();

            cars.Id = Guid.NewGuid();
            cars.Mark = dto.Mark;
            cars.Model = dto.Model;
            cars.Year = dto.Year;
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = DateTime.Now;
            cars.CreatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, cars);
            }

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
            FileToDatabase file = new FileToDatabase();

            cars.Id = dto.Id;
            cars.Mark = dto.Mark;
            cars.Model = dto.Model;
            cars.Year = dto.Year;
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = dto.ModifiedAt;
            cars.CreatedAt = dto.CreatedAt;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, cars);
            }

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();

            return cars;
        }
        public byte[] UploadFile(CarDto dto, Cars cars)
        {

            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            CarId = cars.Id
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }
            return null;
        }
    }
}
