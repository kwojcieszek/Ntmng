using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class Brand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BrandId { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Origin { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}