using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayPalCheckoutSampleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var clientId = "";
            var secret = "";

            //Creating a sandbox environment
            PayPalEnvironment environment = new SandboxEnvironment(clientId, secret);

            // Creating a client for the environment
            PayPalHttpClient client = new PayPalHttpClient(environment);
            var request = new OrdersGetRequest("");
            var task = client.Execute(request);
            var response = task.Result;
            var statusCode = response.StatusCode;

            ViewBag.Message = response.StatusCode.ToString();

            return View(statusCode);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}