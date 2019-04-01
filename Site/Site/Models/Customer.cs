using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Job { get; set; }

        public System.DateTime Birthday { get; set; }

        public float Width { get; set; }

        public float Weight { get; set; }

        public int CountChildren { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string Passport { get; set; }

        public int ZodiacSignId { get; set; }

        public int NationalityId { get; set; }

        public virtual ICollection<CustomerAdditional> CustomerAdditional { get; set; }
        
        public virtual Nationality Nationality { get; set; }

        public virtual ZodiacSign ZodiacSign { get; set; }
    }
}
