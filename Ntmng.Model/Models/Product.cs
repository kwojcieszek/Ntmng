using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required]
    public string Code { get; set; }
    public string? Index { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Ean13 { get; set; }
    public decimal? Price { get; set; }
    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}