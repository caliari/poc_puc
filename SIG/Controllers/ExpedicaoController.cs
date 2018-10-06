using Bussiness.Class;
using SIG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIG.Controllers
{
    public class ExpedicaoController : Controller
    {
        // GET: Expedicao
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var _service = new PedidoBusiness();
            Session["UpdateLogged"] = true;
            var result = new ResultJson();
            try
            {
                var pedidos = _service.GetAll();

                result.status = 200;
                result.message = "Ok";
                result.element = pedidos;
            }
            catch (Exception ex)
            {
                result.status = 500;
                result.message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}