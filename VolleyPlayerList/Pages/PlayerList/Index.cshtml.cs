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
    }
}
