using Microsoft.EntityFrameworkCore;
using System;
using API_Imc.Models;

public class Context : DbContext {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Imc> imcs { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
 
}
