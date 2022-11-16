using Ntmng.Model.Models;
using Ntmng.Web.Common;

namespace Ntmng.Web.Models;

public class DevicesModel
{
    public ICollection<Device> Devices { get; set; }
    public GridViewSettings GridView { get; set; }
}