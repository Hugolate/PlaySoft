using Microsoft.EntityFrameworkCore;
using PlaySoftBeta.Services;
using PlaySoftBeta.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Jwt;
using System.Globalization;
using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var client = new SecretClient(new Uri("https://PlaysoftVault.vault.azure.net/"), new DefaultAzureCredential());
var clientId = await client.GetSecretAsync("client-id");
var clientSecret = await client.GetSecretAsync("clientSecret");

var config = SpotifyClientConfig
  .CreateDefault()
  .WithAuthenticator(new ClientCredentialsAuthenticator(clientId.Value.Value, clientSecret.Value.Value));

var spotify = new SpotifyClient(config);
builder.Services.AddSingleton<ISpotifyClient>(spotify);

builder.Services.AddDbContext<RepositoryContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("RepositoryContext")));
        
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAllHeaders",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});


builder.Services.AddCors();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddTransient<IAuthRepositoy, AuthRepository>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserServiceImpl>();

builder.Services.AddScoped<IPLaylistService, PlaylistServiceImpl>();
builder.Services.AddScoped<IPLaylistRepository, PlaylistRepository>();

builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<ISongService, SongServiceImpl>();

builder.Services.AddScoped<IPlaylistLinesRepository, PlaylistLinesRepositoryImpl>();

builder.Services.AddScoped<ISearchService, SearchServiceImpl>();


builder.Services.AddScoped<IArtistAlbumRepository, ArtistAlbumRepositoryImpl>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistServiceImpl>();
builder.Services.AddScoped<IArtistSongRepository, ArtistSongRepository>();

builder.Services.AddScoped<IAlbumService, AlbumServiceImpl>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepositoryImpl>();


builder.Services.AddAutoMapper(typeof(PlaysoftProfile));
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    //option.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Auth",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddMvc();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "CodeMaze",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtManager.Secret))
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors("AllowAllHeaders");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseCors(
    options =>
        options.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod()
);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseAuthorization();
app.MapControllers();
//AddCustomerData(app);
app.MapRazorPages();
app.Run();


