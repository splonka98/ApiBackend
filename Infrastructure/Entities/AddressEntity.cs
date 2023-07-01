using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
