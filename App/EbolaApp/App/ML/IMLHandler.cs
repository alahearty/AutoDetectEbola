namespace EbolaApp.App
{
    public interface IMLHandler
    {
        Task<IResult> Predict(MedicalSymptomDto symptom);
        Task<IResult> GetPredictions();
    }
}
