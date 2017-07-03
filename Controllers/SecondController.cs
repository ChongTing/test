using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calc(CalcModel model)
        {
            return Json(model.Calc());
        }
    }

    public class CalcModel
    {
        private Dictionary<string, Func<Expression, Expression, BinaryExpression>> _operatorDict
            = new Dictionary<string, Func<Expression, Expression, BinaryExpression>>
            {
                {"+", Expression.Add},
                {"-", Expression.Subtract},
                {"*", Expression.Multiply},
                {"/", Expression.Divide},
            };
        public double Calc()
        {
            var operExp = _operatorDict[Operator];
            var const1 = Expression.Constant(Num1, Num1.GetType());
            var const2 = Expression.Constant(Num2, Num2.GetType());

            var method = Expression.Lambda<Func<double>>(operExp.Invoke(const1, const2));
            return (double) method.Compile()();
        }

        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Operator { get; set; }
    }
}