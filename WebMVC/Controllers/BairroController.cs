using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class BairroController : Controller
    {
        //
        // GET: /Bairro/

        private BairroRepository bairroRepository;
        private CidadeRepository cidadeRepository;
        public BairroController()
        {
            bairroRepository = new BairroRepository();
            cidadeRepository = new CidadeRepository();
        }


        public ActionResult Index()
        {
            return View(bairroRepository.BuscarTodos());
        }


        public ActionResult Cidade(int id)
        {
            List<BairroModel> models = bairroRepository.BuscarTodosDaCidade(id);
            if (models != null && models.Count > 0)
            {
                return View(models);
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Bairro/Details/5

        public ActionResult Details(int id)
        {
            return View(bairroRepository.BuscarPorID(id));
        }

        //
        // GET: /Bairro/Create

        public ActionResult Create()
        {
            BairroModel retorno = new BairroModel();
            retorno.CidadesDisponiveis = cidadeRepository.BuscarTodos().Select(r => new SelectListItem() { Selected = false, Text = r.Nome, Value = r.ID.ToString() }).OrderBy(o => !o.Selected).ToList();
            return View(retorno);
        }

        //
        // POST: /Bairro/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                BairroModel bairroModel = new BairroModel();
                bairroModel.Cidade = new CidadeModel() { ID = Int32.Parse(collection[0]) };
                bairroModel.Nome = collection[1];
                bairroModel.Sigla = collection[2];
                bairroRepository.AdicionarItem(bairroModel);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("a", "Falha ");
            return RedirectToAction("Index");
        }

        //
        // GET: /Bairro/Edit/5

        public ActionResult Edit(int id)
        {
            BairroModel retorno = bairroRepository.BuscarPorID(id);
            if (retorno != null)
            {
                retorno.CidadesDisponiveis = cidadeRepository.BuscarTodos().Select(r =>
                    new SelectListItem()
                    {
                        Selected = (retorno.Cidade.ID == r.ID ? true : false),
                        Text = r.Nome,
                        Value = r.ID.ToString()
                    }).OrderBy(o => !o.Selected).ToList();

                return View(retorno);
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Bairro/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                BairroModel bairroModel = new BairroModel();
                bairroModel.Cidade = new CidadeModel() { ID = Int32.Parse(collection[0]) };
                bairroModel.Nome = collection[1];
                bairroModel.Sigla = collection[2];
                bairroModel.ID = id;
                bairroRepository.EditarItem(bairroModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        //
        // GET: /Bairro/Delete/5

        public ActionResult Delete(int id)
        {
            return View(bairroRepository.BuscarPorID(id));
        }

        //
        // POST: /Bairro/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                BairroModel bairro = new BairroModel();
                bairro.ID = id;
                bairroRepository.ExcluirItem(bairro);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
