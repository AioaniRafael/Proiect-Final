using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CosModel
    {
        [Key]
        public int Id_Cos { get; set; }
        public int Id_Produs { get; set; }
        public string Nume_Produs { get; set; }
        public int Cantitate_Produs { get; set; }
    }
    public class CosDbContext:DbContext
    {
        public DbSet<CosModel> Cos { get; set; }
    }
}