using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace IndividuellOppg3.DAL
{
    public class Sporsmalene
    {
            
            public int Id { get; set; }
            public string Spm { get; set; }
            public int Liker { get; set; }
            public int LikerIkke { get; set; }
            
            public string Svr { get; set; }

    }


    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Sporsmalene> Sporsmalene { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


    }

}
