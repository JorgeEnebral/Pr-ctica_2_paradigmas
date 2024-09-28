namespace Practice2
{
    public class Taxi : Vehicle
    {
        private static string typeOfVehicle = "Taxi";
        private string plate;
        private bool isCarryingPassengers;

        public Taxi(string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
            isCarryingPassengers = false;
            SetSpeed(45.0f);
            Console.WriteLine(WriteMessage("Created."));
        }

        public string GetPlate()
        {
            return plate;
        }
        public void StartRide()
        {
            if (!isCarryingPassengers)
            {
                isCarryingPassengers = true;
                SetSpeed(100.0f);
                Console.WriteLine(WriteMessage("starts a ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already in a ride."));
            }
        }
        public void StopRide()
        {
            if (isCarryingPassengers)
            {
                isCarryingPassengers = false;
                SetSpeed(45.0f);
                Console.WriteLine(WriteMessage("finishes ride."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is not on a ride."));
            }
        }
        public override string WriteMessage(string message)
        {
            return $"{base.ToString()} with plate {plate}: {message}";
        }
    }
}