using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Vendors
{
    public class Vendor
    {
        public int VendorId { get; set; } 
        public string Name { get; set; }    
        public string Email { get; set; } 
        public string Phone { get; set; }  
        public string StoreName { get; set; }
        public string StoreDescription { get; set; } 
        public string StoreLogo { get; set; }
        public string StoreBanner { get; set; } 
        public DateTime DateJoined { get; set; }
        public bool IsActive { get; set; }
    }
}
