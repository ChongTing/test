using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public enum FirstControlType
    {
        Number,
        DropDownList
    }
    public class FirstModel
    {
        public FirstControlType Type { get; set; }
        public string Id { get; set; }

    }
    public class FirstController : Controller
    {

        // GET: First
        public ActionResult Index()
        {
            var list = new List<FirstModel>
            {
                new FirstModel
                {
                    Id = "control1",
                    Type = FirstControlType.Number
                },
                new FirstModel
                {
                    Id = "control2",
                    Type = FirstControlType.DropDownList
                }
            };
            return View(list);
        }

        public ActionResult GetData()
        {
            return Json(new[]
            {
                new {id = 1, name = "x1"},
                new {id = 2, name = "x2"}
            });
        }
    }
}