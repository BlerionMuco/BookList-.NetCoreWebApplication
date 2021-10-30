using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolleyPlayerList.Model;

namespace VolleyPlayerList.Controllers
{
    [Route("api/Player")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlayerController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.VolleyPlayer.ToListAsync()});
        }

        [HttpDelete]
        public async Task <IActionResult> Delete(int id)
        {
            var playerFromDb =await _db.VolleyPlayer.FirstOrDefaultAsync(u => u.Id == id);

            if (playerFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.VolleyPlayer.Remove(playerFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Player was successed deleted" });
        }
    }
}
