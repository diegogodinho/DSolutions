using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc.Html;

namespace WebMVC.Helpers
{
    public static class CustomHelpers
    {
        #region LabelAndTextBox
        public static string LabelAndTextBoxPDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "pequeno");
        }
        public static string LabelAndTextBoxMDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "medio");
        }
        public static string LabelAndTextBoxGDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "grande");
        }

        private static string LabelAndTextBoxDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string tamanho)
        {
            MvcHtmlString label = LabelExtensions.LabelFor<TModel, TProperty>(htmlHelper, expression);
            MvcHtmlString textBox = InputExtensions.TextBoxFor<TModel, TProperty>(htmlHelper, expression, new { @class = "form-control" });
            MvcHtmlString validation = ValidationExtensions.ValidationMessageFor<TModel, TProperty>(htmlHelper, expression);
            return string.Format("<div class=\"form-group {0}\"><div class=\"editor-label\">{1}</div><div class=\"editor-field\">{2}{3}</div></div>", tamanho, label.ToHtmlString(), textBox.ToHtmlString(), validation.ToHtmlString());
        }

        #endregion

        #region LabelAndDropDownList

        public static string LabelAndDropDownListPDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndDropDownListDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "pequeno");
        }
        public static string LabelAndDropDownListMDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndDropDownListDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "medio");
        }
        public static string LabelAndDropDownListGDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndDropDownListDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "grande");
        }

        private static string LabelAndDropDownListDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string tamanho)
        {
            MvcHtmlString label = LabelExtensions.LabelFor<TModel, TProperty>(htmlHelper, expression);
            MvcHtmlString dropDownList = SelectExtensions.DropDownListFor<TModel, TProperty>(htmlHelper, expression, selectList, new { @class = "form-control" });
            MvcHtmlString validation = ValidationExtensions.ValidationMessageFor<TModel, TProperty>(htmlHelper, expression);
            return string.Format("<div class=\"form-group {0}\"><div class=\"editor-label\">{1}</div><div class=\"editor-field\">{2}{3}</div></div>", tamanho, label.ToHtmlString(), dropDownList.ToHtmlString(), validation.ToHtmlString());
        }
        #endregion

        #region LabelAndPassword
        public static string LabelAndPasswordPDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndPasswordDSolution<TModel, TProperty>(htmlHelper, expression, "pequeno");
        }
        public static string LabelAndPasswordMDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndPasswordDSolution<TModel, TProperty>(htmlHelper, expression, "medio");
        }
        public static string LabelAndPasswordGDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndPasswordDSolution<TModel, TProperty>(htmlHelper, expression, "grande");
        }

        private static string LabelAndPasswordDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string tamanho)
        {
            MvcHtmlString label = LabelExtensions.LabelFor<TModel, TProperty>(htmlHelper, expression);
            MvcHtmlString password = InputExtensions.PasswordFor<TModel, TProperty>(htmlHelper, expression, new { @class = "form-control" });
            MvcHtmlString validation = ValidationExtensions.ValidationMessageFor<TModel, TProperty>(htmlHelper, expression);
            return string.Format("<div class=\"form-group {0}\"><div class=\"editor-label\">{1}</div><div class=\"editor-field\">{2}{3}</div></div>", tamanho, label.ToHtmlString(), password.ToHtmlString(), validation.ToHtmlString());
        }

        #endregion

        #region BotaoNovo
        public static string ButtonNew<TModel>(this HtmlHelper<TModel> htmlHelper, string controller, string actionName)
        {
            return string.Format("<a href=\"\\{0}/{1}\" class=\"btn btn-default\" style=\"float: right; margin-bottom: 10px;\"><spa class=\"glyphicon glyphicon-file\">Novo</spa></a>", controller, actionName);
        }
        #endregion

        #region Disableinput
        public static string LabelAndDisableTextBoxPDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndDisableTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "pequeno");
        }
        public static string LabelAndDisableTextBoxMDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndDisableTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "medio");
        }
        public static string LabelAndDisableTextBoxGDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return LabelAndDisableTextBoxDSolution<TModel, TProperty>(htmlHelper, expression, "grande");
        }

        private static string LabelAndDisableTextBoxDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string tamanho)
        {
            MvcHtmlString label = LabelExtensions.LabelFor<TModel, TProperty>(htmlHelper, expression);
            MvcHtmlString textBox = InputExtensions.TextBoxFor<TModel, TProperty>(htmlHelper, expression, new { @class = "form-control", disabled = "disabled" });
            return string.Format("<div class=\"form-group {0}\"><div class=\"editor-label\">{1}</div><div class=\"editor-field\">{2}</div></div>", tamanho, label.ToHtmlString(), textBox.ToHtmlString());
        }

        #endregion

        #region LabelAnChoosen
        public static string LabelAndChosenPDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndChosenDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "pequeno");
        }
        public static string LabelAndChosenMDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndChosenDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "medio");
        }
        public static string LabelAndChosenGDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return LabelAndChosenDSolution<TModel, TProperty>(htmlHelper, expression, selectList, "grande");
        }
        private static string LabelAndChosenDSolution<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string tamanho)
        {
            MvcHtmlString label = LabelExtensions.LabelFor<TModel, TProperty>(htmlHelper, expression);
            MvcHtmlString dropDownList = SelectExtensions.DropDownListFor<TModel, TProperty>(htmlHelper, expression, selectList, new { @class = "form-control", multiple = "multiple" });
            MvcHtmlString validation = ValidationExtensions.ValidationMessageFor<TModel, TProperty>(htmlHelper, expression);
            return string.Format("<div class=\"form-group {0}\"><div class=\"editor-label\">{1}</div><div class=\"editor-field\">{2}{3}</div></div>", tamanho, label.ToHtmlString(), dropDownList.ToHtmlString(), validation.ToHtmlString());
        }
        #endregion

        public static string Imagem<TModel>(this HtmlHelper<TModel> htmlHelper, string baseTeste)
        {
            if (baseTeste != null)
                return string.Format("<img src=\"data:image/png;base64,{0}\" width=\"200\"  height=\"200\"> </img> ", baseTeste);
            return "";
        }
    }
}