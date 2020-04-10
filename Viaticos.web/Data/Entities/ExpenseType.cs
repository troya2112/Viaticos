using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viaticos.web.Data.Entities
{
    public class ExpenseType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        public ICollection<TripDetail> TripDetails { get; set; }

    }
}
