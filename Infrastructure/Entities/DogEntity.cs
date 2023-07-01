using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class DogEntity
    {
        public int AnimalId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public double ActivityFactor { get; set; }

        public virtual int OwnerId { get; set; }
    }
}
