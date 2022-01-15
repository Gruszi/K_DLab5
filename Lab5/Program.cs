using K_DLab5.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace K_DLab5
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<CarContext>();
                SeedDB(context);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SeedDB(CarContext context)
        {
            var carItemList = context.CarItems.ToList();
            if (carItemList.Count > 0) return;

            var Auta = new List<Car>();
            Auta.Add(new Car
            {
                Id = 1,
                Marka = "Mercedes",
                Model = "C63",
                MocSilnika = 250,
                Przebieg = 1000,
                Rocznik = DateTime.Now.ToString(),
            }); ;
            Auta.Add(new Car
            {
                Id = 2,
                Marka = "Fiat",
                Model = "Multipla",
                MocSilnika = 70,
                Przebieg = 400,
                Rocznik = DateTime.Now.ToString(),
            });
            Auta.Add(new Car
            {
                Id = 3,
                Marka = "Dodge",
                Model = "viper",
                MocSilnika = 140,
                Przebieg = 202324,
                Rocznik = DateTime.Now.ToString(),
            });
            Auta.Add(new Car
            {
                Id = 4,
                Marka = "Opel",
                Model = "Astra",
                MocSilnika = 95,
                Przebieg = 19990,
                Rocznik = DateTime.Now.ToString(),
            });
            context.AddRange(Auta);
            context.SaveChanges();

        }

    }

}
