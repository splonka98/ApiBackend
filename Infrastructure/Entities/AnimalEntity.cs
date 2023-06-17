using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    internal abstract class AnimalEntity
    {
        public int animalId { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string gender { get; set; }

        public double weight { get; set; }

        public double activityFactor { get; set; }

        public virtual int ownerId { get; set; }
    }
}
