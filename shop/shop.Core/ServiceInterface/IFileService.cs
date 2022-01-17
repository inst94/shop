using shop.Core.Domain;
using shop.Core.Dtos;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface IFileService : IApplicatonService
    {
        string ProcessUploadedFile(CarDto dto, Cars cars);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathCarDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathCarDto[] dto);
    }
}