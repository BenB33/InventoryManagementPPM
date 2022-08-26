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

        public IndexModel(InventoryManagmentPPM.Data.InventoryManagmentPPMContext context) {
            _context = context;
        }

        public IList<InventoryItem> InventoryItem { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList? Clients { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ItemClient { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterName { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterPpmCode { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterClient { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterSiteCode { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterBay { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterQuantity { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool CheckboxFilterComment { get; set; }

        public async Task OnGetAsync() {

            var items = from i in _context.InventoryItem select i;

            if (!string.IsNullOrEmpty(SearchString)) {
              if (!CheckboxFilterName && !CheckboxFilterPpmCode && !CheckboxFilterClient 
                  && !CheckboxFilterSiteCode && !CheckboxFilterQuantity && !CheckboxFilterComment) {
                CheckboxFilterName = CheckboxFilterPpmCode = CheckboxFilterClient = CheckboxFilterSiteCode
                = CheckboxFilterQuantity = CheckboxFilterComment = CheckboxFilterBay = true;
              }

              items = items.Where(s => (
                (CheckboxFilterName && s.Title.Contains(SearchString)) ||
                (CheckboxFilterSiteCode && s.SiteCode.Contains(SearchString)) ||
                (CheckboxFilterBay && s.SiteCode.Contains(SearchString)) ||
                (CheckboxFilterComment && s.Comment.Contains(SearchString)) ||
                (CheckboxFilterPpmCode && s.PpmCode.Contains(SearchString)) ||
                (CheckboxFilterClient && s.Client.Contains(SearchString))));
            }
            InventoryItem = await items.ToListAsync();
        }
    }
}
