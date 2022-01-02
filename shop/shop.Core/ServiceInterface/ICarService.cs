using shop.Core.Domain;
using shop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface ICarService
    {
        Task<Cars> Delete(Guid id);
        Task<Cars> Add(CarDto dto);
        Task<Cars> Edit(Guid id);
        Task<Cars> Update(CarDto dto);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
    }
}
