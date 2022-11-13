using Ntmng.Model.Models;
using Ntmng.Web.Common;

namespace Ntmng.Web.Models;

public class ProductsModel
{
    public ICollection<string> Products { get; set; }
    public GridViewSettings GridView { get; set; }
}