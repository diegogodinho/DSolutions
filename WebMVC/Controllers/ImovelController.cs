using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;
using System.Configuration;
using WebMVC.Views.Shared;
using Web.Comum.Attributes;
using Dados.Repositorio;

namespace WebMVC.Controllers
{
    public class ImovelController : Controller
    {
        private ImovelRepository imovelRepository;
        private CidadeRepository cidadeRepository;
        private CaracteristicaRepositorio caracteristicaRepository;

        public ImovelController()
        {
            imovelRepository = new ImovelRepository();
            cidadeRepository = new CidadeRepository();
            caracteristicaRepository = new CaracteristicaRepositorio();

        }
        [CustomAuthorize]
        public ActionResult Index(int? page)
        {
            return View(new PaginatedData<ImovelModel>(imovelRepository.BuscarTodos().AsQueryable(), page ?? 0, Int32.Parse(ConfigurationManager.AppSettings["QuantidadeRegistroPorPagina"])));
        }
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }
        [CustomAuthorize]
        public ActionResult Create()
        {
            ImovelModel imovelModel = new ImovelModel();
            imovelModel.Cidades = new List<SelectListItem>() { new SelectListItem() { Selected = true, Text = "Selecione...", Value = "0" } };
            cidadeRepository.BuscarTodos().ForEach(cidade =>
                {
                    imovelModel.Cidades.Add(new SelectListItem() { Selected = false, Text = cidade.Nome, Value = cidade.ID.ToString() });

                });
            imovelModel.Bairros = new List<SelectListItem>() { new SelectListItem() { Selected = true, Text = "Selecione...", Value = "0" } };
            List<SelectListItem> selecaoQuatroItens = new List<SelectListItem>(){new SelectListItem(){Selected = true, Text="Selecione...",Value = "0"},
                new SelectListItem(){Selected = true, Text="1",Value = "1"},
                new SelectListItem(){Selected = true, Text="2",Value = "2"},
                new SelectListItem(){Selected = true, Text="3",Value = "3"},
                new SelectListItem(){Selected = true, Text="4 ou mais",Value = "4"},
            };
            imovelModel.QtdeBanheirosList = selecaoQuatroItens;
            imovelModel.QtdeQuartosList = selecaoQuatroItens;
            imovelModel.QtdeSalasList = selecaoQuatroItens;
            imovelModel.QtdeSuitesList = selecaoQuatroItens;
            imovelModel.QtdeVagasGaragemList = selecaoQuatroItens;
            imovelModel.SituacaoList = selecaoQuatroItens;
            imovelModel.CaracteristicasDisponiveis = new List<SelectListItem>();
            caracteristicaRepository.BuscarTodos().ForEach(caracteristica =>
                {
                    imovelModel.CaracteristicasDisponiveis.Add(new SelectListItem() { Selected = false, Text = caracteristica.Descricao, Value = caracteristica.ID.ToString() });
                });

            return View(imovelModel);
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [CustomAuthorize]
        public ActionResult Edit(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }

        [HttpPost]
        [CustomAuthorize]
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
        [CustomAuthorize]
        public ActionResult Delete(int id)
        {
            return View(imovelRepository.BuscarPorID(id));
        }

        [HttpPost]
        [CustomAuthorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
