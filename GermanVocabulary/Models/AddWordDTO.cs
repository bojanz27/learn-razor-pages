using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GermanVocabulary.Models
{
    public class AddWordDTO
    {
        [Required(ErrorMessage = "The word is required")]
        public string German { get; set; }
        [Required(ErrorMessage = "The translation is required")]
        public string Serbian { get; set; }
    }
}
