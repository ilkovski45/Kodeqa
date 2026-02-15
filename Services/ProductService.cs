using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
    {
        
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, ProductUpdateDto dto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return false;
        }
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        return await _context.Products
            .Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var p = await _context.Products.FindAsync(id);
        if (p == null) return null;

        return new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
