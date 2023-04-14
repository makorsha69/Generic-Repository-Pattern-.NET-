﻿using GenericRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
    }
}
