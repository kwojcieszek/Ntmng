using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class ListPrice
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PriceId { get; set; }
    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    [DataType("decimal(8,2)")]
    public decimal Price { get; set; }
    [Required]
    [ForeignKey("Shop")]
    public int ShopId { get; set; }
    public virtual Shop Shop { get; set; }
    public DateTime DateAdded { get; set; }
}