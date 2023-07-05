using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nagarro.BookReading.Application.Interfaces;
using Nagarro.BookReading.Application.Services;
using Nagarro.BookReading.Core.Configuration;
using Nagarro.BookReading.Core.IRepositories;
using Nagarro.BookReading.Core.IRepositories.Base;
using Nagarro.BookReading.Infrastructure.Data;
using Nagarro.BookReading.Infrastructure.Repository;
using Nagarro.BookReading.Infrastructure.Repository.Base;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Services;
using System;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web
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
            ConfigureBookReadingEventServices(services);
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
            //createAdminWithRole(provider).Wait(); // Error
        }

        //endpoints.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}");
        public void ConfigureBookReadingEventServices(IServiceCollection services)
        {

            //Core Layer DI
            
            services.Configure<ConfigurationSettings>(Configuration);

            //Infrastructure Layer DI
            ConfigureDatabases(services);
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EventContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
               
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            //Application Layer DI
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICommentService, CommentService>();

            //Web Layer DI
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IEventPageService, EventPageService>();
            services.AddScoped<IAccountPageService, AccountPageService>();
            services.AddScoped<ICommentPageService, CommentPageService>();
            services.AddScoped<ServiceCollection>();

            //Miscellaneous
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

#endif
        }
        public void ConfigureDatabases(IServiceCollection services)
        {
            //// use database
            services.AddDbContext<EventContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("EventDatabase")));
        }

        //private RoleManager<IdentityUser> _roleManager;
        //private UserManager<IdentityUser> _userManager;

        //private async Task createAdminWithRole(IServiceProvider serviceProvider)
        //{
        //    _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityUser>>();
        //    _userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        //    var roleExist = await _roleManager.RoleExistsAsync("Admin");
        //    var userExist = await _userManager.FindByEmailAsync("myAdmin@bookevents.com");

        //    if(!roleExist || userExist == null)
        //    {
        //        if(!roleExist)
        //        {
        //            var role = new IdentityUser();
        //            role.UserName = "Admin";
        //            role.NormalizedUserName = "ADMIN";
        //            await _roleManager.CreateAsync(role);
        //        }

        //        if (userExist == null)
        //        {
        //            var user = new IdentityUser();
        //            user.UserName = "myAdmin@bookevents.com";
        //            user.Email = "myAdmin@bookevents.com";

        //            string userPassword = "Admin@1234";

        //            IdentityResult checkUser = await _userManager.CreateAsync(user, userPassword);

        //            if (checkUser.Succeeded)
        //            {
        //                var result = await _userManager.AddToRoleAsync(user, "Admin");
        //            }
        //        }
                        
        //    }

        //}
    }
}
