using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ResponseModels;

public class InsertProduct
{
    [Required] public string ProductName { get; set; }
    [Required] public decimal ProductWeight { get; set; }
    [Required] public decimal ProductWidth { get; set; }
    [Required] public decimal ProductHeight { get; set; }
    [Required] public decimal ProductDepth { get; set; }
    [Required] public List<Categories> ProductCategories { get; set; }
}

