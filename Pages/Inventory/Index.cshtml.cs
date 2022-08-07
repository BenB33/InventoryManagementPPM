using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagmentPPM.Data;
using InventoryManagmentPPM.Models;

namespace InventoryManagmentPPM.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly InventoryManagmentPPM.Data.InventoryManagmentPPMContext _context;

        public IndexModel(InventoryManagmentPPM.Data.InventoryManagmentPPMContext context)
        {
            _context = context;
        }

        public IList<InventoryItem> InventoryItem { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList? Clients { get; set;  }
        [BindProperty(SupportsGet = true)]
        public string? ItemClient { get; set; }

        public async Task OnGetAsync()
        {
            var items = from i in _context.InventoryItem select i;
            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => (s.Title.Contains(SearchString) || s.SiteCode.Contains(SearchString) 
                  || s.Comment.Contains(SearchString) || s.PpmCode.Contains(SearchString) || s.Client.Contains(SearchString)));
            }
            InventoryItem = await items.ToListAsync();
        }
    }
}
