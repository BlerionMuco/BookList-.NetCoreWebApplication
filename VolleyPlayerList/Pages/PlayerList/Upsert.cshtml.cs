using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VolleyPlayerList.Model;

namespace VolleyPlayerList.Pages.PlayerList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VolleyPlayer VolleyPlayer { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            VolleyPlayer = new VolleyPlayer();
            if (id == null)
            {
                //create
                return Page();
            }
            //update
            VolleyPlayer =await  _db.VolleyPlayer.FirstOrDefaultAsync(u => u.Id == id);
            if (VolleyPlayer == null)
            {
                return NotFound();
            }
            return Page();        
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (VolleyPlayer.Id == 0)
                {
                    _db.VolleyPlayer.Add(VolleyPlayer);
                }
                else
                {
                    _db.VolleyPlayer.Update(VolleyPlayer);
                }              

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
