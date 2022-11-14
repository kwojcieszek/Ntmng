using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

[Index(nameof(Name), IsUnique = true)]
public class Localization
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocalizationId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    [DefaultValue("true")]
    public bool IsActive { get; set; }
    [ForeignKey("Country")]
    public int? CountryId { get; set; }
    public virtual Country? Country { get; set; }
    [ForeignKey("User")]
    public int? UserId { get; set; }
    public virtual User? User { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}