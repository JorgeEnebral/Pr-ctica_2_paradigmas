namespace Practice2
{
    class Program
    {

        static void Main()
        {
            // Create city and PoliceStation
            City city = new City("Madrid");

            // Create vehicles
            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");
            PoliceCar policeCar1 = new PoliceCar("0001 CNP", 1);  // 0 -> null, 1 -> SpeedRadar, 2 -> AlcoholicDetector
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", 1);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", 0);
            Scooter scooter1 = new Scooter();

            // Add vehicles
            city.AddTaxi(taxi1);
            city.AddTaxi(taxi2);
            city.policeStation.AddPoliceCar(policeCar1);
            city.policeStation.AddPoliceCar(policeCar2);
            city.policeStation.AddPoliceCar(policeCar3);

            // Police car has no radar
            policeCar2.UseRadar(taxi1);

            // PoliceSttion alert 
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar3.StartPatrolling();
            policeCar1.UseRadar(taxi1);

            // Remove taxi from city
            city.RemoveTaxi(taxi1);

        }
    }
}
    

