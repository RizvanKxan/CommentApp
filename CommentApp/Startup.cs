using CommentApp.BLL.Interfaces;
using CommentApp.BLL.Services;
using CommentApp.DAL;
using CommentApp.DAL.Patterns;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CommentApp
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
            // �������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // ��������� �������� MobileContext � �������� ������� � ����������
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddControllers();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IRecallService, RecallService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IMediaFileService, MediaFileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
