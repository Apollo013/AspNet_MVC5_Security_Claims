using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsTransformation.ClaimsTransformation
{
    public interface IClaimsTransformationService
    {
        Task<IEnumerable<Claim>> TransformInitialClaims(IEnumerable<Claim> initialClaims);
    }
}