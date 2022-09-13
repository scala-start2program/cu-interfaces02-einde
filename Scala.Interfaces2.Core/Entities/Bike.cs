using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Interfaces2.Core.Entities
{
    public class Bike : Movable
    {
        public Bike(float averageSpeed, string model) : base(averageSpeed, model)
        {
        }

        public override TimeSpan Move(float kilometers)
        {
            float windFactor = random.Next(80, 120) / 100F;
            return CalculateTripDuration(kilometers, windFactor);
        }

    }
}
