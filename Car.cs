using System;

namespace cv04_bpc_oop
{
    abstract public class Car
    {
        public string Name;
        
        public enum FuelType {natural, diesel};

        public Radio CarRadio;

        private double fuelTankVolume;
        public double FuelTankVolume
        {
            get
            { return fuelTankVolume; }
            protected set
            { fuelTankVolume = value; }
        }

        private double fuelTankState;
        public double FuelTankState
        {
            get
            { return fuelTankState; }
            protected set
            { fuelTankState = value; }
        }

        private FuelType consumedFuelType;
        public FuelType ConsumedFuelType
        {
            get
            { return consumedFuelType; }
            protected set
            { consumedFuelType = value; }
        }

        public void Refuel(FuelType fuelType, double amount)
        {
            if(ConsumedFuelType != fuelType)
              throw new ArgumentException("Wrong fuel type.");
            else if(FuelTankVolume < (amount + FuelTankState))
              throw new ArgumentException("Fuel tank overflowed.");
            else if(amount < 0.0)
              throw new ArgumentException("Fuel amount has negative value.");
            else
              FuelTankState += amount;
        }
    }
}
