namespace Practice2
{
    public class PoliceStation: IMessageWritter
    {
        private List<PoliceCar> policeCarList;
        public string CityName { get; private set; }
        public PoliceStation(string city)
        {
            this.CityName = city;
            policeCarList = new List<PoliceCar>();
        }
        public void AddPoliceCar(PoliceCar pc)
        {
            Console.WriteLine(pc.WriteMessage($"Added to the PoliceStation of {CityName}"));
            policeCarList.Add(pc);
            pc.PoliceStationGS = this;
        }
        public void ActivateAlert(string plate)
        {
            Console.WriteLine(WriteMessage($"Alerta activada: Perseguir taxi con placa {plate}."));
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