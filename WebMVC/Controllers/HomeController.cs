using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private CidadeRepository cidadeRepository;        
        public HomeController()
        {
            cidadeRepository = new CidadeRepository();            
        }
        public ActionResult Index()
        {
            PesquisaPrincipalModel pesquisaPrincipalModel = new PesquisaPrincipalModel();
            List<SelectListItem> listaCidade = cidadeRepository.BuscarTodos().Select(cidade => new SelectListItem() { Text = cidade.Nome, Value = cidade.ID.ToString() }).ToList();
            listaCidade.Add(new SelectListItem() { Text = "Selecione...", Value = "selecione", Selected = true });
            pesquisaPrincipalModel.Cidades = listaCidade.OrderBy(r => !r.Selected).ToList();
            pesquisaPrincipalModel.Bairros = new List<SelectListItem>() { new SelectListItem() { Text = "Selecione...", Value = "selecione", Selected = true } };
            return View(pesquisaPrincipalModel);
        }

       

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewData["Message"] = message;
            return View();
        }
    }
}
