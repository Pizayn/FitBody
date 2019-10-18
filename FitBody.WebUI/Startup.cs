using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitBody.Business.Abstract;
using FitBody.Business.Concrete;
using FitBody.DataAccess.Abstract;
using FitBody.DataAccess.Concrete;
using FitBody.Entities.Concrete;
using FitBody.WebUI.Entities;
using FitBody.WebUI.MiddleWares;
using FitBody.WebUI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitBody.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
      
            
            services.AddScoped<IExerciseService, ExerciseManager>();
            services.AddScoped<IExerciseDal, ExerciseDal>();
            services.AddScoped<ISupplementService, SupplementManager>();
            services.AddScoped<ISupplementDal, SupplementDal>();
            services.AddScoped<ISupplementCategoryService, SupplementCategoryManager>();
            services.AddScoped<ISupplementCategoryDal, SupplementCategoryDal>();
            services.AddScoped<ISupplementSubCategoryService, SupplementSubCategoryManager>();

            services.AddScoped<ISupplementSubCategoryDal, SupplementSubCategoryDal>();
                
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddScoped<IOrderLineService, OrderLineManager>();
            services.AddScoped<IOrderLineDal, OrderLineDal>();
            services.AddScoped<IOrderDal, OrderDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IExerciseTypeService, ExerciseTypeManager>();
            services.AddScoped<IExerciseTypeDal, ExerciseTypeDal>();
            services.AddScoped<ITrainerService, TrainerManager>();
            services.AddScoped<ITrainerDal, TrainerDal>();
            services.AddScoped<IShippingDetailService, ShippingDetailManager>();
            services.AddScoped<IShippingDetailDal, ShippingDetailDal>();
            services.AddScoped<IBlogPostService, BlogPostManager>();
            services.AddScoped<IBlogPostDal, BlogPostDal>();



            services.AddDbContext<CustomIdentityContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-4DUE46S;Database=FitBody; Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDistributedMemoryCache();//bunu eklemezsek session aktifleştirilmemiş hatası alınır

            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseFileServer();
           
            app.UseSession();

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();


         


        }
    }
}
