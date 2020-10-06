using AutoMapper;
using LibrarySearchService.Core.Cqs;
using LibrarySearchService.Core.Mappings;
using LibrarySearchService.Core.Queries;
using LibrarySearchService.Core.Services;
using LibrarySearchService.Core.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibrarySearchService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddTransient<IQueryHandler, FindBooksQueryHandler>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookModelProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
