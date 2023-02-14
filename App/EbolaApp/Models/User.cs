namespace EbolaApp.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Password { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Accuracy { get; set; }
        public IList<MedicalRecord> MedicalRecords { get; set; }
        public IList<Prediction> Predictions { get; set; }
    }
}
