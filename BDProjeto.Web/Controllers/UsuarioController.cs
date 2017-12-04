using BDProjeto.Aplicacao;
using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDProjeto.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioAplicacao usuarioApp;

        public UsuarioController()
        {
            usuarioApp = UsuarioAplicacaoConstrutor.UsuarioAplicacaoEF();
        }

        // GET: Usuario
        public ActionResult Listar()
        {
            var usuarios = usuarioApp.ListaUsuarios();

            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Detalhe(string id)
        {
            var usuario = usuarioApp.ListaUsuarioPorId(id);

            if(usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    usuarioApp.Salvar(usuario);
                    return RedirectToAction("Listar");
                }

                return View();
            }
            catch
            {   
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Alterar(string id)
        {
            var usuario = usuarioApp.ListaUsuarioPorId(id);
            
            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    usuarioApp.Salvar(usuario);
                    return RedirectToAction("Listar");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Excluir(string id)
        {
            var usuario = usuarioApp.ListaUsuarioPorId(id);

            if(usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Excluir(Usuario usuario, string id)
        {
            try
            {
                // TODO: Add delete logic here
                var user = usuarioApp.ListaUsuarioPorId(id);

                if (user == null)
                {
                    return View();
                }

                usuarioApp.Delete(user);
                return RedirectToAction("Listar");
            }
            catch
            {
                return View();
            }
        }
    }
}
