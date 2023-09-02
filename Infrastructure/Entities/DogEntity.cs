using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class DogEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public double ActivityFactor { get; set; }
        public int ActivityLevel { get; set; }
        [ForeignKey("UserEntity")]
        public UserEntity Owner { get; set; }
        public int OwnerId { get; set; }
    }
}
