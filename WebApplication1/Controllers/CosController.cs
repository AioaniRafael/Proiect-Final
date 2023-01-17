using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CosController : Controller
    {
        private CosDbContext dbCos = new CosDbContext();
        // GET: Cos
        public ActionResult Index()
        {
            return View(dbCos.Cos.ToList());
        }
        [HttpGet]
        public ActionResult DeleteProdus(int? id)
        {
            CosModel msg = dbCos.Cos.Find(id);
            return View(msg);
        }
        [HttpPost]
        public ActionResult DeleteProdus(int id)
        {
            using (CosDbContext dbCos = new CosDbContext())
            {
                using (StocDbContext dbStoc = new StocDbContext())
                {
                    CosModel msg = dbCos.Cos.Find(id);
                    dbCos.Cos.Remove(msg);
                    dbCos.SaveChanges();
                    
                    StocModel msg1 = dbStoc.Stoc.Find(msg.Id_Produs);

                    msg1.Cantitate_Produs = msg1.Cantitate_Produs + msg.Cantitate_Produs;
                    dbStoc.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            CosModel msg = dbCos.Cos.Find(id);
            return View(msg);
        }
        [HttpPost]
        public ActionResult Edit(CosModel msg)
        {
            
                    dbCos.Entry(msg).State = System.Data.Entity.EntityState.Modified;
                    dbCos.SaveChanges();
                    return RedirectToAction("Index ");
                
        }
    }
}