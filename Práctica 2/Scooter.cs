﻿namespace Practice2
{
    public class Scooter : Vehicle
    {
        private static string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle)
        {
            Console.WriteLine(WriteMessage("Created."));
        }
    }
}