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
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Car
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Car.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

    }
}
