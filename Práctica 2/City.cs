namespace Practice2
{
    class City: IMessageWritter
    {
        private string name;
        private List<Taxi> taxiLicenses;
        public PoliceStation policeStation;
        public City(string name)
        {
            this.name = name;
            taxiLicenses = new List<Taxi>();
            Console.WriteLine(WriteMessage($"{name} city: Created."));
            policeStation = new PoliceStation(name);
        }
        public string Name => name;
        public void AddTaxi(Taxi taxi)
        {
            taxiLicenses.Add(taxi);
            Console.WriteLine(taxi.WriteMessage($"Registered in {name}."));
        }
        public void RemoveTaxi(Taxi taxi)
        {
            for (int i = 0; i < taxiLicenses.Count; i++)
            {
                if (taxiLicenses[i].GetPlate() == taxi.GetPlate())
                {
                    taxiLicenses.RemoveAt(i);
                    Console.WriteLine(taxi.WriteMessage($"Eliminated of {name}."));
                }
            }
        }
        public string WriteMessage(string message)
        {
            return $"{message}";
        }
    }
}