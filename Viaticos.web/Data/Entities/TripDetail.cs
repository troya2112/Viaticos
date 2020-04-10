using System;
using System.ComponentModel.DataAnnotations;

namespace Viaticos.web.Data.Entities
{
    public class TripDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public double Amount { get; set; }

        [Display(Name = "Name")]
        [MaxLength(50, ErrorMessage = "The field {0} cannot have more than {1} characters")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Description { get; set; }

        public string PicturePath { get; set; }
        public Trip Trips { get; set; }

        public ExpenseType ExpenseType { get; set; }

    }
}
