using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicVehicles
{
    abstract class Vehicle
    {
        public float FuelInLitres { get; protected set; }
        public float LitresPerKm { get; protected set; }

        public Vehicle()
        {
            FuelInLitres = 0f;
            LitresPerKm = 0f;
        }

        protected Vehicle(float fuelInLitres, float litresPerKm)
        {
            FuelInLitres = fuelInLitres;
            LitresPerKm = litresPerKm;
        }       

       internal virtual bool Drive(float distanceInKm)
        {
            var possibleDistance = FuelInLitres * LitresPerKm;

            if (possibleDistance >= distanceInKm)
            {
                FuelInLitres -= distanceInKm * LitresPerKm;
                Console.WriteLine($"{this.GetType().Name} travelled {distanceInKm} km.\n");
                return true;
            } else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling.\n");
                return false;
            }         
        }

        internal abstract void Refuel(float litres);
    }
}
