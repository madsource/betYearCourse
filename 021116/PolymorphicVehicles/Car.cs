using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorphicVehicles
{
    class Car : Vehicle
    {
        public Car():base() { }

        public Car(bool isSummer, float fuelInLitres, float litresPerKm) : base(fuelInLitres, litresPerKm)
        {
            if(isSummer)
            {
                LitresPerKm = LitresPerKm + 0.9F;
            } 
        }

        internal override void Refuel(float litres)
        {
            FuelInLitres += litres;
            Console.WriteLine($"Car has been refueled. It has {FuelInLitres} now!\n");
        }
          
    }
}
