using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentPPM.Models;

namespace InventoryManagmentPPM.Data
{
    public class InventoryManagmentPPMContext : DbContext
    {
        public InventoryManagmentPPMContext (DbContextOptions<InventoryManagmentPPMContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryManagmentPPM.Models.InventoryItem> InventoryItem { get; set; } = default!;
    }
}
