using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VolleyPlayerList.Model;

namespace VolleyPlayerList.Pages.PlayerList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public VolleyPlayer VolleyPlayer { get; set; } //Krijojme propertyn qe do te perdorim per modelin tone
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost( ) //Metoda Post qe do te bej te mundur ngarkimin e te dhenave ne db
        {
            if (ModelState.IsValid) //Konbtrollojm nqs te dhenat jane valide ne fillim
            {
                await _db.VolleyPlayer.AddAsync(VolleyPlayer); //Sherben qe te kapi Objektin dhe ta hedhe ne Quee
                await _db.SaveChangesAsync(); //ben te mundur update ne db duke shtuar si rekord te gjithe objektin
                return RedirectToPage("Index"); //Pasi te ndodhi i gjithe procesi na behet i mundur kalimi ne faqen Index
            }
            else
            {
                return Page(); //Nqs validimi nuk eshte i sukseshem atehre do te qendrojme ne faqen ku jemi
            }

        }
    }
}
