using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Product_MS.Categories
{
    public class UpdateCategoryDto
    {

        [Required]
        [StringLength(64)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
