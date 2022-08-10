using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventoryManagmentPPM.Data;
using InventoryManagmentPPM.Models;
using System.Reflection;

namespace InventoryManagmentPPM.Pages.Inventory
{

    public class CreateModel : PageModel
    {

    private readonly InventoryManagmentPPM.Data.InventoryManagmentPPMContext _context;

        public CreateModel(InventoryManagmentPPM.Data.InventoryManagmentPPMContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public InventoryItem InventoryItem { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.InventoryItem == null || InventoryItem == null) {
                return Page();
            }

            // TODO: The wwwroot path thing is shit
            string www_root_path = AppDomain.CurrentDomain.BaseDirectory + "/../../../wwwroot/images/";

            // Save image file to wwwroot image folder
            string file_name = Path.GetFileNameWithoutExtension(InventoryItem.ImageFile.FileName);
            string extension = Path.GetExtension(InventoryItem.ImageFile.FileName);
            InventoryItem.ImageName = file_name = file_name + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(www_root_path, file_name);
            using (var file_stream = new FileStream(path, FileMode.Create)) {
              await InventoryItem.ImageFile.CopyToAsync(file_stream);
            }

            // Add record to database
            _context.InventoryItem.Add(InventoryItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
