using System.Net.Http.Headers;
using System.Net.Http.Json;
using Bioplace.Application.DTOs;
using Bioplace.Application.Interfaces;
using BioPlace.Domain.Entities;


namespace BioPlace.Infrastructure.Repositories
{
    public class MarketplaceRepository : IMarketplaceRepository
    {
        private readonly HttpClient _httpClient;
        private string _token;

        public MarketplaceRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetTokenAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress + "jwt-auth/v1/token", new { username, password });
            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                _token = tokenResponse?.Token ?? string.Empty;
                return _token;
            }
            return string.Empty;
        }

        private void SetAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "dokan/v1/products");            
            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
                return products ?? Enumerable.Empty<Product>();
            }
            else
            {
                // Manejar el error de la respuesta
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            SetAuthorizationHeader();
            return await _httpClient.GetFromJsonAsync<Product>($"wp-json/dokan/v1/products/{id}");
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PostAsJsonAsync("wp-json/dokan/v1/products", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.PutAsJsonAsync($"wp-json/dokan/v1/products/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            SetAuthorizationHeader();
            var response = await _httpClient.DeleteAsync($"wp-json/dokan/v1/products/{id}");
            return response.IsSuccessStatusCode;
        }

        // Woocommerce Products
        public async Task<IEnumerable<WooProduct>> GetWooProductsAsync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var allProducts = new List<WooProduct>();
            int page = 1;
            bool morePages = true;

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
                    // Manejar el error de la respuesta
                    morePages = false;
                }
            }

            return allProducts;
        }

        public async Task<IEnumerable<Product>> GetWooProductByIdAsync(int productId)
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            Product product = null;
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}wc/v3/products/{productId}");

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                throw new Exception("Error al obtener el producto");
            }

            return new List<Product> { product };
        }


        public async Task<IEnumerable<Vendor>> GetVendorsAsync()
        {
            var token = await GetTokenAsync("bioplace_apiu", "NXZ%jZb5XD^hHyK^k*");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "dokan/v1/vendors");

            if (response.IsSuccessStatusCode)
            {
                var vendors = await response.Content.ReadFromJsonAsync<IEnumerable<Vendor>>();
                return vendors ?? Enumerable.Empty<Vendor>();
            }
            else
            {
                return Enumerable.Empty<Vendor>();
            }
        }



    }
}
