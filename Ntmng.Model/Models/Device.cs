using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class Device
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DeviceId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Host { get; set; }
    [Required]
    [ForeignKey("Localization")]
    public int? LocalizationId { get; set; }
    public virtual Localization? Localization { get; set; }
    [Required]
    [DefaultValue("true")]
    public bool IsActive { get; set; }
    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime DateAdded { get; set; }
}