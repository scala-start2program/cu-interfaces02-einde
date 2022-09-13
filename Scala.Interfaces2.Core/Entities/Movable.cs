using Scala.Interfaces2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Interfaces2.Core.Entities
{
    public abstract class Movable : IMovable
    {
        protected static Random random = new Random();
        public float AverageSpeed { get; set; }
        public virtual string TransportationInfo
        {
            get { return $"{Model}\n\t{AverageSpeed} km/u."; }
        }
        public string Model { get; set; }
        public TimeSpan TimePerKilometer
        {
            get
            {
                TimeSpan hour = TimeSpan.FromHours(1);
                return hour / AverageSpeed;
            }
        }
        public Movable(float averageSpeed, string model)
        {
            AverageSpeed = averageSpeed;
            Model = model;
        }

        public abstract TimeSpan Move(float kilometers);

        protected TimeSpan CalculateTripDuration(float kilometers, float speedFactor)
        {
            return TimePerKilometer * kilometers * speedFactor;
        }

        public override string ToString()
        {
            return TransportationInfo;
        }
    }

}
