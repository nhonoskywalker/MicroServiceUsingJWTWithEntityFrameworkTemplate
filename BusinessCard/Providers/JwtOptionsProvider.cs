namespace BusinessCard.Providers
{
    using BusinessCard.Insfrastructure.Models.AuthTokens;
    using BusinessCard.Insfrastructure.Providers;
    using BusinessCard.Options;
    using Microsoft.Extensions.Options;

    public class JwtOptionsProvider : IJwtOptionsProvider
    {
        private readonly JwtOptions jwtOptions;

        public JwtOptionsProvider(IOptions<JwtSettings> options)
        {
            this.jwtOptions = new JwtOptions(options.Value.SecretId, options.Value.Expires);
        }

        public JwtOptions GetJwtOptions()
        {
            return this.jwtOptions;
        }
    }
}
