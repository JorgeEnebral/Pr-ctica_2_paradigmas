using System.Xml.Linq;

namespace Practice2
{
    public class PoliceStation: IMessageWritter
    {
        private List<PoliceCar> policeCarList;
        public string CityName { get; private set; }
        public PoliceStation(string city)
        {
            CityName = city;
            policeCarList = new List<PoliceCar>();
            Console.WriteLine(WriteMessage($"{CityName} PoliceStation: Created."));
        }
        public void AddPoliceCar(PoliceCar pc)
        {
            Console.WriteLine(pc.WriteMessage($"Added to the PoliceStation of {CityName}."));
            policeCarList.Add(pc);
            pc.PoliceStationGS = this;
        }
        public void ActivateAlert(string plate)
        {
            Console.WriteLine(WriteMessage($"{CityName} PoliceStation alert activated: chasing taxi with plate {plate}."));
            foreach (var policeCar in policeCarList)
            {
                if (policeCar.IsPatrolling())
                {
                    policeCar.PursueTaxi(plate);
                }
            }
        }
        public string WriteMessage(string message)
        {
            return $"{message}";
        }
    }
}