using Microsoft.EntityFrameworkCore;
using PlaySoftBeta.Services;
using PlaySoftBeta.Models;
using PlaySoftBeta.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RepositoryContext")));

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
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(("RepositoryContext"));
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


builder.Services.AddAutoMapper(typeof(PlaysoftProfile));
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

var app = builder.Build();

app.UseCors("AllowAllHeaders");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
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


