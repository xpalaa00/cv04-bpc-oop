using System;

namespace cv04_bpc_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalCar car1 = new PersonalCar("Osobák", 60.0, 5, Car.FuelType.natural);
            Truck car2 = new Truck("Kamion", 100.0, 4000.0, Car.FuelType.diesel);

            car1.Refuel(Car.FuelType.natural, 40.0);
            car2.Refuel(Car.FuelType.diesel, 85.0);

            car1.CurrentPassengers = 4;
            car2.CurrentLoad = 3501.4;

            car1.CarRadio.CurrentFrequency = 1.0;
            car2.CarRadio.CurrentFrequency = 1.0;

            car1.CarRadio.RadioState = true;
            car1.CarRadio.SavePreset(1, 97.7);
            car1.CarRadio.SavePreset(5, 101.2);
            car1.CarRadio.SavePreset(6, 102.5);
            car1.CarRadio.ChangeChannel(5);

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());

            Console.ReadLine();
        }
    }
}
