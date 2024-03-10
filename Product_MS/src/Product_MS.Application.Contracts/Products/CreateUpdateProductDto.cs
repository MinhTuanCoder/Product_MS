using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Product_MS.Products;

public class CreateUpdateProductDto
{
    public Guid CategoryId { get; set; }
    [Required]//validate
    [StringLength(128)] 
    public string Name { get; set; } = string.Empty;
    [Required]//validate
    [StringLength(256)]
    public string Description { get; set; } = string.Empty;
    [Required]//validate


    [Range(0.01f, float.MaxValue, ErrorMessage = "Price must be a positive value")]
    public float Price { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Inventory must be a non-negative integer")]
    public int Inventory { get; set; } = 0;
}
