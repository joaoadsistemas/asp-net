using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoxUnitTest
{
    public class ProductsUnitTestController
    {

        public IUnitOfWork repository;

        public static DbContextOptions<SystemDbContext> dbContext { get; }

        // public static string connectionString = "Server=DESKTOP-ESPF03F; Database=ApiCatalagoDb; trustServerCertificate=true; Integrated Security=true"; // PC
        public static string connectionString = "Server=DESKTOP-7HAELNV; Database=ApiCatalagoDb; trustServerCertificate=true; Integrated Security=true"; // NOTEBOOK


        static ProductsUnitTestController()
        {
            dbContext = new DbContextOptionsBuilder<SystemDbContext>().UseSqlServer(connectionString).Options;
        }

        public ProductsUnitTestController()
        {
            var context = new SystemDbContext(dbContext);
            repository = new UnitOfWork(context);
        }

    }
}
