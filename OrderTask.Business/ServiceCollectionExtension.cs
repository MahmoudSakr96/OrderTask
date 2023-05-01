using Microsoft.Extensions.DependencyInjection;
using OrderTask.Business;
using OrderTask.Business.Contracts.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTask.Business;
using GlobalApp.Demo.Application.Services;

namespace GlobalApp.Demo.Application
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureApplicationServices1(this IServiceCollection services)
        {

            //services.AddScoped<IOrderAppService, OrderAppService>();
            //services.AddScoped<IDepartmentAppService, DepartmentAppService>();
        }
    }
}
