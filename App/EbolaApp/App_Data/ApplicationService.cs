namespace EbolaApp.App_Data
{
    public class ApplicationService
    {
        public ApplicationService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<UserDto> UpdateUser(UserDto user)
        {

            var exist = DbContext.Users.ToList().Where(x => x.Email.ToUpper() == user.Email.ToUpper()).FirstOrDefault();
            if (exist == null) return null;

            exist.FirstName = user.FirstName;
            exist.LastName = user.LastName;
            exist.Email = user.Email;
            exist.Phone = user.Phone;
            exist.Address = user.Address;
            exist.Latitude = user.Latitude;
            exist.Longitude = user.Longitude;
            exist.Country = user.Country;
            exist.City = user.City;
            exist.PostCode = user.PostCode;

            DbContext.Users.Update(exist);
            var dbOperation = await DbContext.SaveChangesAsync();
            if (dbOperation > 0)
                return user;

            return null;
        }

        public async Task<bool> AddUser(string email, string password)
        {
            var exist = DbContext.Users.ToList().Where(x => x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
            if (exist != null)
                return false;

            await DbContext.AddAsync(new User
            {
                Email = email,
                Password = Utils.HashPassword(password)
            });
            var dbOperation = await DbContext.SaveChangesAsync();
            if (dbOperation > 0)
                return true;

            return false;
        }
        public async Task<List<UserDto>> GetUsers()
        {
            var data = await DbContext.Users.ToListAsync();
            var predictions = await DbContext.Predictions.ToListAsync();
            var list = new List<UserDto>();
            foreach (var item in data)
            {
                var predict = predictions.Where(x => x.User.Id == item.Id).OrderBy(x => x.Date).LastOrDefault();
                var nil = predictions.Where(x => x.User.Id == item.Id && x.Status == VirusStatus.NIL).ToList();
                var evd = predictions.Where(x => x.User.Id == item.Id && x.Status == VirusStatus.EVD).ToList();
                var mvd = predictions.Where(x => x.User.Id == item.Id && x.Status == VirusStatus.MVD).ToList();
                list.Add(new UserDto
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Accuracy = item.Accuracy,
                    Address = item.Address,
                    Phone = item.Phone,
                    LastPrediction = predict == null ? VirusStatus.NIL : predict.Status,
                    TotalNIL = nil.Count,
                    TotalMVD = mvd.Count,
                    TotalEVD = evd.Count
                });
            }
            return list;
        }

        public async Task<List<PredictionDto>> GetPredictions()
        {
            var data = await DbContext.Predictions.ToListAsync();
            var list = new List<PredictionDto>();
            foreach (var item in data)
            {
                list.Add(new PredictionDto
                {
                    FirstName = item.User.FirstName,
                    LastName = item.User.LastName,
                    Email = item.User.Email,
                    Latitude = item.User.Latitude,
                    Longitude = item.User.Longitude,
                    Address = item.User.Address,
                    Phone = item.User.Phone,
                    Status = item.Status
                });
            }
            return list;
        }
        public async Task<UserDto> GetUser(string email)
        {
            var data = await DbContext.Users.ToListAsync();
            var predictions = await DbContext.Predictions.ToListAsync();

            var user = data.Where(x=>x.Email.ToUpper() == email.ToUpper()).FirstOrDefault();

            var predict = predictions.Where(x => x.User.Id == user.Id).OrderBy(x => x.Date).LastOrDefault();
            var nil = predictions.Where(x => x.User.Id == user.Id && x.Status == VirusStatus.NIL).ToList();
            var evd = predictions.Where(x => x.User.Id == user.Id && x.Status == VirusStatus.EVD).ToList();
            var mvd = predictions.Where(x => x.User.Id == user.Id && x.Status == VirusStatus.MVD).ToList();
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Latitude = user.Latitude,
                Longitude = user.Longitude,
                Accuracy = user.Accuracy,
                Address = user.Address,
                Phone = user.Phone,
                City = user.City,
                Country = user.Country,
                PostCode = user.PostCode,
                LastPrediction = predict == null ? VirusStatus.NIL : predict.Status,
                TotalNIL = nil.Count,
                TotalMVD = mvd.Count,
                TotalEVD = evd.Count
            };
        }
        public ApplicationDbContext DbContext { get; }

    }
}
