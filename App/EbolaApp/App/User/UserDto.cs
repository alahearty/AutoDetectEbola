namespace EbolaApp.App
{
    public class UserDto : UserCommand
    {
        public VirusStatus LastPrediction { get; set; }
        public int TotalMVD { get; set; }
        public int TotalEVD { get; set; }
        public int TotalNIL { get; set; }
    }
}
