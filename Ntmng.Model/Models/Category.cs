using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }
    [StringLength(255)]
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    [ForeignKey("Category")]
    public int? ParentCategoryId { get; set; }
    public virtual Category? ParentCategory { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}