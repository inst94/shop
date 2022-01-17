using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;
using shop.Core.Dtos;
using shop.Core.ServiceInterface;
using shop.Data;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace shop.ApplicatonServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly shopDbContext _context;
        private readonly IFileService _file;
        public ProductServices
            (
                shopDbContext context,
                IFileService file
            )
        {
            _context = context;
            _file = file;
        }
        public async Task<Product> Delete(Guid id)
        {
            var photos = await _context.ExistingFilePath
               .Where(x => x.ProductId == id)
               .Select(y => new ExistingFilePathDto
               {
                   ProductId = y.ProductId,
                   FilePath = y.FilePath,
                   PhotoId = y.Id
               })
               .ToArrayAsync();

            var productId = await _context.Product
                .Include(x => x.ExistingFilePaths)
                .FirstOrDefaultAsync(x => x.Id == id);

            await _file.RemoveImages(photos);
            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }
        public async Task<Product> Add(ProductDto dto)
        {
            Product product = new Product();

            product.Id = Guid.NewGuid();
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = DateTime.Now;
            product.CreatedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, product);

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<Product> Edit(Guid id)
        {
            var result = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
            
        }
        public async Task<Product> Update(ProductDto dto)
        {
            Product product = new Product();

            product.Id = dto.Id;
            product.Description = dto.Description;
            product.Name = dto.Name;
            product.Amount = dto.Amount;
            product.Price = dto.Price;
            product.ModifiedAt = dto.ModifiedAt;
            product.CreatedAt = dto.CreatedAt;
            _file.ProcessUploadedFile(dto, product);

            _context.Product.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
