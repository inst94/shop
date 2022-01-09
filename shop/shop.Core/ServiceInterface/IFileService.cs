using shop.Core.Domain;
using shop.Core.Dtos;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface IFileService : IApplicationService
    {
        string ProcessUploadedFile(ProductDto dto, Product product);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto);
    }
}
