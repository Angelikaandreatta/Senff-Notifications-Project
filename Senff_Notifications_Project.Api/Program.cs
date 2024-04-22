using Senff_Notifications_Project.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "your_issuer",
//            ValidAudience = "your_audience",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key")),
//            ClockSkew = TimeSpan.Zero
//        };

//        options.Events = new JwtBearerEvents
//        {
//            OnTokenValidated = async context =>
//            {
//                var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
//                var userId = Guid.Parse(context.Principal.Identity.Name);
//                //var user = await userService.GetUserById(userId);

//                //if (user == null)
//                //    context.Fail("Unauthorized");
//            }
//        };
//    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
