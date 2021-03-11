using System;
using System.Collections.Generic;

namespace cv04_bpc_oop
{
    public class Radio
    {
        //Pozn.: Vypnuté rádio neposkytne o sobě žádné informace
        //(při snaze získat info krom stavu zapnutí je vyhozena chyba) a nelze s ním ani manipulovat

        //Lze nastavit i vlastní frekvenci (pokud je zadání platné) bez ohledu na předvolby
        private double currentFrequency;
        public double CurrentFrequency
        {
            get
            { 
                if (RadioState)
                    return currentFrequency;
                else
                    throw new ArgumentException("Unable to get current frequency, the radio is turned off.");
            }
            set
            {
                if (value <= 0.0)
                    throw new ArgumentException("Frequency is negative or equal to zero.");
                else if(RadioState)
                    currentFrequency = value;
                else
                    throw new ArgumentException("Unable to set current frequency, the radio is turned off.");
            }
        }
        private bool radioState;
        public bool RadioState
        {
            get
            { return radioState; }
            set
            {
                if (value == true && (double.IsNaN(currentFrequency) || currentFrequency <= 0.0))
                    //Ke stavu by nemělo dojít, uživatel nemůže nastavit nulovou nebo zápornou frekvenci a výchozí přednastavená je 1.0
                    throw new ArgumentException("Current frequency has not been initialized.");
                else
                    radioState = value;
            }
        }

        private Dictionary<int, double> presets;
        public Dictionary<int, double> Presets
        {
            get
            {
                if (RadioState)
                    return presets;
                else
                    throw new ArgumentException("Unable to get presets, the radio is turned off.");
            }
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
            else if (RadioState)
            {
                //Zadáním záporné frekvence nad existující předvolbou je předvolba vymazána
                if (frequency <= 0.0)
                    Presets.Remove(index);
                else
                    Presets[index] = frequency;
            }
            else
                throw new InvalidOperationException("Unable to save preset, the radio is turned off.");
        }

        public void ChangeChannel(int index)
        {
            if (!Presets.ContainsKey(index))
                throw new ArgumentException("Unable to find the preset, the preset does not exist.");
            else if (RadioState)
                CurrentFrequency = Presets[index];
            else
                throw new InvalidOperationException("Unable to set channel, the radio is turned off.");
        }

        public Radio(double defaultFrequency = 1.0, bool defaultState = false)
        {
            Presets = new Dictionary<int, double> { };
            radioState = true; //Bypass výjimky pro vypnuté rádio (zápis do stávající frekvence vyžaduje zapnutí rádia), zápis přes věřejnou vlastnost není možná (požadavek na inicializaci frekvence)
            CurrentFrequency = defaultFrequency; //Zápis musí být skze veřejnou vlastnost (kontrola na platnost zadání frekvence)
            RadioState = defaultState; //Uvedení rádia do stavu, který požaduje uživatel
        }
    }
}
