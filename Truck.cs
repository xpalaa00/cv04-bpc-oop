using System;
using System.Collections.Generic;
using System.Text;

namespace cv04_bpc_oop
{
    sealed class Truck : Car
    {
        private double maxLoad;
        public double MaxLoad
        {
            get
            { return maxLoad; }
            private set
            { maxLoad = value; }
        }

        private double currentLoad;
        public double CurrentLoad
        {
            get
            { return currentLoad; }
            set
            {
                if (value > MaxLoad)
                    throw new ArgumentException("The car is overloaded.");
                else
                    currentLoad = value;
            }
        }
        public Truck(string name, double fuelTankVolume, double maxLoad, Car.FuelType consumedFuelType, double fuelTankState = 0.0, double currentLoad = 0)
        {
            CarRadio = new Radio();
            Name = name;
            FuelTankVolume = fuelTankVolume;
            MaxLoad = maxLoad;
            ConsumedFuelType = consumedFuelType;
            FuelTankState = fuelTankState;
            CurrentLoad = currentLoad;
        }

        public override string ToString()
        {
            StringBuilder outputText = new StringBuilder();
            outputText.Append("==================================================\n");
            outputText.AppendFormat("Název vozu: {0}\n\n", Name);
            outputText.AppendFormat("Palivo: {0:f1}/{1:f1} (", FuelTankState, FuelTankVolume);
            if (ConsumedFuelType == FuelType.natural)
                outputText.Append("Benzín)\n");
            else
                outputText.Append("Nafta)\n");

            outputText.AppendFormat("Náklad: {0:f1}/{1:f1}\n\n", CurrentLoad, MaxLoad);
            outputText.Append("Rádio:\n");
            outputText.Append("  Stav: ");
            if (CarRadio.RadioState == true)
            {
                outputText.Append("Zapnuto\n");
                outputText.AppendFormat("  Nastavená frekvence: {0:f1}\n", CarRadio.CurrentFrequency);
                outputText.Append("  Seznam stanic:\n");
                foreach (KeyValuePair<int, double> item in CarRadio.Presets)
                {
                    outputText.AppendFormat("    {0:d}: {1:f1}\n", item.Key, item.Value);
                }
            }
            else
                outputText.Append("Vypnuto\n");
            outputText.Append("==================================================\n");

            return outputText.ToString();
        }
    }
}
