using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Domain.Entities.Stores
{
    // Represents a store entity with details such as store name, owner info, social media, and other business-related properties
    public class Store
    {
        // Unique identifier for the store
        public int Id { get; set; }

        // Name of the store (serialized as "store_name" in JSON)
        [JsonPropertyName("store_name")]
        public string StoreName { get; set; }

        // Owner's first name (serialized as "first_name" in JSON)
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        // Owner's last name (serialized as "last_name" in JSON)
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        // Social media or other related information (dynamic object to store varying data types)
        public object Social { get; set; }

        // Contact phone number of the store
        public string Phone { get; set; }

        // Whether the store's email is visible or not (serialized as "show_email" in JSON)
        [JsonPropertyName("show_email")]
        public bool ShowEmail { get; set; }

        // Store address (could be an object containing street, city, etc.)
        public object Address { get; set; }

        // Store's general location (e.g., city or area)
        public string Location { get; set; }

        // URL of the store's banner image
        public string Banner { get; set; }

        // ID of the banner image (serialized as "banner_id" in JSON)
        [JsonPropertyName("banner_id")]
        public int BannerId { get; set; }

        // URL of the store's gravatar image
        public string Gravatar { get; set; }

        // ID of the gravatar image (serialized as "gravatar_id" in JSON)
        [JsonPropertyName("gravatar_id")]
        public int GravatarId { get; set; }

        // URL to the store's page or shop
        [JsonPropertyName("shop_url")]
        public string ShopUrl { get; set; }

        // Whether the store has Terms and Conditions enabled (serialized as "toc_enabled" in JSON)
        [JsonPropertyName("toc_enabled")]
        public bool TocEnabled { get; set; }

        // Text or link to the store's Terms of Service (serialized as "store_toc" in JSON)
        [JsonPropertyName("store_toc")]
        public string StoreToc { get; set; }

        // Indicates if the store is featured
        public bool Featured { get; set; }

        // Store's rating (could be an object, possibly containing rating details or average score)
        public object Rating { get; set; }

        // Whether the store is enabled or active
        public bool Enabled { get; set; }

        // Store's registration date (custom DateTime serialization using DateTimeConverter)
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("registered")]
        public DateTime Registered { get; set; }

        // Payment-related details for the store (could vary, hence dynamic object)
        public object Payment { get; set; }

        // Whether the store is trusted or verified
        public bool Trusted { get; set; }

        // Store's open and close times (serialized as "store_open_close" in JSON)
        [JsonPropertyName("store_open_close")]
        public object StoreOpenClose { get; set; }

        // Indicates if the store sells exclusive products (serialized as "sale_only_here" in JSON)
        [JsonPropertyName("sale_only_here")]
        public bool SaleOnlyHere { get; set; }

        // Store's company name (serialized as "company_name" in JSON)
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        // VAT number for the store (serialized as "vat_number" in JSON)
        [JsonPropertyName("vat_number")]
        public string VatNumber { get; set; }

        // Company ID number (serialized as "company_id_number" in JSON)
        [JsonPropertyName("company_id_number")]
        public string CompanyIdNumber { get; set; }

        // Bank name associated with the store (serialized as "bank_name" in JSON)
        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        // Bank IBAN (International Bank Account Number) for the store (serialized as "bank_iban" in JSON)
        [JsonPropertyName("bank_iban")]
        public string BankIban { get; set; }

        // Commission or additional fees related to the store's category (serialized as "admin_category_commission" in JSON)
        [JsonPropertyName("admin_category_commission")]
        public object AdminCategoryCommission { get; set; }

        // Store's commission value (serialized as "admin_commission" in JSON)
        [JsonPropertyName("admin_commission")]
        public string AdminCommission { get; set; }

        // Additional administrative fees (serialized as "admin_additional_fee" in JSON)
        [JsonPropertyName("admin_additional_fee")]
        public string AdminAdditionalFee { get; set; }

        // Type of administrative commission (serialized as "admin_commission_type" in JSON)
        [JsonPropertyName("admin_commission_type")]
        public string AdminCommissionType { get; set; }

        // Hyperlinks related to the store (could include links to API endpoints or other resources)
        public object Links { get; set; }
    }

    // Custom DateTime converter to handle the serialization and deserialization of DateTime values
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        // Method to read and convert a JSON string to a DateTime object
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var dateString = reader.GetString();
                if (DateTime.TryParse(dateString, out DateTime dateValue))
                {
                    return dateValue;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }

            return DateTime.MinValue; // Return a default DateTime value if parsing fails
        }

        // Method to write and convert DateTime values to a specific string format in JSON
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));  // Write the DateTime in ISO 8601 format
        }
    }
}
