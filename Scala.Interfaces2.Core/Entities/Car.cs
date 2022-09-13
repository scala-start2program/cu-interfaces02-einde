﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Interfaces2.Core.Entities
{
    public class Car : Movable
    {
        public float AverageConsumption { get; set; }
        public override string TransportationInfo
        {
            get
            {
                return $"{base.TransportationInfo}\n\t{AverageConsumption} l/100 km.";
            }
        }
        public Car(float averageSpeed, string type, float averageConsumption) :
                base(averageSpeed, type)
        {
            AverageConsumption = averageConsumption;
        }


        public override TimeSpan Move(float kilometers)
        {
            int trafficFluency = random.Next(0, 51);
            float trafficInfluence = (100 + trafficFluency) / 100F;
            return CalculateTripDuration(kilometers, trafficInfluence);
        }

    }
}
