using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyPlayerList.Model;

namespace VolleyPlayerList.Pages.PlayerList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VolleyPlayer VolleyPlayer { get;set;}
        public async Task OnGet(int id)
        {
            VolleyPlayer = await _db.VolleyPlayer.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var PlayerFromDb = await _db.VolleyPlayer.FindAsync(VolleyPlayer.Id);
                PlayerFromDb.Name = VolleyPlayer.Name;
                PlayerFromDb.LastName = VolleyPlayer.LastName;
                PlayerFromDb.Rate = VolleyPlayer.Rate;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
