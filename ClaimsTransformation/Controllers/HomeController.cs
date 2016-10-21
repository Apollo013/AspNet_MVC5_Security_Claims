using ClaimsTransformation.ClaimsTransformation;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClaimsTransformation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //await RunPreOWINHookup();

            // Print claims after OWIN has transformed them
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            if (claimsPrincipal != null)
            {
                Debug.WriteLine("OWIN Claims");
                foreach (var claim in claimsPrincipal.Claims)
                {
                    Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
                }
            }
            return View();
        }


        private async Task RunPreOWINHookup()
        {
            // Access the current user property
            ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;
            if (claimsPrincipal != null)
            {
                // Get initial set of claims
                ClaimsIdentity claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                Debug.WriteLine($"Authenticated: {claimsIdentity.IsAuthenticated}");

                // Get list of claims and output them
                IEnumerable<Claim> claimsCollection = claimsIdentity.Claims;

                Debug.WriteLine("Claims before transformation: ");
                foreach (var claim in claimsCollection)
                {
                    Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
                }

                // Transform claims
                await TestClaimsTransformation(claimsCollection);
            }
        }

        private async Task TestClaimsTransformation(IEnumerable<Claim> initialsClaims)
        {
            // Transform initial claims collection
            ClaimsTransformationService service = new ClaimsTransformationService();
            IEnumerable<Claim> transformedClaims = await service.TransformInitialClaims(initialsClaims);

            Debug.WriteLine("Claims after transformation: ");
            foreach (var claim in transformedClaims)
            {
                Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
            }
        }



        #region IGNORE
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
        #endregion
    }
}