using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentPPM.Data;
using InventoryManagmentPPM.Models;

namespace InventoryManagmentPPM.Pages
{
    public class BufferListModel : PageModel
    {
        private readonly InventoryManagmentPPM.Data.InventoryManagmentPPMContext _context;

        public BufferListModel(InventoryManagmentPPM.Data.InventoryManagmentPPMContext context)
        {
            _context = context;
        }

        public IList<InventoryItem> InventoryItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.InventoryItem != null)
            {
                InventoryItem = await _context.InventoryItem.ToListAsync();
            }
        }
    }
}
