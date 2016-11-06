using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicVehicles
{
    class Truck : Vehicle
    {
        public Truck(): base()
        {

        }

        public Truck(bool isSummer, float fuelInLitres, float litresPerKm) : base(fuelInLitres, litresPerKm)
        {
            if (isSummer)
            {
                LitresPerKm = LitresPerKm + 1.6F;
            }
        }

        internal override void Refuel(float litres)
        {
            // Every truck has a hole in the tank :D
            FuelInLitres += litres * 0.95f;
            Console.WriteLine($"Truck has been refueled. It has {FuelInLitres} now!");
        }
    }
}
