using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

public class UserRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserRoleId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public DateTime DateAdded { get; set; }
}