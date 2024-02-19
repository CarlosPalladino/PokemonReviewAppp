//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using PokemonReviewApp;
//using PokemonReviewAppp.Data;
//using PokemonReviewAppp.Interfaces;
//using PokemonReviewAppp.Repository;
//using System.Reflection;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddTransient<Seed>();
//builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

////builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
//builder.Services.AddScoped<ICountryRespository, CountryRespository>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
//builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
//builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowMyOrigin",
//        builder => builder.WithOrigins("http://localhost:4200")
//                          .WithMethods("GET", "POST", "PUT", "DELETE")
//                          .WithHeaders("Content-Type"));
//});

//builder.Services.ConfigureSwaggerGen(setup =>
//{
//    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
//    {
//        Title = "Poke app",
//        Version = "v1"
//    });
//});


//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection"));
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//app.UseSwagger();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseCors("AllowMyOrigin");

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
