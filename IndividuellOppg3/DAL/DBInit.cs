using IndividuellOppg3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellOppg3.DAL
{
    public class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            var db = serviceScope.ServiceProvider.GetService<DBContext>();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var sporsmal1 = new Sporsmalene
            {

                Spm = "Hvem viser man billetten til?",
                Svr = "Vis frem billetten din til buss-sjåfør ved påstigning",
                Liker = 12,
                LikerIkke = 2
                
            };

            var sporsmal2 = new Sporsmalene
            {

                Spm = "Er det toaletter på bussene deres?",
                Svr = "Ikke på alle desverre. På ruter under 2 timer kjøres det busser uten toaletter",
                Liker = 99,
                LikerIkke = 5
            };
            var sporsmal3 = new Sporsmalene
            {

                Spm = "Er det WI-FI i bussen?",
                Svr = "JA! Passordet finner du på baksiden av setet forran deg",
                Liker = 8,
                LikerIkke = 1
            };
            

            db.Sporsmalene.Add(sporsmal1);
            db.Sporsmalene.Add(sporsmal2);
            db.Sporsmalene.Add(sporsmal3);

            db.SaveChanges();
        }
    }
}
