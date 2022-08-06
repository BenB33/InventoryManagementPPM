using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentPPM.Data;
using InventoryManagmentPPM.Models;

namespace InventoryManagmentPPM.Pages.Inventory
{
    public class DeleteModel : PageModel
    {
        private readonly InventoryManagmentPPM.Data.InventoryManagmentPPMContext _context;

        public DeleteModel(InventoryManagmentPPM.Data.InventoryManagmentPPMContext context)
        {
            _context = context;
        }

        [BindProperty]
      public InventoryItem InventoryItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.InventoryItem == null)
            {
                return NotFound();
            }

            var inventoryitem = await _context.InventoryItem.FirstOrDefaultAsync(m => m.ID == id);

            if (inventoryitem == null)
            {
                return NotFound();
            }
            else 
            {
                InventoryItem = inventoryitem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.InventoryItem == null)
            {
                return NotFound();
            }
            var inventoryitem = await _context.InventoryItem.FindAsync(id);

            if (inventoryitem != null)
            {
                InventoryItem = inventoryitem;
                _context.InventoryItem.Remove(InventoryItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
