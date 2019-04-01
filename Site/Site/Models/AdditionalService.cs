using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class AdditionalService
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public virtual ICollection<CustomerAdditional> CustomerAdditional { get; set; }
    }
}
