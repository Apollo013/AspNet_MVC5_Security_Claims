using ClaimsTransformation.ClaimsTransformation;
using Owin;
using System;

namespace ClaimsTransformation.Middleware
{
    public static class AppBuilderExtensions
    {
        public static void UseClaimsTransformationComponent(this IAppBuilder appBuilder, IClaimsTransformationService claimsTransformationService)
        {
            if (claimsTransformationService == null)
            {
                throw new ArgumentNullException("ClaimsTransformationService");
            }
            appBuilder.Use<ClaimsTransformationComponent>(claimsTransformationService);
        }
    }
}