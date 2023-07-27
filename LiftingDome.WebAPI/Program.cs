namespace LiftingDome.WebAPI
{
	using LiftingDome.Data;
	using LiftingDome.Infrastructure.Extensions;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			string connectionString
				= builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<LiftingDomeDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddApplicationServices(typeof(IWorkoutService));

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(setup =>
			{
				setup.AddPolicy("LiftingDome", policyBuilder =>
				{
					policyBuilder
					.WithOrigins("https://localhost:7115")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.UseCors("LiftingDome");

			app.Run();
		}
	}
}