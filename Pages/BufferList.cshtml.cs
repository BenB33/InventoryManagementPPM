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


        public async Task OnGetAsync() {
          var items = from i in _context.InventoryItem select i;

          items = items.Where(s => (!s.IsApproved));

          InventoryItem = await items.ToListAsync();
        }
    }
}
