using System.ComponentModel.DataAnnotations;

namespace Ntmng.Model.Models;

public class Language
{
    [Key]
    public int LanguageId { get; set; }
    public string Name { get; set; }
}