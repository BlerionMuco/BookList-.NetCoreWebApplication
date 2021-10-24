using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolleyPlayerList.Model
{
    public class VolleyPlayer
    {
        [Key]
       public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Double Rate { get; set; }


    }
}
