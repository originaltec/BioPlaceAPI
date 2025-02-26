using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;
using System.Text;
using Bioplace.Application.DTOs;
using Bioplace.Application.Interfaces;
using BioPlace.Domain.Entities.Orders;
using BioPlace.Domain.Entities.Stores;
using BioPlace.Domain.Entities.WooProduct;
using BioPlace.Domain.Entities.Stores;
using Domain.Entities.Stores;

namespace BioPlace.Infrastructure.Repositories
{
    // MarketplaceRepository handles communication with a marketplace API to manage products, orders, categories, etc.
    public class MarketplaceRepository : IMarketplaceRepository
    {
        private readonly HttpClient _httpClient; // The HttpClient used to make HTTP requests.
        private string _token; // The authentication token used for authorization in API requests.

        // Constructor that accepts an HttpClient to be used for API requests.
        public MarketplaceRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Retrieves an authentication token from the API using a username and password.
        public async Task<string> GetTokenAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "jwt-auth/v1/token", new { username, password });

            // Check if the token request is successful and return the token.
            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                _token = tokenResponse?.Token ?? string.Empty;
                return _token;
            }
            return string.Empty;
        }

        // Sets the authorization header using the stored token.
        private void SetAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }
        }

        // Retrieves all products from the marketplace, requiring an authorization token.
        public async Task<IEnumerable<Domain.Entities.Products.Product>> GetProductsAsync(string authorizationToken)
        {
            if (string.IsNullOrEmpty(authorizationToken))
            {
                return Enumerable.Empty<Domain.Entities.Products.Product>();
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorizationToken);
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "dokan/v1/products");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<IEnumerable<Domain.Entities.Products.Product>>();
                return products ?? Enumerable.Empty<Domain.Entities.Products.Product>();
            }
            else
            {
                return Enumerable.Empty<Domain.Entities.Products.Product>();
            }
        }

        // Retrieves a product by its ID.
        public async Task<Domain.Entities.Products.Product?> GetProductByIdAsync(int id)
        {
            SetAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<Domain.Entities.Products.Product>($"wp-json/dokan/v1/products/{id}");
        }

        // Creates a new product in the marketplace.
        public async Task<bool> CreateProductAsync(Domain.Entities.Products.Product product)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync("wp-json/dokan/v1/products", product);
            return response.IsSuccessStatusCode;
        }

        // Updates an existing product.
        public async Task<bool> UpdateProductAsync(Domain.Entities.Products.Product product)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PutAsJsonAsync($"wp-json/dokan/v1/products/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }

        // Deletes a product by its ID.
        public async Task<bool> DeleteProductAsync(int id)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.DeleteAsync($"wp-json/dokan/v1/products/{id}");
            return response.IsSuccessStatusCode;
        }

        // Retrieves all WooCommerce products from the marketplace.
        public async Task<IEnumerable<WooProduct>> GetWooProductsAsync(string autheritzation)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autheritzation);

            var allProducts = new List<WooProduct>();
            int page = 1;
            bool morePages = true;

            // Loop to retrieve all products, handling pagination.
            while (morePages)
            {
                var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}wc/v3/products?page={page}&per_page=100");
                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<IEnumerable<WooProduct>>();
                    if (products != null && products.Any())
                    {
                        allProducts.AddRange(products);
                        page++;
                    }
                    else
                    {
                        morePages = false;
                    }
                }
                else
                {
                    // Handle response error and exit the loop.
                    morePages = false;
                }
            }

            return allProducts;
        }

        // Retrieves a WooCommerce product by its ID.
        public async Task<IEnumerable<Domain.Entities.Products.Product>> GetWooProductByIdAsync(int productId)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Domain.Entities.Products.Product product = null;
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}wc/v3/products/{productId}");

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadFromJsonAsync<Domain.Entities.Products.Product>();
            }
            else
            {
                throw new Exception("Error al obtener el producto");
            }

            return new List<Domain.Entities.Products.Product> { product };
        }

        // Updates a WooCommerce product's stock and description.
        public async Task<bool> UpdateWooProductAsync(int productId, int stock_quantity, string description)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var updatedProduct = new
            {
                stock_quantity = stock_quantity,
                description = description,
                manage_stock = true  // Ensure stock management is enabled.
            };

            var content = new StringContent(JsonSerializer.Serialize(updatedProduct), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_httpClient.BaseAddress}wc/v3/products/{productId}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {responseContent}");  // Show error details.
                return false;
            }
        }

        // Retrieves all categories from the WooCommerce store.
        public async Task<IEnumerable<Domain.Entities.Categories.Category>> GetCategoriesSync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "wc/v3/products/categories");

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<IEnumerable<Domain.Entities.Categories.Category>>();
                return categories ?? Enumerable.Empty<Domain.Entities.Categories.Category>();
            }
            else
            {
                return Enumerable.Empty<Domain.Entities.Categories.Category>();
            }
        }

        // Retrieves a category by its ID.
        public async Task<Domain.Entities.Categories.Category> GetCategoryById(int categoryId)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"wc/v3/products/categories/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                var category = await response.Content.ReadFromJsonAsync<Domain.Entities.Categories.Category>();
                return category;
            }
            else
            {
                return null;
            }
        }

        // Retrieves all WooCommerce orders.
        public async Task<IEnumerable<Order>> GetWooOrdersSync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "wc/v3/orders");

            if (response.IsSuccessStatusCode)
            {
                var orders = await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
                return orders ?? Enumerable.Empty<Order>();
            }
            else
            {
                return Enumerable.Empty<Order>();
            }
        }

        // Retrieves a specific WooCommerce order by its ID.
        public async Task<Order> GetWooOrderByIdSync(int orderId)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"wc/v3/orders/{orderId}");

            if (response.IsSuccessStatusCode)
            {
                var order = await response.Content.ReadFromJsonAsync<Order>();
                return order;
            }
            else
            {
                return null;
            }
        }

        // Retrieves all stores from the marketplace.
        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "dokan/v1/stores");

            if (response.IsSuccessStatusCode)
            {
                var stores = await response.Content.ReadFromJsonAsync<IEnumerable<Store>>();
                return stores ?? Enumerable.Empty<Store>();
            }
            else
            {
                return Enumerable.Empty<Store>();
            }
        }

        // Retrieves a specific store by its ID.
        public async Task<Store?> GetStoreByIdAsync(int storeId)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + $"dokan/v1/stores/{storeId}");

            if (response.IsSuccessStatusCode)
            {
                var store = await response.Content.ReadFromJsonAsync<Store>();
                return store;
            }
            else
            {
                return null;
            }
        }
    }
}
