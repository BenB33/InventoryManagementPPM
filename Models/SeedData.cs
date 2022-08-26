using Microsoft.EntityFrameworkCore;
using InventoryManagmentPPM.Data;

namespace InventoryManagmentPPM.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new InventoryManagmentPPMContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<InventoryManagmentPPMContext>>()))
      {
        if (context == null || context.InventoryItem == null) {
          throw new ArgumentNullException("Null InventoryManagmentPPMContext");
        }

        // Look for any items.
        if (context.InventoryItem.Any()) {
          return;   // DB has been seeded
        }

        context.InventoryItem.AddRange(
            new InventoryItem
            {
              Title = "Shredder",
              Quantity = 10,
              PpmCode = "F-02",
              SiteCode = "SE-009-B",
              Bay = "B",
              Comment = "One damaged - small scratch on left side",
              Client = "Nomad",
              ImageName = "shredder.png",
              IsApproved = false,
            },

            new InventoryItem
            {
              Title = "Tabletop Phone",
              Quantity = 5,
              PpmCode = "F-09",
              SiteCode = "SE-009-B",
              Bay = "B",
              Comment = "",
              Client = "Nomad",
              ImageName = "phone.png",
              IsApproved = false,
            },

            new InventoryItem
            {
              Title = "Printer Paper",
              Quantity = 2,
              PpmCode = "H-19",
              SiteCode = "SE-007-A",
              Bay = "A",
              Comment = "HP 400 sheets",
              Client = "Nomad",
              ImageName = "paper.png",
              IsApproved = false,
            },

            new InventoryItem
            {
              Title = "Kitchen Scale",
              Quantity = 3,
              PpmCode = "A-04",
              SiteCode = "SE-009-A",
              Bay = "C",
              Comment = "Scales for weighing ingredients",
              Client = "Arts Club",
              ImageName = "scale.png",
              IsApproved = true,
            },

            new InventoryItem
            {
              Title = "Food Blender",
              Quantity = 18,
              PpmCode = "L-10",
              SiteCode = "SE-009-B",
              Bay = "A",
              Comment = "Vitamix w/ measuring jug",
              Client = "Arts Club",
              ImageName = "blender.png",
              IsApproved = true,
            }
        );
        context.SaveChanges();
      }
    }
  }
}