using FirstAspNetMVC.Data;
using FirstAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAspNetMVC.Controllers
{
    public class EmprestimoController : Controller
    {
        readonly private ApplicationDbContext _context;
        public EmprestimoController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;

            return View(emprestimos);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Add(emprestimo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Cadastrar");
        }
    }
}
