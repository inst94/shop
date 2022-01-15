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
    public class CarFileServices : IFileService
    {
        private readonly shopDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CarFileServices
            (
                shopDbContext context,
                IWebHostEnvironment env
            )
        {
            _context = context;
            _env = env;
        }
        public async Task<ExistingFilePathCar> RemoveImage(ExistingFilePathCarDto dto)
        {
            var imageId = await _context.ExistingFilePathCar
                .FirstOrDefaultAsync(x => x.FilePath == dto.FilePath);

            string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dto.FilePath;

            File.Delete(photoPath);

            _context.ExistingFilePathCar.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }
        public async Task<ExistingFilePathCar> RemoveImages(ExistingFilePathCarDto[] dto)
        {
            foreach (var dtos in dto)
            {
                var fileId = await _context.ExistingFilePathCar
                .FirstOrDefaultAsync(x => x.FilePath == dtos.FilePath);

                string photoPath = _env.WebRootPath + "\\multipleFileUpload\\" + dtos.FilePath;

                File.Delete(photoPath);

                _context.ExistingFilePathCar.Remove(fileId);
                await _context.SaveChangesAsync();
            }

            return null;
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
                        ExistingFilePathCar paths = new ExistingFilePathCar
                        {
                            Id = Guid.NewGuid(),
                            FilePath = uniqueFileName,
                            CarId = cars.Id
                        };
                        _context.ExistingFilePathCar.Add(paths);
                    }
                }
            }
            return uniqueFileName;
        }
    }
}
