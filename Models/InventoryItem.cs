using System.ComponentModel.DataAnnotations;

namespace InventoryManagmentPPM.Models
{
  public class InventoryItem
  {
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string PpmCode { get; set; } = string.Empty;
    public string SiteCode { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string Comment { get; set; } = string.Empty;
  }
}
