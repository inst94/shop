using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using System;
using System.IO;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class CarServices : ICarService
    {
        private readonly shopDbContext _context;
        public CarServices
            (
                shopDbContext context
            )
        {
            _context = context;
        }
        public async Task<Car> Delete(Guid id)
        {
            var car = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Add(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = Guid.NewGuid();
            car.Mark = dto.Mark;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Amount = dto.Amount;
            car.Price = dto.Price;
            car.ModifiedAt = DateTime.Now;
            car.CreatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, car);
            }

            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Edit(Guid id)
        {
            var result = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
        public async Task<Car> Update(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();

            car.Id = dto.Id;
            car.Mark = dto.Mark;
            car.Model = dto.Model;
            car.Year = dto.Year;
            car.Amount = dto.Amount;
            car.Price = dto.Price;
            car.ModifiedAt = dto.ModifiedAt;
            car.CreatedAt = dto.CreatedAt;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, car);
            }

            _context.Car.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public byte[] UploadFile(CarDto dto, Car car)
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
                            CarId = car.Id
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
