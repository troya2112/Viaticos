﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viaticos.web.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

    }
}
