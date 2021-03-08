using System;
using System.Text;
using System.Collections.Generic;

namespace cv04_bpc_oop
{
    sealed class PersonalCar : Car
    {
        private int maxPassengers;
        public int MaxPassengers
        {
            get
            { return maxPassengers; }
            private set
            { maxPassengers = value; }
        }

        private int currentPassengers;
        public int CurrentPassengers
        {
            get
            { return currentPassengers; }
            set
            {
                if (value > MaxPassengers)
                    throw new ArgumentException("The car is overloaded.");
                else
                    currentPassengers = value;
            }
        }

        public PersonalCar(string name, double fuelTankVolume, int maxPassengers, Car.FuelType consumedFuelType, double fuelTankState = 0.0, int currentPassengers = 0)
        {
            CarRadio = new Radio();
            Name = name;
            FuelTankVolume = fuelTankVolume;
            MaxPassengers = maxPassengers;
            ConsumedFuelType = consumedFuelType;
            FuelTankState = fuelTankState;
            CurrentPassengers = currentPassengers;
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

            outputText.AppendFormat("Cestující: {0:d}/{1:d}\n\n", CurrentPassengers, MaxPassengers);
            outputText.Append("Rádio:\n");
            outputText.Append("  Stav: ");
            if (CarRadio.RadioState == true)
            {
                outputText.Append("Zapnuto\n");
                outputText.AppendFormat("  Nastavená frekvence: {0:f1}\n", CarRadio.CurrentFrequency);
                outputText.Append("  Seznam stanic:\n");
                foreach(KeyValuePair<int, double> item in CarRadio.Presets)
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
