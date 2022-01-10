using shop.Core.Domain;
using shop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<Car> Delete(Guid id);
    }
}
