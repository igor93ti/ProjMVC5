using ProjMVC5.Application;
using ProjMVC5.Application.Interfaces;
using ProjMVC5.Application.Services;
using ProjMVC5.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;

namespace ProjMVC5.UI.Sistema.Controllers
{
    [Authorize]
    public class FiliacaoController : Controller
    {

        //ModuloCliente - CL,CI,CE,CD,CX

        private readonly IFiliacaoAppService _filiacaoAppService;

        public FiliacaoController()
        {
            _filiacaoAppService = new FiliacaoAppService();
        }

        [ClaimsAuthorize("ModuloCliente", "CL")]
        public ActionResult Index()
        {
            return View(_filiacaoAppService.ObterTodos());
        }

        [ClaimsAuthorize("ModuloCliente", "CD")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteViewModel clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "CI")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("ModuloCliente", "CI")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _filiacaoAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "CE")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "CE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _filiacaoAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "CX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _filiacaoAppService.ObterPorId(id.Value);
             
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("ModuloCliente", "CX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _filiacaoAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _filiacaoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
