namespace BusinessCard.Insfrastructure.Models.AuthTokens
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class JwtOptions
    {
        public JwtOptions(string secret, int expiresInMinutes)
        {
            this.Secret = secret;
            this.ExpiresInMinutes = expiresInMinutes;
        }

        public string Secret { get; set; }

        public int ExpiresInMinutes { get; set; }
    }
}
