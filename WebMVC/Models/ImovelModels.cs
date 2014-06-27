using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dados;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebMVC.Models
{
    public class ImovelModel : BaseModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Quantidade de Quartos")]
        public int QtdeQuartos { get; set; }

        public List<SelectListItem> QtdeQuartosList { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Quantidade de Banheiros")]
        public int QtdeBanheiros { get; set; }

        public List<SelectListItem> QtdeBanheirosList { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Quantidade de Vagas de Garagem")]
        public int QtdeVagasGaragem { get; set; }

        public List<SelectListItem> QtdeVagasGaragemList { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Valor do imóvel")]
        public double Valor { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Metragem do imóvel")]
        public string Metragem { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Usuário")]
        public int IDUsuario { get; set; }


        [DataType(DataType.Currency)]
        [DisplayName("Valor do condomínio")]
        public double? Condominio { get; set; }


        [DataType(DataType.Currency)]
        [DisplayName("Valor do IPTU")]
        public double? Iptu { get; set; }


        [DataType(DataType.Text)]
        [DisplayName("Idade do imóvel")]
        public int? IdadeImovel { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Quantidade de suítes")]
        public int QtdeSuites { get; set; }

        public List<SelectListItem> QtdeSuitesList { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Quantidade de salas")]
        public int QtdeSalas { get; set; }

        public List<SelectListItem> QtdeSalasList { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Unidades por andar")]
        public int? QtdeUnidadesPorAndar { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Características")]
        public string ListaCaracteristicas { get; set; }

        public List<SelectListItem> CaracteristicasDisponiveis { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Situação")]
        public int Situacao { get; set; }

        public List<SelectListItem> SituacaoList { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Bairro")]
        public int IDBairro { get; set; }

        public List<SelectListItem> Bairros { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Cidade")]
        public int IDCidade { get; set; }

        public List<SelectListItem> Cidades { get; set; }

    }

    public class ImovelRepository : BaseRepository<IMOVEL>
    {
        public List<ImovelModel> BuscarTodos()
        {
            return (from a in SingletonDBContext.Current.dbContext.IMOVEL
                    select new ImovelModel()
                    {
                        Condominio = a.CONDOMINIO,
                        Descricao = a.DESCRICAO,
                        ID = a.IDIMOVEL,
                        IdadeImovel = a.IDADEIMOVEL,
                        IDBairro = a.IDBAIRRO,
                        IDUsuario = a.IDUSUARIO,
                        Iptu = a.IPTU,
                        ListaCaracteristicas = a.LISTACARACTERISTICAS,
                        Metragem = a.METRAGEM,
                        QtdeBanheiros = a.QTDEBANHEIROS,
                        QtdeQuartos = a.QTDEQUARTOS,
                        QtdeSalas = a.QTDESALAS,
                        QtdeSuites = a.QTDESUITES,
                        QtdeUnidadesPorAndar = a.QTDEUNIDADESPORANDAR,
                        QtdeVagasGaragem = a.QTDEVAGASGARAGEM,
                        Situacao = a.SITUACAO,
                        Titulo = a.TITULO,
                        Valor = a.VALOR
                    }).ToList();
        }

        public ImovelModel BuscarPorID(int id)
        {
            return (from a in SingletonDBContext.Current.dbContext.IMOVEL
                    where a.IDIMOVEL == id
                    select new ImovelModel()
                    {
                        Condominio = a.CONDOMINIO,
                        Descricao = a.DESCRICAO,
                        ID = a.IDIMOVEL,
                        IdadeImovel = a.IDADEIMOVEL,
                        IDBairro = a.IDBAIRRO,
                        IDCidade = a.IDCIDADE,
                        IDUsuario = a.IDUSUARIO,
                        Iptu = a.IPTU,
                        ListaCaracteristicas = a.LISTACARACTERISTICAS,
                        Metragem = a.METRAGEM,
                        QtdeBanheiros = a.QTDEBANHEIROS,
                        QtdeQuartos = a.QTDEQUARTOS,
                        QtdeSalas = a.QTDESALAS,
                        QtdeSuites = a.QTDESUITES,
                        QtdeUnidadesPorAndar = a.QTDEUNIDADESPORANDAR,
                        QtdeVagasGaragem = a.QTDEVAGASGARAGEM,
                        Situacao = a.SITUACAO,
                        Titulo = a.TITULO,
                        Valor = a.VALOR
                    }).FirstOrDefault();
        }
        public void AdicionarItem(ImovelModel model)
        {
            IMOVEL imovel = BaseModel.AdaptarTipos<ImovelModel, IMOVEL>(model);
            this.AdicionarItem(imovel);
        }

        public void ExcluirItem(int id)
        {
            ImovelModel imovelModel = this.BuscarPorID(id);
            if (imovelModel != null)
            {
                this.ExcluirItem(imovelModel.ID);
            }
        }

        public void AtualizarItem(ImovelModel model)
        {
            IMOVEL imovel = (from a in SingletonDBContext.Current.dbContext.IMOVEL
                             where a.IDIMOVEL == model.ID
                             select a).FirstOrDefault();
            if (imovel != null)
            {
                BaseModel.AdaptarTipos<ImovelModel, IMOVEL>(model, ref imovel);
                SingletonDBContext.Current.dbContext.SaveChanges();
            }
        }
    }
}