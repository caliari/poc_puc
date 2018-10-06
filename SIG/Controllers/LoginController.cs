using Newtonsoft.Json.Linq;
using SIG.Models;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Class;
using Newtonsoft.Json;
using System.Collections;

namespace SIG.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Authentication(string param)
        {
            Session["UpdateLogged"] = true;
            var result = new ResultJson();
            UsuarioBusiness _service = new UsuarioBusiness();

            var _base = JsonConvert.DeserializeObject<Usuario>(param);

            if ((string.IsNullOrEmpty(_base.email)) || (string.IsNullOrEmpty(_base.senha)))
            {
                result.status = 401;
                result.message = "Usuário não localizado!";
                return Json(result);
            }

            var parametro = new Hashtable();
            parametro.Add("email", _base.email);
            parametro.Add("senha", _base.senha);

            var user = _service.GetUser(parametro);
            
            if (user != null)
            {
                
                Session["User"] = user;

                var userModel = new UserModel();
                userModel.usuario = user;

                //Context.NomeEmpresa = userModel.usuario.Empresa.NomeEmpresa;
                System.Web.HttpContext.Current.Session[UserModel.USER_SESSION_KEY] = userModel;

                dynamic elemento = new JObject();
                elemento.Nome = user.nome;

                result.status = 200;
                result.element = elemento;
            }
            else
            {
                result.status = 401;
                result.message = "Usuário não localizado!";
            }

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public JsonResult UserFail()
        {
            Session["UpdateLogged"] = true;
            return Json(new { message = "expired" }, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public RedirectResult UserRedirect()
        {
            Session["UpdateLogged"] = true;
            return Redirect("~/Login");
        }
    }
}