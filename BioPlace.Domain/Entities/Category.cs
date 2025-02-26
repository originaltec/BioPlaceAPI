using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioPlace.Domain.Entities.Categories
{
    // Represents a product category in the marketplace
    public class Category
    {
        // Unique identifier for the category
        public int Id { get; set; }

        // Name of the category
        public string Name { get; set; }

        // URL-friendly version of the category name (slug)
        public string Slug { get; set; }

        // ID of the parent category (0 if this is a top-level category)
        public int Parent { get; set; }

        // A description of the category
        public string Description { get; set; }

        // Display setting for the category (e.g., visible or hidden)
        public string Display { get; set; }

        // Image associated with the category
        public CategoryImage Image { get; set; }

        // Order of the category in the menu
        public int MenuOrder { get; set; }

        // The number of products in this category
        public int Count { get; set; }

        // Links related to the category for navigation or related actions
        public Links _Links { get; set; }
    }

    // Represents the image associated with a category
    public class CategoryImage
    {
        // Unique identifier for the image
        public int Id { get; set; }

        // The date the image was created
        public string DateCreated { get; set; }

        // The GMT date the image was created
        public string DateCreatedGmt { get; set; }

        // The date the image was last modified
        public string DateModified { get; set; }

        // The GMT date the image was last modified
        public string DateModifiedGmt { get; set; }

        // The URL source of the image
        public string Src { get; set; }

        // The name of the image file
        public string Name { get; set; }

        // Alt text for the image
        public string Alt { get; set; }
    }

    // Represents various links related to the category
    public class Links
    {
        // The self link related to the category
        public Self[] Self { get; set; }

        // Collection of links to other related categories or collections
        public Collection[] Collection { get; set; }

        // Links related to the parent or higher level
        public Up[] Up { get; set; }
    }

    // Represents a self link that points to the current resource
    public class Self
    {
        // The href URL of the self link
        public string Href { get; set; }

        // Additional target hints for the self link
        public TargetHints TargetHints { get; set; }
    }

    // Provides additional target hint settings for links
    public class TargetHints
    {
        // An array of allowed actions for the link
        public string[] Allow { get; set; }
    }

    // Represents a collection link, which can point to a collection of related items
    public class Collection
    {
        // The href URL for the collection link
        public string Href { get; set; }
    }

    // Represents an "up" link, typically used for navigation to a parent resource
    public class Up
    {
        // The href URL for the up link
        public string Href { get; set; }
    }
}
