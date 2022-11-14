using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class ModuleData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModuleDataId { get; set; }
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime DateAdded { get; set; }
    [Required]
    public bool ResponseResult { get; set; }
    public int? ResponseTime { get; set; }
}