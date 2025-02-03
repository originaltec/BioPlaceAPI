using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string PostAuthor { get; set; } = string.Empty;
        public string Permalink { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedGmt { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateModifiedGmt { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public bool Featured { get; set; }
        public string CatalogVisibility { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? DateOnSaleFrom { get; set; }
        public DateTime? DateOnSaleFromGmt { get; set; }
        public DateTime? DateOnSaleTo { get; set; }
        public DateTime? DateOnSaleToGmt { get; set; }
        public string PriceHtml { get; set; } = string.Empty;
        public bool OnSale { get; set; }
        public bool Purchasable { get; set; }
        public int TotalSales { get; set; }
        public bool Virtual { get; set; }
        public bool Downloadable { get; set; }
        public List<object> Downloads { get; set; } = new();
        public int DownloadLimit { get; set; }
        public int DownloadExpiry { get; set; }
        public string ExternalUrl { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string TaxStatus { get; set; } = string.Empty;
        public string TaxClass { get; set; } = string.Empty;
        public bool ManageStock { get; set; }
        public int? StockQuantity { get; set; }
        public string LowStockAmount { get; set; } = string.Empty;
        public bool InStock { get; set; }
        public string Backorders { get; set; } = string.Empty;
        public bool BackordersAllowed { get; set; }
        public bool Backordered { get; set; }
        public bool SoldIndividually { get; set; }
        public string Weight { get; set; } = string.Empty;
        public Dimensions Dimensions { get; set; } = new();
        public bool ShippingRequired { get; set; }
        public bool ShippingTaxable { get; set; }
        public string ShippingClass { get; set; } = string.Empty;
        public int ShippingClassId { get; set; }
        public bool ReviewsAllowed { get; set; }
        public string AverageRating { get; set; } = string.Empty;
        public int RatingCount { get; set; }
        public List<int> RelatedIds { get; set; } = new();
        public List<int> UpsellIds { get; set; } = new();
        public List<int> CrossSellIds { get; set; } = new();
        public int ParentId { get; set; }
        public string PurchaseNote { get; set; } = string.Empty;
        public List<Category> Categories { get; set; } = new();
        public List<object> Tags { get; set; } = new();
        public List<Image> Images { get; set; } = new();
        public List<object> Attributes { get; set; } = new();
        public List<object> DefaultAttributes { get; set; } = new();
        public List<object> Variations { get; set; } = new();
        public List<object> GroupedProducts { get; set; } = new();
        public int MenuOrder { get; set; }
        public List<MetaData> MetaData { get; set; } = new();
        public Store Store { get; set; } = new();
        public RowActions RowActions { get; set; } = new();
        public Links Links { get; set; } = new();
    }

    public class Dimensions
    {
        public string Length { get; set; } = string.Empty;
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }

    public class Image
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateCreatedGmt { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateModifiedGmt { get; set; }
        public string Src { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool IsFeatured { get; set; }
    }

    public class MetaData
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public object Value { get; set; } = new();
    }

    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public Address Address { get; set; } = new();
    }

    public class Address
    {
        public string Street1 { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }

    public class RowActions
    {
        public Action Edit { get; set; } = new();
        public Action Delete { get; set; } = new();
        public Action View { get; set; } = new();
        public Action QuickEdit { get; set; } = new();
        public Action Duplicate { get; set; } = new();
    }

    public class Action
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Other { get; set; } = string.Empty;
    }

    public class Links
    {
        public List<Link> Self { get; set; } = new();
        public List<Link> Collection { get; set; } = new();
    }

    public class Link
    {
        public string Href { get; set; } = string.Empty;
        public TargetHints TargetHints { get; set; } = new();
    }

    public class TargetHints
    {
        public List<string> Allow { get; set; } = new();
    }
}
