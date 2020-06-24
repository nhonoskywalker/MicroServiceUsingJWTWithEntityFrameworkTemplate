namespace BusinessCard.Data.Entities.Users
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserEntity : IdentityUser<Guid>
    {
        public DateTime? CreatedAt { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public Guid? CountryId { get; set; }

        public DateTime? LastLogInDate { get; set; }
    }
}
