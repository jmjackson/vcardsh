using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vcardsh.web.Clase;
using vcardsh.web.Models;
using vcardsh.web.Models.ViewModels;

namespace vcardsh.web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            
            return View(db.Users.OrderBy(a=>a.Email).ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(RegisterUserViewModel user)
        {
            try
            {
                Utilities.CreateUserASP(user.Email, user.Password, user.Rol);
                var userdb = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                userdb.Nombre = user.Nombre;
                userdb.Apellido = user.Apellido;
                userdb.Estado = user.Estado;
                userdb.FechaCreacion = (DateTime)user.FechaCreacion;
                db.SaveChanges();

                Perfil perfil = new Perfil() {
                UsuarioId=userdb.Id,
                };
                db.Perfiles.Add(perfil);
                db.SaveChanges();
                InfoPago info = new InfoPago()
                {
                    EmailCobro = User.Identity.GetUserName(),
                    UsuarioId=userdb.Id,
                    FechaPago=user.FechaCreacion,
                    
                };
                db.InfoPagos.Add(info);
                db.SaveChanges();

                DetalleUsuario du = new DetalleUsuario()
                {
                    UsuarioId = userdb.Id
                };
                db.DetalleUsuarios.Add(du);
                db.SaveChanges();
                // TODO: Add insert logic here
                TempData["Success"] = "Sus datos fueron agregados automaticamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Error de datos o email existente";
                return RedirectToAction("Index");
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {

                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();

                TempData["Success"] = "Sus datos fueron agregados automaticamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = "Error de datos o email existente";
                return RedirectToAction("Index");
            }
        }
    }
}
