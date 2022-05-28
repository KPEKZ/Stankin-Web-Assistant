using SWA.Database;
using Microsoft.EntityFrameworkCore;
using SWA.Database.Repositories.UserInfoRepository;
using SWA.Database.Repositories.ExcelRepository;
using SWA.Database.Repositories.ProblemRepository;

namespace Backend
{
    public class Startup
    {
		private readonly string _corsPolicy = "AskBmstuFm";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFrameworkNpgsql().AddDbContext<SWADbContext>(options =>
				options.UseNpgsql(Configuration.GetConnectionString("SWA"))
			);

			services.AddTransient<IProblemRepository, ProblemRepository>();
			services.AddTransient<IExcelRepository, ExcelRepository>();
			services.AddTransient<IReferenceRepository, ReferenceRepository>();
			services.AddTransient<IExcelRepository, ExcelRepository>();
			services.AddTransient<IUserInfoRepository, UserInfoRepository>();

			services.AddControllers();
			services.AddHealthChecks();
			services.AddCors(o => o.AddPolicy(_corsPolicy, builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));


		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			UpdateDatabase(app);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(_corsPolicy);
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void UpdateDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<SWADbContext>();
			context?.Database.Migrate();
			context?.Database.EnsureCreated();
		}
	
	}
}
