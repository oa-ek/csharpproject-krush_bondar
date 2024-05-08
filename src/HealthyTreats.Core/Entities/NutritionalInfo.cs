using HealthyTreats.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyTreats.Core.Entities
{
    public class NutritionalInfo : IEntity<Guid>
    {
            public Guid Id { get; set; } = Guid.NewGuid();
            public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbs { get; set; }
    }
}
