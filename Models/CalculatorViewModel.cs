using System.ComponentModel.DataAnnotations;

namespace TP.Models
{
    public class CalculatorViewModel
    {
        [Required(ErrorMessage = "Please, enter the 1st number")]
        public ulong? FirstNumber { get; set; }


        [Required(ErrorMessage = "Please, enter the 2st number")]
        public float? SecondNumber { get; set; }


        [Required(ErrorMessage = "Please, select a sign")]
        public char? Sign { get; set; }

        public float Result { get; set; }

    }
}
