using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StocController : Controller
    {
        // GET: Stoc
        private StocDbContext dbStoc=new StocDbContext();
        public ActionResult Index()
        {
            return View(dbStoc.Stoc.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            StocModel msg = new StocModel();
            return View(msg);
        }
        [HttpPost]
        public ActionResult Create(StocModel msg)
        {
            dbStoc.Stoc.Add(msg);
            dbStoc.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            StocModel msg = dbStoc.Stoc.Find(id);
            return View(msg);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            StocModel msg = dbStoc.Stoc.Find(id);
            return View(msg);
        }
        [HttpPost]
        public ActionResult Edit(StocModel msg)
        {
            dbStoc.Entry(msg).State = System.Data.Entity.EntityState.Modified;
            dbStoc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            StocModel msg = dbStoc.Stoc.Find(id);
            return View(msg);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            StocModel msg = dbStoc.Stoc.Find(id);
            dbStoc.Stoc.Remove(msg);
            dbStoc.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult  AdaugaLaCosulDeCumparaturi(int? id)
        {
            StocModel msg = dbStoc.Stoc.Find(id);
            return View(msg);
        }
        [HttpPost]
        public ActionResult AdaugaLaCosulDeCumparaturi(CosModel msg)
        {
            using (CosDbContext dbCos=new CosDbContext())
            {
                using (StocDbContext dbStoc = new StocDbContext())
                {
                    dbCos.Cos.Add(msg);
                    dbCos.SaveChanges();
                    StocModel msg1 = dbStoc.Stoc.Find(msg.Id_Produs);
                    msg1.Cantitate_Produs=msg1.Cantitate_Produs-msg.Cantitate_Produs;
                    dbStoc.SaveChanges() ;
                }
                
            }
            
            
            return RedirectToAction("Index");
        }
    }
}