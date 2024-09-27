namespace Practice2
{
    public class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        private bool isChasing;
        private string chasingTaxi;
        public PoliceStation policeStation;

        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            isChasing = false;
            chasingTaxi = "";
            policeStation = null;
        }
        public PoliceStation PoliceStationGS 
        { 
            get => policeStation;
            set => policeStation = value;
        }
        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                if (meassurement.Contains("Catched"))
                {
                    AlertNotification(vehicle.GetPlate());
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }

        public void AlertNotification(string plate)
        {
            if (PoliceStationGS != null)
            {
                PoliceStationGS.ActivateAlert(plate);
            }
        }
        public void PursueTaxi(string plate)
        {
            isChasing = true;
            chasingTaxi = plate;
            Console.WriteLine(WriteMessage($"is pursuing taxi with plate {plate}."));
            
        }
    }
}