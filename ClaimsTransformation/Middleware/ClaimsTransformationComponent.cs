using ClaimsTransformation.ClaimsTransformation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ApplicationFunction = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;


/* N.B. 'ApplicationFunction
 * The application function, or AppFunc is a tool that defines how elements process incoming HTTP requests to the server. 
 * It provides a delegate which returns a Task and accepts an IDictionary of string and object.
 * The dictionary represents the request environment.
 */
namespace ClaimsTransformation.Middleware
{
    /// <summary>
    /// Claims transformation component that will be hooked up to OWIN
    /// </summary>
    public class ClaimsTransformationComponent
    {
        private readonly ApplicationFunction _nextComponent;
        private readonly IClaimsTransformationService _claimsTransformationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appFunc">Represents the next component in the component chain</param>
        public ClaimsTransformationComponent(ApplicationFunction appFunc, IClaimsTransformationService claimsTransformationService)
        {
            if (appFunc == null)
            {
                throw new ArgumentNullException("AppFunc of next component");
            }
            if (claimsTransformationService == null)
            {
                throw new ArgumentNullException("claimsTransformationService");
            }
            _nextComponent = appFunc;
            _claimsTransformationService = claimsTransformationService;
        }

        /// <summary>
        /// Transforms claims
        /// </summary>
        /// <param name="environment">A dictionary that includes all types of data about the request from and the response to the client: headers, cookies, server variables etc</param>
        /// <returns></returns>
        public async Task Invoke(IDictionary<string, object> environment)
        {
            // Get the current principal that will contain the initial set of claims
            ClaimsPrincipal claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (claimsPrincipal != null)
            {
                // Get initial set of claims
                ClaimsIdentity claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                Debug.WriteLine($"OWIN Authenticated: {claimsIdentity.IsAuthenticated}");

                // Get list of claims and output them
                IEnumerable<Claim> claimsCollection = claimsIdentity.Claims;
                Debug.WriteLine("OWIN Claims BEFORE transformation: ");
                foreach (var claim in claimsCollection)
                {
                    Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
                }

                // Transform Claims
                IEnumerable<Claim> transformedClaims = await _claimsTransformationService.TransformInitialClaims(claimsCollection);
                Debug.WriteLine("OWIN Claims AFTER transformation: ");
                foreach (var claim in transformedClaims)
                {
                    Debug.WriteLine($"Claim Type: {claim.Type},\t Value Type: {claim.ValueType},\t Claim Value: {claim.Value}");
                }

                // Create a new principal and override initial principal in the current thread
                ClaimsPrincipal extendedPrincipal = new ClaimsPrincipal(new ClaimsIdentity(transformedClaims));
                Thread.CurrentPrincipal = extendedPrincipal;
                await _nextComponent(environment);

                //PrintEnvironment(environment).Wait();
            }
        }

        /// <summary>
        /// Prints OWIN environment variables (not necessary)
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        private Task<IDictionary<string, object>> PrintEnvironment(IDictionary<string, object> environment)
        {
            Debug.WriteLine("OWIN ENVIRONMENT");
            foreach (var pair in environment)
            {
                Debug.WriteLine($"{pair.Key}: {pair.Value}");
            }

            return Task.FromResult(environment);
        }
    }
}