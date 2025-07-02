using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappor.Application.DTO.Request;
using Zappor.Domain.Entities;
using Zappor.Infrastructure.Persistence;

namespace Zappor.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ZapporDbContext _context;
        public ProductService(ZapporDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Quantity = dto.Quantity
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateAsync(Guid id, ProductDTO dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
