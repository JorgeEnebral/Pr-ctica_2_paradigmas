namespace Practice2
{
    public abstract class Vehicle : IMessageWritter
    {
        private string typeOfVehicle;
        private float speed;

        public Vehicle(string typeOfVehicle)
        {
            this.typeOfVehicle = typeOfVehicle;
            speed = 0f;
        }
        public string GetTypeOfVehicle()
        {
            return typeOfVehicle;
        }
        public float GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }
        public virtual string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}