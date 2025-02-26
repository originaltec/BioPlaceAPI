using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.WooProduct
{
    // Represents a WooCommerce Product with all its properties
    public class WooProduct
    {
        public int Id { get; set; } // Unique identifier for the product
        public string Name { get; set; } // Name of the product
        public string Slug { get; set; } // URL-friendly version of the product name
        public string Permalink { get; set; } // Full URL to the product page
        public DateTime? DateCreated { get; set; } // Date when the product was created
        public DateTime? DateCreatedGmt { get; set; } // GMT date when the product was created
        public DateTime? DateModified { get; set; } // Date when the product was last modified
        public DateTime? DateModifiedGmt { get; set; } // GMT date when the product was last modified
        public string Type { get; set; } // Type of the product (e.g., simple, variable)
        public string Status { get; set; } // Status of the product (e.g., publish, draft)
        public bool Featured { get; set; } // Indicates if the product is featured
        public string CatalogVisibility { get; set; } // Visibility in the catalog (e.g., visible, hidden)
        public string Description { get; set; } // Full description of the product
        public string ShortDescription { get; set; } // Short description of the product
        public string Sku { get; set; } // SKU (Stock Keeping Unit) for the product
        public string Price { get; set; } // Current price of the product
        public string RegularPrice { get; set; } // Regular price (before any discounts)
        public string SalePrice { get; set; } // Sale price (if any discount is applied)
        public DateTime? DateOnSaleFrom { get; set; } // Date when the sale started
        public DateTime? DateOnSaleFromGmt { get; set; } // GMT date when the sale started
        public DateTime? DateOnSaleTo { get; set; } // Date when the sale ends
        public DateTime? DateOnSaleToGmt { get; set; } // GMT date when the sale ends
        public string PriceHtml { get; set; } // HTML formatted price for display purposes
        public bool OnSale { get; set; } // Whether the product is currently on sale
        public bool Purchasable { get; set; } // Whether the product is available for purchase
        public int TotalSales { get; set; } // Total number of sales for this product
        public bool Virtual { get; set; } // Indicates if the product is virtual (non-shippable)
        public bool Downloadable { get; set; } // Indicates if the product is downloadable (e.g., e-books, software)
        public List<object> Downloads { get; set; } // List of download links, if the product is downloadable
        public int DownloadLimit { get; set; } // Limit on the number of downloads allowed
        public int DownloadExpiry { get; set; } // Expiry time for the download link
        public string ExternalUrl { get; set; } // External URL if the product is an external product (e.g., affiliate links)
        public string ButtonText { get; set; } // Text to display on the "Add to Cart" button
        public string TaxStatus { get; set; } // Tax status (e.g., taxable, shipping only)
        public string TaxClass { get; set; } // Tax class (if applicable)
        public bool ManageStock { get; set; } // Whether stock management is enabled for this product
        public int? StockQuantity { get; set; } // The quantity of stock available for the product
        public bool InStock { get; set; } // Whether the product is in stock
        public string Backorders { get; set; } // Backorder status (e.g., allow, notify)
        public bool BackordersAllowed { get; set; } // Indicates if backorders are allowed
        public bool Backordered { get; set; } // Indicates if the product is backordered
        public bool SoldIndividually { get; set; } // Indicates if the product can only be bought individually (not in bulk)
        public string Weight { get; set; } // Weight of the product (useful for shipping calculations)
        public WooDimensions Dimensions { get; set; } // Dimensions of the product (length, width, height)
        public bool ShippingRequired { get; set; } // Whether shipping is required for this product
        public bool ShippingTaxable { get; set; } // Whether the shipping for this product is taxable
        public string ShippingClass { get; set; } // Shipping class for the product (if applicable)
        public int ShippingClassId { get; set; } // Shipping class ID
        public bool ReviewsAllowed { get; set; } // Whether product reviews are allowed
        public string AverageRating { get; set; } // Average rating for the product
        public int RatingCount { get; set; } // Number of ratings the product has received
        public List<int> RelatedIds { get; set; } // List of related product IDs
        public List<int> UpsellIds { get; set; } // List of upsell product IDs
        public List<int> CrossSellIds { get; set; } // List of cross-sell product IDs
        public int ParentId { get; set; } // ID of the parent product (if this is a variation)
        public string PurchaseNote { get; set; } // Purchase note to display after purchase
        public List<WooCategory> Categories { get; set; } // Categories the product belongs to
        public List<object> Tags { get; set; } // Tags associated with the product
        public List<WooImage> Images { get; set; } // List of images for the product
        public List<object> Attributes { get; set; } // List of product attributes (e.g., size, color)
        public List<object> DefaultAttributes { get; set; } // Default attributes for the product
        public List<object> Variations { get; set; } // Variations of the product (if it is a variable product)
        public List<object> GroupedProducts { get; set; } // Grouped products (if this product is part of a group)
        public int MenuOrder { get; set; } // Menu order (used to order products in the menu)
        public List<WooMetaData> MetaData { get; set; } // Additional metadata for the product
    }

    // Represents the dimensions of a product (length, width, height)
    public class WooDimensions
    {
        public string Length { get; set; } // Length of the product
        public string Width { get; set; } // Width of the product
        public string Height { get; set; } // Height of the product
    }

    // Represents a category that the product belongs to
    public class WooCategory
    {
        public int Id { get; set; } // Unique identifier for the category
        public string Name { get; set; } // Name of the category
        public string Slug { get; set; } // URL-friendly version of the category name
    }

    // Represents an image associated with the product
    public class WooImage
    {
        public int Id { get; set; } // Unique identifier for the image
        public DateTime DateCreated { get; set; } // Date when the image was created
        public DateTime DateCreatedGmt { get; set; } // GMT date when the image was created
        public DateTime DateModified { get; set; } // Date when the image was last modified
        public DateTime DateModifiedGmt { get; set; } // GMT date when the image was last modified
        public string Src { get; set; } // URL of the image source
        public string Name { get; set; } // Name of the image file
        public string Alt { get; set; } // Alt text for the image
        public int Position { get; set; } // Position of the image in the product gallery
    }

    // Represents metadata associated with a product
    public class WooMetaData
    {
        public int Id { get; set; } // Unique identifier for the metadata
        public string Key { get; set; } // Key for the metadata
        public object Value { get; set; } // Value for the metadata
    }
}
