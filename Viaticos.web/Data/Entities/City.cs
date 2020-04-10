using System.ComponentModel.DataAnnotations;

namespace Viaticos.web.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        public Country Country { get; set; }

    }
}
