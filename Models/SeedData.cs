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
            new InventoryItem {
              Title = "Office Table",
              Quantity = 10,
              PpmCode = "F-02",
              SiteCode = "SE-009-B",
              Comment = "One damaged - small scratch on left side",
              Client = "Nomad",
            },

            new InventoryItem {
              Title = "Office Chair",
              Quantity = 5,
              PpmCode = "F-09",
              SiteCode = "SE-009-B",
              Comment = "Chair with blue seat covers",
              Client = "Nomad",
            },

            new InventoryItem {
              Title = "Duvet Set",
              Quantity = 2,
              PpmCode = "H-19",
              SiteCode = "SE-007-A",
              Comment = "Has a picture of buzz lightyear",
              Client = "Nomad",
            },

            new InventoryItem {
              Title = "Painting",
              Quantity = 3,
              PpmCode = "A-04",
              SiteCode = "SE-009-A",
              Comment = "Art for hanging in hotel rooms",
              Client = "Arts Club",
            },

            new InventoryItem {
              Title = "Desk Lamp",
              Quantity = 18,
              PpmCode = "L-10",
              SiteCode = "SE-009-B",
              Comment = "Bendy desk lamp",
              Client = "Arts Club",
            }
        );
        context.SaveChanges();
      }
    }
  }
}