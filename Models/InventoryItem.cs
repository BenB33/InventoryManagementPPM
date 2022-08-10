using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagmentPPM.Models
{
  public class InventoryItem
  {
    public int ID { get; set; }

    [StringLength(60, MinimumLength = 1)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "PPM Code")]
    [Required]
    public string PpmCode { get; set; } = string.Empty;

    [Required]
    public string Client { get; set; } = string.Empty;

    [Display(Name = "Site Code")]
    [Required]
    public string SiteCode { get; set; } = string.Empty;

    [StringLength(6)]
    public string Bay { get; set; } = string.Empty;

    [Required]
    public int Quantity { get; set; }

    public string Comment { get; set; } = string.Empty;

    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }

    public string ImageName = string.Empty;
  }
}
