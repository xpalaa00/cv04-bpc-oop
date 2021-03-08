using System;
using System.Collections.Generic;

namespace cv04_bpc_oop
{
    class Radio
    {
        private double currentFrequency;
        public double CurrentFrequency
        {
            get
            { return currentFrequency; }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("Frequency is negative or equal to zero.");
                else
                    currentFrequency = value;
            }
        }
        private bool radioState;
        public bool RadioState
        {
            get
            { return radioState; }
            set
            {
                if (value == true && (double.IsNaN(CurrentFrequency) || CurrentFrequency <= 0.0))
                    throw new ArgumentException("Current frequency has not been initialized.");
                else
                    radioState = value;
            }
        }

        private Dictionary<int, double> presets;
        public Dictionary<int, double> Presets
        {
            get
            { return presets; }
            private set
            { presets = value; }
        }

        public void SavePreset(int index, double frequency)
        {
            if (!Presets.ContainsKey(index))
                if (frequency <= 0.0)
                    throw new ArgumentException("Unable to remove the preset, the preset does not exist.");
                else
                    Presets.Add(index, frequency);
            else
            {
                if (frequency <= 0.0)
                    Presets.Remove(index);
                else
                    Presets[index] = frequency;
            }
        }

        public void ChangeChannel(int index)
        {
            if(!Presets.ContainsKey(index))
                throw new ArgumentException("Unable to find the preset, the preset does not exist.");
            else
                CurrentFrequency = Presets[index];
        }

        public Radio(double defaultFrequency = 1.0, bool defaultState = false)
        {
            Presets = new Dictionary<int, double> { };
            CurrentFrequency = defaultFrequency;
            RadioState = defaultState;
        }
    }
}
