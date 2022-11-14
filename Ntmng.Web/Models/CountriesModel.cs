using Ntmng.Model.Models;
using Ntmng.Web.Common;

namespace Ntmng.Web.Models;

public class CountriesModel
{
    public ICollection<Country> Countries { get; set; }
    public GridViewSettings GridView { get; set; }
}