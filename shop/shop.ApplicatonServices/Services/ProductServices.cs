using Microsoft.EntityFrameworkCore;
using shop.Core.Domain;
using shop.Core.ServiceInterface;
using shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.ApplicatonServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly shopDbContext _context;
        public ProductServices
            (
                shopDbContext context
            )
        {
            _context = context;
        }
        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }
    }
}
