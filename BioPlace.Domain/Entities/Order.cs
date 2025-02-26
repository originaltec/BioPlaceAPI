using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Orders
{
    // Represents an order in the marketplace
    public class Order
    {
        // Unique identifier for the order
        public int Id { get; set; }

        // ID of the parent order (if any)
        public int ParentId { get; set; }

        // Unique order number
        public string Number { get; set; }

        // A unique key for the order
        public string OrderKey { get; set; }

        // The method through which the order was created (e.g., web, API)
        public string CreatedVia { get; set; }

        // Version of the order system used
        public string Version { get; set; }

        // Current status of the order (e.g., pending, completed, cancelled)
        public string Status { get; set; }

        // Currency used for the order
        public string Currency { get; set; }

        // The creation date of the order
        public string DateCreated { get; set; }

        // The creation date in GMT
        public string DateCreatedGmt { get; set; }

        // The last modification date of the order
        public string DateModified { get; set; }

        // The last modification date in GMT
        public string DateModifiedGmt { get; set; }

        // The total discount applied to the order
        public double DiscountTotal { get; set; }

        // The tax applied to the discount
        public double DiscountTax { get; set; }

        // The total shipping cost for the order
        public double ShippingTotal { get; set; }

        // The tax applied to the shipping
        public double ShippingTax { get; set; }

        // The total tax applied to the cart
        public double CartTax { get; set; }

        // The overall total of the order
        public double Total { get; set; }

        // The total tax applied to the order
        public double TotalTax { get; set; }

        // Flag to indicate if prices include tax
        public bool PricesIncludeTax { get; set; }

        // Unique identifier for the customer who made the order
        public int CustomerId { get; set; }

        // IP address of the customer when the order was made
        public string CustomerIpAddress { get; set; }

        // The user agent of the customer when placing the order
        public string CustomerUserAgent { get; set; }

        // Any additional notes from the customer
        public string CustomerNote { get; set; }

        // Billing information for the order
        public Billing billing { get; set; }

        // Shipping information for the order
        public Shipping shipping { get; set; }

        // Payment method used for the order
        public string PaymentMethod { get; set; }

        // Title of the payment method
        public string PaymentMethodTitle { get; set; }

        // Transaction ID for the payment
        public string TransactionId { get; set; }

        // The date when the order was paid
        public string DatePaid { get; set; }

        // The GMT date when the order was paid
        public string DatePaidGmt { get; set; }

        // The date when the order was completed
        public string DateCompleted { get; set; }

        // The GMT date when the order was completed
        public string DateCompletedGmt { get; set; }

        // The cart hash identifier for the order
        public string CartHash { get; set; }

        // Metadata related to the order (e.g., custom fields)
        public List<MetaData> metaData { get; set; }

        // A list of line items (products) in the order
        public List<LineItem> LineItems { get; set; }

        // A list of tax lines applied to the order
        public List<TaxLine> TaxLines { get; set; }

        // A list of shipping lines (shipping methods) applied to the order
        public List<ShippingLine> ShippingLines { get; set; }

        // Represents the billing details of the customer
        public class Billing
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Country { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        // Represents the shipping details of the order
        public class Shipping
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Country { get; set; }
        }

        // Represents metadata associated with the order (e.g., custom fields)
        public class MetaData
        {
            public int Id { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }
        }

        // Represents a line item (product) in the order
        public class LineItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int ProductId { get; set; }
            public int VariationId { get; set; }
            public int Quantity { get; set; }
            public string TaxClass { get; set; }
            public double Subtotal { get; set; }
            public double SubtotalTax { get; set; }
            public double Total { get; set; }
            public double TotalTax { get; set; }
            public List<Tax> Taxes { get; set; }
            public string Sku { get; set; }
            public double Price { get; set; }
        }

        // Represents tax information for an item
        public class Tax
        {
            public int Id { get; set; }
            public double Total { get; set; }
            public double Subtotal { get; set; }
        }

        // Represents a tax line applied to the order
        public class TaxLine
        {
            public int Id { get; set; }
            public string RateCode { get; set; }
            public int RateId { get; set; }
            public string Label { get; set; }
            public bool Compound { get; set; }
            public double TaxTotal { get; set; }
            public double ShippingTaxTotal { get; set; }
            public List<MetaData> MetaData { get; set; }
        }

        // Represents a shipping line applied to the order
        public class ShippingLine
        {
            public int Id { get; set; }
            public string MethodTitle { get; set; }
            public string MethodId { get; set; }
            public double Total { get; set; }
            public double TotalTax { get; set; }
            public List<Tax> Taxes { get; set; }
            public List<MetaData> MetaData { get; set; }
        }
    }
}
