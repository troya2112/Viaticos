using System.Collections.Generic;

namespace Viaticos.web.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Trip> Trips { get; set; }

    }
}
