using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viaticos.web.Data.Entities
{
    public class Trip
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; }
        public City City { get; set; }
        public double TotalAmount { get; set; }
        public ICollection<TripDetail> TripDetails { get; set; }
    }
}
