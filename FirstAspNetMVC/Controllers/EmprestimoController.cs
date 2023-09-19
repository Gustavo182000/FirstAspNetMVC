using FirstAspNetMVC.Data;
using FirstAspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult Editar(int id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }   
            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }
        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _context.Emprestimos.Remove(emprestimo);
            _context.SaveChanges();

            return RedirectToAction("Index");


        }
        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Emprestimos.Update(emprestimo);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }


            return View(emprestimo);

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
