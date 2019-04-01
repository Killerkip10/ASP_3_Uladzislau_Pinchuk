using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class CustomerAdditional
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int AdditionalServiceId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual AdditionalService AdditionalService { get; set; }
    }
}
