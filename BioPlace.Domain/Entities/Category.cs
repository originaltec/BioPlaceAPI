using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Parent { get; set; }
        public string Description { get; set; }
        public string Display { get; set; }
        public CategoryImage Image { get; set; }
        public int MenuOrder { get; set; }
        public int Count { get; set; }
        public Links _Links { get; set; }
    }

    public class CategoryImage
    {
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public string DateCreatedGmt { get; set; }
        public string DateModified { get; set; }
        public string DateModifiedGmt { get; set; }
        public string Src { get; set; }
        public string Name { get; set; }
        public string Alt { get; set; }
    }

    public class Links
    {
        public Self[] Self { get; set; }
        public Collection[] Collection { get; set; }
        public Up[] Up { get; set; }
    }

    public class Self
    {
        public string Href { get; set; }
        public TargetHints TargetHints { get; set; }
    }

    public class TargetHints
    {
        public string[] Allow { get; set; }
    }

    public class Collection
    {
        public string Href { get; set; }
    }

    public class Up
    {
        public string Href { get; set; }
    }
}
