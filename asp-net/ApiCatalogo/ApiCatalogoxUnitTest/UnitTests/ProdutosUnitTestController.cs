using ApiCatalogo.Repositories;
using ApiCatalogo.Repositories.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCatalogoxUnitTest.UnitTests
{
    public class ProdutosUnitTestController
    {

        public IUnitOfWork repository;

        public static DbContextOptions<SystemDbContext> dbContext { get; }

        public static string connectionString = "Server=DESKTOP-ESPF03F; Database=ApiCatalagoDb; trustServerCertificate=true; Integrated Security=true";

        static ProdutosUnitTestController()
        {
            dbContext = new DbContextOptionsBuilder<SystemDbContext>().UseSqlServer(connectionString).Options;
        }

        public ProdutosUnitTestController()
        {
            var context = new SystemDbContext(dbContext);
            repository = new UnitOfWork(context);
        }

    }
}
