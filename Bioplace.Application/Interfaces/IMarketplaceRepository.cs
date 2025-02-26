using BioPlace.Domain.Entities.WooProduct;
using BioPlace.Domain.Entities.Categories;
using BioPlace.Domain.Entities.Products;
using BioPlace.Domain.Entities.Orders;
using Domain.Entities.Stores;

namespace Bioplace.Application.Interfaces
{
    // Interface for repository operations related to the marketplace
    public interface IMarketplaceRepository
    {
        // Retrieves an authentication token using username and password
        Task<string> GetTokenAsync(string username, string password);

        // Retrieves all products from the marketplace
        Task<IEnumerable<Product>> GetProductsAsync(string authorizationToken);

        // Retrieves a product by its ID
        Task<Product?> GetProductByIdAsync(int id);

        // Creates a new product in the marketplace
        Task<bool> CreateProductAsync(Product product);

        // Updates an existing product in the marketplace
        Task<bool> UpdateProductAsync(Product product);

        // Deletes a product by its ID
        Task<bool> DeleteProductAsync(int id);

        // Retrieves all WooCommerce products
        Task<IEnumerable<WooProduct>> GetWooProductsAsync(string authorizationToken);

        // Retrieves a WooCommerce product by its ID
        Task<IEnumerable<Product>> GetWooProductByIdAsync(int productId);

        // Updates a WooCommerce product's stock quantity and description
        Task<bool> UpdateWooProductAsync(int productId, int stock_quantity, string description);

        // Retrieves all categories from the marketplace
        Task<IEnumerable<BioPlace.Domain.Entities.Categories.Category>> GetCategoriesSync();

        // Retrieves a category by its ID
        Task<BioPlace.Domain.Entities.Categories.Category> GetCategoryById(int categoryId);

        // Retrieves all WooCommerce orders
        Task<IEnumerable<Order>> GetWooOrdersSync();

        // Retrieves a specific WooCommerce order by its ID
        Task<Order> GetWooOrderByIdSync(int orderId);

        // Retrieves all stores from the marketplace
        Task<IEnumerable<Domain.Entities.Stores.Store>> GetStoresAsync();

        // Retrieves a specific store by its ID
        Task<Domain.Entities.Stores.Store?> GetStoreByIdAsync(int storeId);
    }
}
