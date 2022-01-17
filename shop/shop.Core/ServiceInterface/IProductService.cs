using shop.Core.Domain;
using shop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace shop.Core.ServiceInterface
{
    public interface IProductService : IApplicationService
    {
        Task<Product> Delete(Guid id);
        Task<Product> Add(ProductDto dto);
        Task<Product> Edit(Guid id);
        Task<Product> Update(ProductDto dto);
    }
}
