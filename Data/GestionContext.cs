using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Data.Models;

namespace Data
{
    public class GestionContext : DbContext
    {

        public GestionContext()
        {
        }
        public GestionContext(DbContextOptions<GestionContext> options)
          : base(options)
        {
        }

        public static string GetConnectionString()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            var sampleConnectionString = root.GetConnectionString("Gestionconn");
            return sampleConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var con = GetConnectionString();
                optionsBuilder.UseSqlServer(con);
            }
        }

        #region DataSet 


        public virtual DbSet<SP_ConsultarTareas_Result> Consultar_Tareas { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
