using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _env;
        public CarServices
            (
                shopDbContext context,
                IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<Cars> Delete(Guid id)
        {
            var carId = await _context.Cars
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

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
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = DateTime.Now;
            cars.CreatedAt = DateTime.Now;
            ProcessUploadedFile(dto, cars);

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
            cars.Amount = dto.Amount;
            cars.Price = dto.Price;
            cars.ModifiedAt = dto.ModifiedAt;
            cars.CreatedAt = dto.CreatedAt;
            ProcessUploadedFile(dto, cars);

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();

            return cars;
        }
        public async Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto)
        {
            var imageId = await _context.ExistingFilePath
                .FirstOrDefaultAsync(x => x.Id == dto.PhotoId);

            _context.ExistingFilePath.Remove(imageId);

            await _context.SaveChangesAsync();

            return imageId;
        }
        public string ProcessUploadedFile(CarDto dto, Cars cars)
        {
            string uniqueFileName = null;
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_env.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\multipleFileUpload\\");
                }
                foreach (var photo in dto.Files)
                {
                    string uploadFolder = Path.Combine(_env.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                        ExistingFilePath paths = new ExistingFilePath
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            CarId = cars.Id
                        };
                        _context.ExistingFilePath.Add(paths);
                    }
                }
            }
            return uniqueFileName;
        }
    }
}
