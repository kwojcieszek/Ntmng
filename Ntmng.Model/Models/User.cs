using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ntmng.Model.Models;

[Index(nameof(UserName), IsUnique = true)]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string Name { get; set; }
    [Required]
    [StringLength(255)]
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? MobilePhone { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [DefaultValue("true")]
    public bool IsActive { get; set; }
    [DefaultValue("false")]
    public bool IsEmailConfirmed { get; set; }
    [ForeignKey("Country")]
    public int? CountryId { get; set; }
    public virtual Country? Country { get; set; }
    [ForeignKey("Language")]
    public int? LanguageId { get; set; }
    public virtual Language? Language { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime? DateModified { get; set; }
}