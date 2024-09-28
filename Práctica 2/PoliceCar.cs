using System.ComponentModel.Design;

namespace Practice2
{
    public class PoliceCar : Vehicle
    {
        private static string typeOfVehicle = "Police Car";
        private string plate;
        private bool isPatrolling;
        private bool isChasing;
        private string chasingTaxi;
        private SpeedRadar speedRadar; 
        public PoliceStation policeStation;

        public PoliceCar(string plate, int measurer) : base(typeOfVehicle)
        {
            this.plate = plate;
            policeStation = null;
            isPatrolling = false;
            isChasing = false;
            chasingTaxi = "";
            // 0 -> null, 1 -> SpeedRadar
            if (measurer == 0) 
            { 
                speedRadar = null;
                Console.WriteLine(WriteMessage("with no measurer. Created."));
            }
            else if (measurer == 1) 
            { 
                speedRadar = new SpeedRadar();
                Console.WriteLine(WriteMessage("with SpeedRadar measurer. Created."));
            }
        }
        public string GetPlate()
        {
            return plate;
        }
        public PoliceStation PoliceStationGS 
        { 
            get => policeStation;
            set => policeStation = value;
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
        public void UseRadar(Taxi vehicle)
        {
            if (speedRadar is SpeedRadar)
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
                    Console.WriteLine(WriteMessage("has no active radar."));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
        }
        public void PrintRadarHistory()
        {
            if (speedRadar is SpeedRadar)
            { 
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                    {
                        Console.WriteLine(speed);
                    }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar."));
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
        public override string WriteMessage(string message)
        {
            return $"{base.ToString()} with plate {plate}: {message}";
        }
    }
}