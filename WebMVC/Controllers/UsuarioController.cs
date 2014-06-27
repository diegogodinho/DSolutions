using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMVC.Models;
using WebMVC.Authentication;
using System.Web.Script.Serialization;
using WebMVC.Validators;
using WebMVC.Attributes;
using System.IO;

namespace WebMVC.Controllers
{

    [HandleError]
    public class UsuarioController : Controller
    {

        private UsuarioRepository usuarioRepository;
        private GrupoRepository grupoRepository;
        public UsuarioController()
        {
            usuarioRepository = new UsuarioRepository();
            grupoRepository = new GrupoRepository();

        }
        public ActionResult LogOn()
        {
            return View();
        }

        public ActionResult LoginEspecifico(string message)
        {
            if (message != null)
                ViewData["message"] = message;
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                CustomPrincipal principal;
                if (usuarioRepository.ValidarUsuario(model.UserName, model.Password, out principal))
                {
                    //FormsService.SignIn(model.UserName, model.RememberMe);
                    autenticarUsuario(model.UserName, model.Password, principal.Grupo);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "HomeAdmin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "O nome do usuário ou senha são inválidos. Tente novamente");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void autenticarUsuario(string login, string senha, Grupo grupo)
        {
            Profile profile = new Profile();
            profile.Login = login;
            profile.Grupo = grupo;


            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string userData = json_serializer.Serialize(profile);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1,
            login,
            DateTime.Now,
            DateTime.Now.Add(FormsAuthentication.Timeout),
            false,
            userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Register()
        {
            //ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(UsuarioModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Attempt to register the user
        //        MembershipCreateStatus createStatus = MembershipService.CreateUser(model.Nome, model.Senha, model.Email);

        //        if (createStatus == MembershipCreateStatus.Success)
        //        {
        //            // autenticarUsuario(model.UserName, model.Password);//false /* createPersistentCookie */);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
        //    return View(model);
        //}


        [Authorize]
        public ActionResult ChangePassword()
        {
            //ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        //[Authorize]
        //[HttpPost]
        //public ActionResult ChangePassword(ChangePasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
        //        {
        //            return RedirectToAction("ChangePasswordSuccess");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
        //    return View(model);
        //}

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        #region Index
        public ActionResult Index()
        {
            return View(usuarioRepository.BuscarTodos());
        }
        #endregion

        #region Create
        [CustomAuthorize]
        public ActionResult Create()
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.GruposDisponiveis = new List<SelectListItem>();
            usuario.GruposDisponiveis.Add(new SelectListItem() { Selected = true, Text = "Selecione...", Value = "0" });
            grupoRepository.BuscarTodos().ForEach(grupo =>
                {
                    usuario.GruposDisponiveis.Add(new SelectListItem() { Selected = false, Text = grupo.NomeGrupo, Value = grupo.ID.ToString() });
                });
            usuario.DataNascimento = DateTime.Now;            
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Create(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files != null && Request.Files.Count > 0)
                {
                    byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                    {
                        fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                    }
                    model.Foto = fileData;
                }
                usuarioRepository.AdicionarItem(model);
                return RedirectToAction("Index");
            }
            else
            {
                model.GruposDisponiveis = new List<SelectListItem>();
                model.GruposDisponiveis.Add(new SelectListItem() { Selected = true, Text = "Selecione...", Value = "0" });
                grupoRepository.BuscarTodos().ForEach(grupo =>
                {
                    model.GruposDisponiveis.Add(new SelectListItem() { Selected = false, Text = grupo.NomeGrupo, Value = grupo.ID.ToString() });
                });
                return View(model);
            }

        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            UsuarioModel usuario = usuarioRepository.BuscarPorID(id);
            if (usuario != null)
            {
                usuario.GruposDisponiveis = new List<SelectListItem>();
                usuario.GruposDisponiveis.Add(new SelectListItem() { Selected = true, Text = usuario.Grupo.NomeGrupo, Value = usuario.idGrupo.ToString() });

                grupoRepository.BuscarTodos().ForEach(r =>
                    {
                        if (r.ID != usuario.Grupo.ID)
                        {
                            usuario.GruposDisponiveis.Add(new SelectListItem() { Selected = false, Text = r.NomeGrupo, Value = r.ID.ToString() });
                        }
                    });

                return View(usuario);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(UsuarioModel model)
        {
            ModelState.Remove("Senha");
            ModelState.Remove("Login");
            ModelState.Remove("ConfirmacaoSenha");
            if (ModelState.IsValid)
            {
                usuarioRepository.EditarItem(model);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Informe os campos obrigatórios");
            return View(model);
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            return View(usuarioRepository.BuscarPorID(id));
        }

        [HttpPost]
        public ActionResult Delete(UsuarioModel model)
        {
            try
            {
                usuarioRepository.ExcluirItem(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new { message = e.Message });
            }

            return RedirectToAction("Index", "Usuario");



        }
        #endregion

        #region Details
        public ActionResult Details(int id)
        {
            UsuarioModel usuario = usuarioRepository.BuscarPorID(id);
            if (usuario.Foto != null)
                usuario.FotoString = System.Convert.ToBase64String(usuario.Foto, 0, usuario.Foto.Length);
            return View(usuario);
        }
        #endregion

    }
}
