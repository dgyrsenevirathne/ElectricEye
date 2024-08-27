using System.ComponentModel.DataAnnotations;


namespace ElectricEye.Web.Models
{
    public class AlertSetting
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } // Assuming you have user authentication

        [Required]
        public string Location { get; set; } // Location for which the alert is set

        [Required]
        public double Threshold { get; set; } // Threshold for the alert

        [Required]
        public string AlertType { get; set; } // Type of alert (e.g., email, SMS)
    }
}
