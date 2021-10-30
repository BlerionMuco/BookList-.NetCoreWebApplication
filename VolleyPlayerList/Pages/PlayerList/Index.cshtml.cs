using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolleyPlayerList.Model;

namespace VolleyPlayerList.Pages.PlayerList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<VolleyPlayer> VolleyPlayers { get; set; }
        public async Task OnGet() //Metoda bene get ne Db duke e ngarkuar listen me element qe ndodhen ne db
        {
            VolleyPlayers = await _db.VolleyPlayer.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var player = await _db.VolleyPlayer.FindAsync(id);//kapim rekordin ne db me kete id
                if (player == null)
                {
                   return NotFound();
                }

            _db.VolleyPlayer.Remove(player); //Fshime rekordin
            await _db.SaveChangesAsync();//I bejm change db 
            return RedirectToPage("Index");//Kthehemi te faqa Index
        }
    }
}
