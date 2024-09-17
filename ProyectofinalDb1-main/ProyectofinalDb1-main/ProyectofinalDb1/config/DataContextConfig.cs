using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectofinalDb1.data;

namespace ProyectofinalDb1.config
{
    public class DataContextConfig
    {
        public static DataContext GetDataContext()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Configurar el DbContext
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            // Crear una instancia del DbContext
            return serviceProvider.GetService<DataContext>();
        }
    }
}
