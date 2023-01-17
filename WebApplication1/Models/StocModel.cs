using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class StocModel
    {
        [Key]
        public int Id_Produs { get; set; }
        public string Nume_Produs { get; set; }
        public string Material_Produs { get; set; }
        public int Cantitate_Produs { get; set; }
    }
    public class StocDbContext : DbContext
    {
        public DbSet<StocModel> Stoc { get; set; }
    }
    
}






