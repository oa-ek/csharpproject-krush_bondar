﻿using Microsoft.AspNetCore.Identity;

namespace HealthyTreats.Repositories.Models
{
    public class UserListItemModel
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public List<IdentityRole<Guid>>? Roles { get; set; }
    }
}