namespace BusinessCard.Insfrastructure.Providers
{
    using BusinessCard.Insfrastructure.Models.AuthTokens;

    public interface IJwtOptionsProvider
    {
        JwtOptions GetJwtOptions();
    }
}
