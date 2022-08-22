using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_blazor_maui.Data
{
    public class GuessALetterModel
    {
        [Required]
        [StringLength(1, ErrorMessage = "Only one letter can be guessed at a time!")]
        public string Letter { get; set; }
    }
}
