using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Web.Mvc;

namespace ClaimsTransformation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Access the current user property
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            if (claimsPrincipal != null)
            {
                ClaimsIdentity claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                Debug.WriteLine($"Authenticated: {claimsIdentity.IsAuthenticated}");

                // Get list of claims
                IEnumerable<Claim> claimsCollection = claimsIdentity.Claims;

                foreach (var claim in claimsCollection)
                {
                    Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}