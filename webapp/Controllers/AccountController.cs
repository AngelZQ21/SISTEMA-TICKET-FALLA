#region Using

using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartAdminMvc.Models;
using CL_BE;
using CL_BL;

#endregion

namespace SmartAdminMvc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // TODO: This should be moved to the constructor of the controller in combination with a DependencyResolver setup
        // NOTE: You can use NuGet to find a strategy for the various IoC packages out there (i.e. StructureMap.MVC5)
        private readonly UserManager _manager = UserManager.Create();

        // GET: /account/forgotpassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/login        
        [AllowAnonymous]
        [RedirectOnError]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new AccountLoginModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        // POST: /account/login
        [HttpPost]
        [AllowAnonymous]
        [RedirectOnError]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountLoginModel viewModel)
        {
            //BE_Configuration bE_Configuration = new BE_Configuration();

            //string[] stringSeparators = new string[] { "," };
            //string usuariocadena = @User.Identity.Name.ToUpper();
            //string[] usuario = usuariocadena.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            //bE_Configuration.RegistrationUser = Convert.ToInt32(usuario[0]);
            // Si el modelo enviado no es válido retornar la vista
            if (ModelState.IsValid) {
                EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
                BE_User bE_User = new BE_User();
                bE_User.UUser = viewModel.Email;
                bE_User.UPassword = ClaseEncriptar.EncryptToString(viewModel.Password);

                var lista = new BL_User().ValidarUsuario(bE_User);

                var IdUserX = lista[0].IdUser;

                string valor = "A";

                var lista2 = new BL_Configuration().EditAlertStatus(valor , IdUserX);

                if (lista.Count > 0)
                {
                    if (lista[0].RegistrationStatus == "A")
                    {
                        /*EXITO*/
                        IdentityUser ad = new IdentityUser();
                        ad.UserName = lista[0].IdUser.ToString() + "," +
                                      viewModel.Email + "," +
                                      lista[0].IdProfile.ToString() + "," +
                                      lista[0].UserType.ToString() + "," +
                                      lista[0].Name.ToString() + "," +
                                      lista[0].ViewController.ToString() + "," +
                                      lista[0].Controller.ToString();
                        ad.Id = lista[0].IdUser.ToString();
                        await SignInAsync(ad, viewModel.RememberMe);
                        //return RedirectToLocal("Home", "Vhome");
                        return RedirectToLocal(lista[0].Controller.ToString(), lista[0].ViewController.ToString());
                        //return RedirectToLocal("Home", "Vhome");

                    }
                    else if (lista[0].ValorConsulta == "0")
                    {
                        ModelState.AddModelError("ErrorValidacion", lista[0].MensajeConsulta);
                        ModelState.AddModelError("", "No se pudieron validar los datos, contacte con el administrador de sistema.");
                    }
                    else if (lista[0].RegistrationStatus == "I")
                    {
                        /*Usuario inactivo*/
                        ModelState.AddModelError("", "El usuario ingresado se encuentra temporalmente bloqueado.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "No se pudo realizar la validación");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o clave incorrecto");
                }
            }
            else
            {
                return View(viewModel);
            }

            return View(viewModel);

            //// Verify if a user exists with the provided identity information
            //var user = await _manager.FindByEmailAsync(viewModel.Email);

            //// If a user was found
            //if (user != null)
            //{
            //    // Then create an identity for it and sign it in
            //    await SignInAsync(user, viewModel.RememberMe);

            //    // If the user came from a specific page, redirect back to it
            //    return RedirectToLocal(viewModel.ReturnUrl);
            //}

            //// No existing user was found that matched the given criteria
            //ModelState.AddModelError("", "Invalid username or password.");

            //// If we got this far, something failed, redisplay form
            //return View(viewModel);


            //try
            //{
            //    cont++;
            //    EncryptAndDecryptFile ClaseEncriptar = new EncryptAndDecryptFile();
            //    //ENLogueo oENLogueo = new ENLogueo();
            //    //String clavePassMD5 = ObtenerMD5.ObtenerMd5(viewModel.password);
            //    //oENLogueo.usuario = viewModel.Email;
            //    //oENLogueo.pASsword = clavePassMD5;
            //    //var lista = new LogueoRepository().RWP_SP_LogIn(oENLogueo);
            //    ENLogueo oENLogueo = new ENLogueo();
            //    oENLogueo.txtnombreUsuario = viewModel.Email;
            //    //oENLogueo.txtclaveUsuario = viewModel.password;
            //    oENLogueo.txtclaveUsuario = ClaseEncriptar.EncryptToString(viewModel.password);
            //    var lista = new LogueoRepository().SIGO_SP_BUSCAR_USUARIO(oENLogueo);
            //    // Ensure we have a valid viewModel to work with
            //    //if (!ModelState.IsValid)
            //    //return View(viewModel);

            //    // Verify if a user exists with the provided identity information
            //    //var user = await _manager.FindByEmailAsync(viewModel.Email);
            //    if (lista.Count > 0)
            //    {
            //        IdentityUser ad = new IdentityUser();
            //        ad.UserName = lista[0].IdePersona.ToString() + "," +
            //                      viewModel.Email + "," + lista[0].IdeOperacion.ToString() + "," + lista[0].IdePerfil.ToString() + "," + lista[0].txtnombreUsuario.ToString();
            //        ad.Id = lista[0].IdePersona.ToString();

            //        //var user = await _manager.FindByEmailAsync(viewModel.Email);

            //        // If a user was found
            //        if (viewModel.Email != null)
            //        {
            //            // Then create an identity for it and sign it in
            //            await SignInAsync(ad, viewModel.RememberMe);

            //            // If the user came from a specific page, redirect back to it
            //            return RedirectToLocal(lista[0].txtMenuController.ToString(), lista[0].txtMenuAction.ToString());
            //        }

            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Usuario o clave incorrecta.");
            //        return View();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    return View();
            //}
            //finally
            //{
            //    //return View(viewModel);
            //}

            //return View();









        }

        // GET: /account/error
        [AllowAnonymous]
        public ActionResult Error()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View();
        }

        // GET: /account/register
        [AllowAnonymous]
        public ActionResult Register()
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            return View(new AccountRegistrationModel());
        }

        // POST: /account/register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountRegistrationModel viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            // Prepare the identity with the provided information
            var user = new IdentityUser
            {
                UserName = viewModel.Username ?? viewModel.Email,
                Email = viewModel.Email
            };

            // Try to create a user with the given identity
            try
            {
                var result = await _manager.CreateAsync(user, viewModel.Password);

                // If the user could not be created
                if (!result.Succeeded) {
                    // Add all errors to the page so they can be used to display what went wrong
                    AddErrors(result);

                    return View(viewModel);
                }

                // If the user was able to be created we can sign it in immediately
                // Note: Consider using the email verification proces
                await SignInAsync(user, false);

                return RedirectToLocal("Home", "Index");
            }
            catch (DbEntityValidationException ex)
            {
                // Add all errors to the page so they can be used to display what went wrong
                AddErrors(ex);

                return View(viewModel);
            }
        }

        // POST: /account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // First we clean the authentication ticket like always
            FormsAuthentication.SignOut();

            // Second we clear the principal to ensure the user does not retain any authentication
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);

            // Last we redirect to a controller/action that requires authentication to ensure a redirect takes place
            // this clears the Request.IsAuthenticated flag since this triggers a new request
            return RedirectToLocal("Home", "Index");
        }

        //private ActionResult RedirectToLocal(string returnUrl = "")
        //{
        //    // If the return url starts with a slash "/" we assume it belongs to our site
        //    // so we will redirect to this "action"
        //    if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
        //        return Redirect(returnUrl);

        //    // If we cannot verify if the url is local to our host we redirect to a default location
        //    return RedirectToAction("index", "home");
        //}

        private ActionResult RedirectToLocal(string controlado, string vista)
        {
            // If the return url starts with a slash "/" we assume it belongs to our site
            // so we will redirect to this "action"
            //if (!returnUrl.IsNullOrWhiteSpace() && Url.IsLocalUrl(returnUrl))
            //    return Redirect(returnUrl);

            // If we cannot verify if the url is local to our host we redirect to a default location
            //return RedirectToAction("HomeGestor", "GEOperacion");
            return RedirectToAction(vista, controlado);
            //return RedirectToAction("Index", "Home");
        }

        private void AddErrors(DbEntityValidationException exc)
        {
            foreach (var error in exc.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors.Select(validationError => validationError.ErrorMessage)))
            {
                ModelState.AddModelError("", error);
            }
        }

        private void AddErrors(IdentityResult result)
        {
            // Add all errors that were returned to the page error collection
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                Logout();
        }

        private async Task SignInAsync(IdentityUser user, bool isPersistent)
        {
            // Clear any lingering authencation data
            FormsAuthentication.SignOut();

            // Create a claims based identity for the current user
            //var identity = await _manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            // Write the authentication cookie
            FormsAuthentication.SetAuthCookie(user.UserName, isPersistent);
        }

        // GET: /account/lock
        [AllowAnonymous]
        public ActionResult Lock()
        {
            return View();
        }
    }
}