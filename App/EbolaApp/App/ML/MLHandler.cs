namespace EbolaApp.App
{
    public class MLHandler : IMLHandler
    {
        public async Task<IResult> Predict(MedicalSymptomDto symptom)
        {
            return await Task.FromResult(Results.Ok(MLPredict(symptom)));
        }

        public async Task<IResult> GetPredictions()
        {
            var predictions = await _service.GetPredictions();
            return Results.Ok(predictions);
        }

        private VirusStatus MLPredict(MedicalSymptomDto symptom)
        {
            return VirusStatus.EVD;
        }
        private ApplicationService _service;
    }
}
