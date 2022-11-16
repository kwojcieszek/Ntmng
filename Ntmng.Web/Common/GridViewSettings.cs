namespace Ntmng.Web.Common;

public class GridViewSettings
{
    public string GridID { get; set; }
    public int QuantityRows { get; set; }
    public int RowsOnPage { get; set; } = 20;
    public int MaxPagination { get; set; } = 10;
    public string RestApiPath { get; set; }
}