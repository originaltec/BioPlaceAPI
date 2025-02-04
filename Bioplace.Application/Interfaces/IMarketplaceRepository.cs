using BioPlace.Domain.Entities.WooProduct;
using BioPlace.Domain.Entities.Vendors;
using BioPlace.Domain.Entities.Categories;
using BioPlace.Domain.Entities.Products;

namespace Bioplace.Application.Interfaces
{
    public interface IMarketplaceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<string?> GetTokenAsync(string username, string password);
        Task<Product?> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);

        Task<IEnumerable<WooProduct>> GetWooProductsAsync();
        Task<IEnumerable<Product>> GetWooProductByIdAsync(int productId);

        /* Vendors */
        Task<IEnumerable<Vendor>> GetVendorsAsync();

        /* Categories */
        Task<IEnumerable<BioPlace.Domain.Entities.Categories.Category>> GetCategoriesSync();
    }
}
