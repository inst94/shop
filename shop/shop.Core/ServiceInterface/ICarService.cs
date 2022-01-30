using shop.Core.Domain;
using shop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<Car> Delete(Guid id);
        Task<Car> Add(CarDto dto);
        Task<Car> Edit(Guid id);
        Task<Car> Update(CarDto dto);
    }
}
