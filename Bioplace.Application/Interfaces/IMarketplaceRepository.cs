using BioPlace.Domain.Entities;


namespace Bioplace.Application.Interfaces
{
    public interface IMarketplaceRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();        
        Task<string?>   GetTokenAsync(string username, string password);
        Task<Product?> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<WooProduct>> GetWooProductsAsync();

        /* Vendors */
        Task<IEnumerable<dynamic>> GetVendorsAsync();
        
    }

}
