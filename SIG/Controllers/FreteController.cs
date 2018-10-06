using Bussiness.Class;
using Model.Models;
using Newtonsoft.Json;
using SIG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uitl;

namespace SIG.Controllers
{
    public class FreteController : Controller
    {
        // GET: Frete
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var _service = new FreteBussiness();
            Session["UpdateLogged"] = true;
            var result = new ResultJson();
            try
            {
                var fretes = _service.GetAll();

                result.status = 200;
                result.message = "Ok";
                result.element = fretes;
            }
            catch (Exception ex)
            {
                result.status = 500;
                result.message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(string param)
        {

            // The long way...  
            var distance = Distance.GetDistance("12237828", "12230490");
            if (distance != 0) Console.WriteLine(distance + " miles");


            var _service = new FreteBussiness();
            Session["UpdateLogged"] = true;
            var result = new ResultJson();

            try
            {
                var dto = JsonConvert.DeserializeObject<Frete>(param);
                Frete frete = new Frete();
                frete = _service.Add(dto);

                result.status = 200;
                result.message = "Ok";
                result.element = frete;
            }
            catch (Exception ex)
            {
                result.status = 500;
                result.message = ex.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CalcFrete(string param)
        {
            Session["UpdateLogged"] = true;
            var result = new ResultJson();

            try
            {
                var value = 0;
                var dto = JsonConvert.DeserializeObject<Frete>(param);

                // The long way...  
                var distance = Distance.GetDistance(dto.origem, dto.destino);
                
                if(distance != 0)
                {
                    value = int.Parse(dto.valor) * distance;
                }

                result.status = 200;
                result.message = "Ok";
                result.element = value;
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