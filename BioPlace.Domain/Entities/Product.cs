using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Products
{
    // Represents a product entity with all associated details and attributes
    public class Product
    {
        // Unique identifier for the product
        public int Id { get; set; }

        // Name of the product
        public string Name { get; set; } = string.Empty;

        // Slug for SEO-friendly URL generation
        public string Slug { get; set; } = string.Empty;

        // Author of the product post or listing
        public string PostAuthor { get; set; } = string.Empty;

        // Permanent URL for the product
        public string Permalink { get; set; } = string.Empty;

        // Date when the product was created
        public DateTime DateCreated { get; set; }

        // GMT date when the product was created
        public DateTime DateCreatedGmt { get; set; }

        // Date when the product was last modified
        public DateTime DateModified { get; set; }

        // GMT date when the product was last modified
        public DateTime DateModifiedGmt { get; set; }

        // Type/category of the product
        public string Type { get; set; } = string.Empty;

        // Status of the product (e.g., 'available', 'out of stock')
        public string Status { get; set; } = string.Empty;

        // Indicates whether the product is featured
        public bool Featured { get; set; }

        // Visibility of the product in the catalog (e.g., visible, hidden)
        public string CatalogVisibility { get; set; } = string.Empty;

        // Full description of the product
        public string Description { get; set; } = string.Empty;

        // Short description of the product
        public string ShortDescription { get; set; } = string.Empty;

        // SKU (Stock Keeping Unit) for the product
        public string Sku { get; set; } = string.Empty;

        // Price of the product (can be dynamic, e.g., decimal or double)
        public dynamic? Price { get; set; }

        // Regular price before any discounts
        public dynamic? RegularPrice { get; set; }

        // Sale price if the product is on sale
        public dynamic? SalePrice { get; set; }

        // Date when the sale starts (if applicable)
        public DateTime? DateOnSaleFrom { get; set; }

        // GMT date when the sale starts (if applicable)
        public DateTime? DateOnSaleFromGmt { get; set; }

        // Date when the sale ends (if applicable)
        public DateTime? DateOnSaleTo { get; set; }

        // GMT date when the sale ends (if applicable)
        public DateTime? DateOnSaleToGmt { get; set; }

        // HTML representation of the price (e.g., for display purposes)
        public string PriceHtml { get; set; } = string.Empty;

        // Indicates whether the product is currently on sale
        public bool OnSale { get; set; }

        // Indicates whether the product is purchasable
        public bool Purchasable { get; set; }

        // Total number of sales of this product
        public int TotalSales { get; set; }

        // Indicates if the product is virtual (doesn't require shipping)
        public bool Virtual { get; set; }

        // Indicates if the product is downloadable (e.g., software, media)
        public bool Downloadable { get; set; }

        // List of downloadable files associated with the product
        public List<object> Downloads { get; set; } = new();

        // Maximum number of times the product can be downloaded
        public int DownloadLimit { get; set; }

        // Expiry time for downloads in days
        public int DownloadExpiry { get; set; }

        // External URL for the product (if applicable, for affiliate links)
        public string ExternalUrl { get; set; } = string.Empty;

        // Text displayed on the purchase button (e.g., 'Buy Now', 'Add to Cart')
        public string ButtonText { get; set; } = string.Empty;

        // Tax status of the product (e.g., taxable, exempt)
        public string TaxStatus { get; set; } = string.Empty;

        // Tax class for the product (e.g., standard, reduced)
        public string TaxClass { get; set; } = string.Empty;

        // Indicates whether stock management is enabled for the product
        public bool manage_stock { get; set; }

        // The current stock quantity of the product (null if not managed)
        public int? stock_quantity { get; set; }

        // Low stock warning threshold
        public string LowStockAmount { get; set; } = string.Empty;

        // Indicates whether the product is in stock
        public bool InStock { get; set; }

        // Indicates whether backorders are allowed for the product
        public string Backorders { get; set; } = string.Empty;

        // Whether backorders are allowed for this product
        public bool BackordersAllowed { get; set; }

        // Indicates whether the product is currently backordered
        public bool Backordered { get; set; }

        // Indicates if the product can only be purchased individually
        public bool SoldIndividually { get; set; }

        // Weight of the product (used for shipping calculation)
        public string Weight { get; set; } = string.Empty;

        // Dimensions (length, width, height) of the product
        public Dimensions Dimensions { get; set; } = new();

        // Indicates whether shipping is required for this product
        public bool ShippingRequired { get; set; }

        // Indicates whether the product's shipping is taxable
        public bool ShippingTaxable { get; set; }

        // Shipping class for the product (e.g., flat rate, free shipping)
        public string ShippingClass { get; set; } = string.Empty;

        // Shipping class ID
        public int ShippingClassId { get; set; }

        // Indicates whether reviews are allowed for this product
        public bool ReviewsAllowed { get; set; }

        // Average product rating (e.g., '4.5', '5.0')
        public string AverageRating { get; set; } = string.Empty;

        // Number of ratings/reviews the product has received
        public int RatingCount { get; set; }

        // List of related product IDs
        public List<int> RelatedIds { get; set; } = new();

        // List of upsell product IDs (suggested higher-priced items)
        public List<int> UpsellIds { get; set; } = new();

        // List of cross-sell product IDs (suggested complementary items)
        public List<int> CrossSellIds { get; set; } = new();

        // ID of the parent product (for variants or grouped products)
        public int ParentId { get; set; }

        // Purchase note to be displayed on product purchase
        public string PurchaseNote { get; set; } = string.Empty;

        // Categories this product belongs to
        public List<Category> Categories { get; set; } = new();

        // Tags associated with the product
        public List<object> Tags { get; set; } = new();

        // List of images associated with the product
        public List<Image> Images { get; set; } = new();

        // List of custom product attributes (e.g., size, color)
        public List<object> Attributes { get; set; } = new();

        // Default attributes for the product (e.g., default size or color)
        public List<object> DefaultAttributes { get; set; } = new();

        // Variations of the product (e.g., different sizes or colors)
        public List<object> Variations { get; set; } = new();

        // Grouped products (products sold together as a bundle)
        public List<object> GroupedProducts { get; set; } = new();

        // Menu order for displaying products in a specific sequence
        public int MenuOrder { get; set; }

        // Metadata for the product (e.g., custom fields or extra info)
        public List<MetaData> MetaData { get; set; } = new();

        // Store details that this product belongs to
        public Store Store { get; set; } = new();

        // Row actions (e.g., edit, delete, view, etc.) for managing the product
        public RowActions RowActions { get; set; } = new();

        // Links related to the product (e.g., self, collection)
        public Links Links { get; set; } = new();
    }

    // Represents the dimensions of the product (length, width, height)
    public class Dimensions
    {
        public string Length { get; set; } = string.Empty;  // Length of the product
        public string Width { get; set; } = string.Empty;   // Width of the product
        public string Height { get; set; } = string.Empty;  // Height of the product
    }

    // Represents a product category
    public class Category
    {
        public int Id { get; set; }  // Category identifier
        public string Name { get; set; } = string.Empty;  // Name of the category
        public string Slug { get; set; } = string.Empty;  // Slug for SEO-friendly URL
    }

    // Represents an image associated with a product
    public class Image
    {
        public int Id { get; set; }  // Unique identifier for the image
        public DateTime DateCreated { get; set; }  // Date the image was created
        public DateTime DateCreatedGmt { get; set; }  // GMT date the image was created
        public DateTime DateModified { get; set; }  // Date the image was last modified
        public DateTime DateModifiedGmt { get; set; }  // GMT date the image was last modified
        public string Src { get; set; } = string.Empty;  // URL of the image
        public string Name { get; set; } = string.Empty;  // Name of the image file
        public string Alt { get; set; } = string.Empty;  // Alt text for the image (for accessibility)
        public int Position { get; set; }  // Position of the image (e.g., featured image)
        public bool IsFeatured { get; set; }  // Indicates whether the image is featured
    }

    // Represents metadata for a product (e.g., custom fields or extra info)
    public class MetaData
    {
        public int Id { get; set; }  // Unique identifier for the metadata
        public string Key { get; set; } = string.Empty;  // Key for the metadata
        public object Value { get; set; } = new();  // Value for the metadata
    }

    // Represents a store that the product belongs to
    public class Store
    {
        public int Id { get; set; }  // Store identifier
        public string Name { get; set; } = string.Empty;  // Name of the store
        public string Url { get; set; } = string.Empty;  // URL of the store
        public string Avatar { get; set; } = string.Empty;  // Avatar image of the store
        public Address Address { get; set; } = new();  // Address of the store
    }

    // Represents the address of a store
    public class Address
    {
        public string Street1 { get; set; } = string.Empty;  // First street address line
        public string Street2 { get; set; } = string.Empty;  // Second street address line
        public string City { get; set; } = string.Empty;  // City of the store
        public string Zip { get; set; } = string.Empty;  // Zip code of the store
        public string Country { get; set; } = string.Empty;  // Country of the store
        public string State { get; set; } = string.Empty;  // State of the store
    }

    // Represents row actions for managing a product (edit, delete, view, etc.)
    public class RowActions
    {
        public Action Edit { get; set; } = new();  // Action to edit the product
        public Action Delete { get; set; } = new();  // Action to delete the product
        public Action View { get; set; } = new();  // Action to view the product details
        public Action QuickEdit { get; set; } = new();  // Action for quick edit
        public Action Duplicate { get; set; } = new();  // Action to duplicate the product
    }

    // Represents a specific action that can be performed on a product (edit, delete, etc.)
    public class Action
    {
        public string Title { get; set; } = string.Empty;  // Title of the action (e.g., 'Edit')
        public string Url { get; set; } = string.Empty;  // URL for the action
        public string Class { get; set; } = string.Empty;  // CSS class for styling
        public string Other { get; set; } = string.Empty;  // Other parameters for the action
    }

    // Represents the links related to a product (e.g., self, collection)
    public class Links
    {
        public List<Link> Self { get; set; } = new();  // Link to the product itself
        public List<Link> Collection { get; set; } = new();  // Link to the product collection
    }

    // Represents a single link related to a product
    public class Link
    {
        public string Href { get; set; } = string.Empty;  // URL of the link
        public TargetHints TargetHints { get; set; } = new();  // Target hints for the link
    }

    // Represents hints about the link target (e.g., allowed link targets)
    public class TargetHints
    {
        public List<string> Allow { get; set; } = new();  // List of allowed link targets
    }
}
