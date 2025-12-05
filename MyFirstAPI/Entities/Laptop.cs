namespace MyFirstAPI.Entities
{
    public sealed class Laptop:Device
    {
        public override string GetBrand()
        {
            return "Apple";
        }

        public string GetModel()
        {
            var isConnected = IsConnected();
            if (isConnected) return "Mackbook";
            return "Unknown";
        }

        override public string Hello()
        {
            return "Hello From Laptop";
        }

    }
}
