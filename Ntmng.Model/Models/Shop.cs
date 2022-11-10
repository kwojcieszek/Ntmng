using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class Shop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShopId { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Web { get; set; }
    public string? SearchScript { get; set; }
    public string? PriceScript { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}