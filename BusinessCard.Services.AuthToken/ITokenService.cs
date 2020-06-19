namespace BusinessCard.Services.AuthToken
{
    using BusinessCard.Data.Entities.Users;
    using System.Collections.Generic;

    public interface ITokenService
    {
        string GenerateToken(UserEntity userEntity, IList<string> roles);
    }
}
