
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sube2.HelloMvc.Models;

namespace Sube2.HelloMvc.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Dersler.ToList();
                return View(lst);
            }
        }
        [HttpGet]
        public IActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DersEkle(Ders der)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Dersler.Add(der);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult DersGuncelle(int id)
        {
            Ders der = null;
            using (var ctx = new OkulDbContext())
            {
                der = ctx.Dersler.Find(id);

            }
            return View(der);
        }
        [HttpPost]
        public IActionResult DersGuncelle(Ders der)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(der).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult DersSil(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Dersler.Remove(ctx.Dersler.Find(id));
                ctx.SaveChanges();

            }
            return RedirectToAction("Index");

        }
    }
}
