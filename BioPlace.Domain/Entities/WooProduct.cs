using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.WooProduct
{
        public class WooProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public string Permalink { get; set; }
            public DateTime? DateCreated { get; set; }
            public DateTime? DateCreatedGmt { get; set; }
            public DateTime? DateModified { get; set; }
            public DateTime? DateModifiedGmt { get; set; }
            public string Type { get; set; }
            public string Status { get; set; }
            public bool Featured { get; set; }
            public string CatalogVisibility { get; set; }
            public string Description { get; set; }
            public string ShortDescription { get; set; }
            public string Sku { get; set; }
            public string Price { get; set; }
            public string RegularPrice { get; set; }
            public string SalePrice { get; set; }
            public DateTime? DateOnSaleFrom { get; set; }
            public DateTime? DateOnSaleFromGmt { get; set; }
            public DateTime? DateOnSaleTo { get; set; }
            public DateTime? DateOnSaleToGmt { get; set; }
            public string PriceHtml { get; set; }
            public bool OnSale { get; set; }
            public bool Purchasable { get; set; }
            public int TotalSales { get; set; }
            public bool Virtual { get; set; }
            public bool Downloadable { get; set; }
            public List<object> Downloads { get; set; }
            public int DownloadLimit { get; set; }
            public int DownloadExpiry { get; set; }
            public string ExternalUrl { get; set; }
            public string ButtonText { get; set; }
            public string TaxStatus { get; set; }
            public string TaxClass { get; set; }
            public bool ManageStock { get; set; }
            public int? StockQuantity { get; set; }
            public bool InStock { get; set; }
            public string Backorders { get; set; }
            public bool BackordersAllowed { get; set; }
            public bool Backordered { get; set; }
            public bool SoldIndividually { get; set; }
            public string Weight { get; set; }
            public WooDimensions Dimensions { get; set; }
            public bool ShippingRequired { get; set; }
            public bool ShippingTaxable { get; set; }
            public string ShippingClass { get; set; }
            public int ShippingClassId { get; set; }
            public bool ReviewsAllowed { get; set; }
            public string AverageRating { get; set; }
            public int RatingCount { get; set; }
            public List<int> RelatedIds { get; set; }
            public List<int> UpsellIds { get; set; }
            public List<int> CrossSellIds { get; set; }
            public int ParentId { get; set; }
            public string PurchaseNote { get; set; }
            public List<WooCategory> Categories { get; set; }
            public List<object> Tags { get; set; }
            public List<WooImage> Images { get; set; }
            public List<object> Attributes { get; set; }
            public List<object> DefaultAttributes { get; set; }
            public List<object> Variations { get; set; }
            public List<object> GroupedProducts { get; set; }
            public int MenuOrder { get; set; }
            public List<WooMetaData> MetaData { get; set; }
        }

        public class WooDimensions
        {
            public string Length { get; set; }
            public string Width { get; set; }
            public string Height { get; set; }
        }

        public class WooCategory
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
        }

        public class WooImage
    {
            public int Id { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateCreatedGmt { get; set; }
            public DateTime DateModified { get; set; }
            public DateTime DateModifiedGmt { get; set; }
            public string Src { get; set; }
            public string Name { get; set; }
            public string Alt { get; set; }
            public int Position { get; set; }
        }

        public class WooMetaData
    {
            public int Id { get; set; }
            public string Key { get; set; }
            public object Value { get; set; }
        }
}
