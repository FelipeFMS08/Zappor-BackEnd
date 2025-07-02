using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappor.Application.DTO.Request;
using Zappor.Domain.Entities;

namespace Zappor.Application.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllAsync();

        public Task<Product?> GetByIdAsync(Guid id);
        public Task<Product> CreateAsync(ProductDTO dto);
        public Task<bool> UpdateAsync(Guid id, ProductDTO dto);
        public Task<bool> DeleteAsync(Guid id);
    }
}
