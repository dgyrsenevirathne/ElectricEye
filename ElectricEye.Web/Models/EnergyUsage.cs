namespace ElectricEye.Web.Models
{
    public class EnergyUsage
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Location { get; set; }
        public decimal Consumption { get; set; }
        public string UserName { get; set; }

    }
}
