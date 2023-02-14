using EbolaApp.App;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ApplicationService>();
builder.Services.AddScoped<IUserHandler, UserHandler>();
builder.Services.AddScoped<IMLHandler, MLHandler>();
builder.Services.AddScoped<IAuthHandler, AuthHandler>();
builder.Services.AddAuthorization()
                .AddAuthentication(auth =>
                {
                   auth.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   auth.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                }).AddCookie(options =>
                {
                    options.LoginPath = "/login.html";
                    options.LogoutPath = "/logout.html";
                   // options.AccessDeniedPath = ConstantValue.FORBIDDEN;
                    options.Cookie.Name = "Ebola";
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(15);
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/api/register", (IAuthHandler handler, LoginCommand command) => handler.Register(command)).AllowAnonymous();
app.MapPost("/api/login", (IAuthHandler handler, LoginCommand command, HttpContext http) => handler.Login(command, http)).AllowAnonymous();
app.MapDelete("/api/logout", (IAuthHandler handler, HttpContext http) => handler.Logout(http)).RequireAuthorization();
app.MapGet("/api/profile/all", (IUserHandler handler) => handler.GetProfiles()).RequireAuthorization();
app.MapGet("/api/profile", (IUserHandler handler, HttpContext http) => handler.GetProfile(http)).RequireAuthorization();
app.MapPut("/api/profile", (IUserHandler handler, UserDto user) => handler.UpdateUser(user)).RequireAuthorization();
app.MapGet("/api/prediction", (IMLHandler handler) => handler.GetPredictions()).RequireAuthorization();
app.MapPost("/api/prediction", (IMLHandler handler, MedicalSymptomDto symptom) => handler.Predict(symptom)).RequireAuthorization();

app.Run();