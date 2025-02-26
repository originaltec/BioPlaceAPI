using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioplace.Application.DTOs.UpdateProductDto
{
    // Data Transfer Object (DTO) for updating product information
    public class UpdateProductDto
    {
        // Property to hold the updated stock quantity of the product
        public int stock_quantity { get; set; }

        // Property to hold the updated description of the product
        public string description { get; set; }
    }
}
