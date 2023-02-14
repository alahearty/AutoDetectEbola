namespace EbolaApp.Models
{
    public class Prediction : Entity
    {
        public User User { get; protected set; }
        public DateTime Date { get; protected set; }
        public VirusStatus Status { get; set; }
    }
}
