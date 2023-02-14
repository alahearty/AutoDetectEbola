namespace EbolaApp.Models
{
    public class MedicalRecord : Entity
    {
        protected MedicalRecord() { }
        public MedicalRecord(User user)
        {
            User = user;
            Date = DateTime.Now;
        }
        public double BodyTemperature { get; set; }
        public bool IsSevere { get; set; }
        public bool ProlongedHighFever { get; set; }
        public bool FrequentHeadache { get; set; }
        public bool AbdominalStomachPain { get; set; }
        public bool Vomiting { get; set; }
        public bool Nausea { get; set; }
        public bool Diarrhea { get; set; }
        public bool SoreThroat { get; set; }
        public bool Lethargy { get; set; }
        public bool ChestPain { get; set; }
        public bool Weakness { get; set; }
        public bool Dehydration { get; set; }
        public bool RedEyes { get; set; }
        public bool LackOfAppetite { get; set; }
        public bool DifficultyInBreathing { get; set; }
        public bool InternalExternalBleeding { get; set; }
        public bool SkinTexture { get; set; }
        public bool HighFever { get; set; }
        public bool SevereHeadache { get; set; }
        public bool MuscleAchesAndPains { get; set; }
        public bool SevereMalaise { get; set; }
        public bool SevereWateryDiarrhea { get; set; }
        public bool AbdominalPainAndCramping { get; set; }
        public bool DeepSetEyes { get; set; }
        public bool ExpressionlessFaces { get; set; }
        public bool ExtremeLethargy { get; set; }
        public bool NonitchyRash { get; set; }
        public bool MultipleBleeding  { get; set; }
        public bool IrritabilityAndAggression { get; set; }
        public bool Orchitis { get; set; }
        public bool SevereBloodLossAndShock { get; set; }
        public User User { get; protected set; }
        public DateTime Date { get; protected set; }
    }
}
