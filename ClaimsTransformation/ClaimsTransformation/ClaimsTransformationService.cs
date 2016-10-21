using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsTransformation.ClaimsTransformation
{
    public class ClaimsTransformationService : IClaimsTransformationService
    {
        /// <summary>
        /// Transforms the initial set of claims automatically produced by the system, into a set of claims that we actually want
        /// </summary>
        /// <param name="initialClaims"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Claim>> TransformInitialClaims(IEnumerable<Claim> initialClaims)
        {
            // This will contain the claims we actually want
            List<Claim> finalClaims = new List<Claim>();

            // Get the user
            Claim userIdClaim = (from c in initialClaims where c.Type == ClaimTypes.NameIdentifier select c).FirstOrDefault();

            // Check if user is authenticated
            if (userIdClaim == null)
            {
                return initialClaims;
            }

            await Task.Delay(1000);

            // Add additional claims (just an example, we could run to the database here)
            finalClaims.Add(new Claim("http://www.mycompany.com/claims/favourite-day", "Friday"));
            finalClaims.Add(new Claim("http://www.mycompany.com/claims/favourite-colour", "Navy Blue"));
            finalClaims.Add(new Claim("http://www.mycompany.com/claims/occupation", "Developer"));

            // Add innitial claims
            finalClaims.AddRange(initialClaims);

            return finalClaims;
        }
    }
}