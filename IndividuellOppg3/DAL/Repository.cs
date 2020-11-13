using IndividuellOppg3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellOppg3.DAL
{
    public class Repository : IRepository
    {
        private readonly DBContext _db;

        public Repository(DBContext db)
        {
            _db = db;
        }

        public async Task<bool>LagreSpm(Sporsmal innSpm)
        {
            try
            {
                var nySpmRad = new Sporsmalene();
                nySpmRad.Spm = innSpm.Spm;
                nySpmRad.Liker = innSpm.Liker;
                nySpmRad.LikerIkke = innSpm.LikerIkke;
                nySpmRad.Svr = innSpm.Svr;

                _db.Sporsmalene.Add(nySpmRad);
                await _db.SaveChangesAsync();
                Console.Write("kommer hit 3");
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<List<Sporsmal>> HentAlle()
        {
            try
            {
                List<Sporsmal> alleSporsmalene = await _db.Sporsmalene.Select(k => new Sporsmal
                {
                    Id = k.Id,
                    Spm = k.Spm,
                    Liker = k.Liker,  
                    LikerIkke = k.LikerIkke,
                    Svr = k.Svr
                }).ToListAsync();
                return alleSporsmalene;
            } catch
            {
                return null;
            }
        }

        public async Task<bool> OppdaterLiker(Sporsmal liker)
        {
            try
            {
                var endreObjekt = await _db.Sporsmalene.FindAsync(liker.Id);
                if(endreObjekt.Id != liker.Id)
                {
                    var idSjekk = _db.Sporsmalene.Find(liker.Id);
                    if(idSjekk == null)
                    {
                        var nyRad = new Sporsmalene();
                        nyRad.Id = liker.Id;
                        endreObjekt.Id = liker.Id;
                    }
                    else
                    {
                        endreObjekt.Id = liker.Id;
                    }
                }
                endreObjekt.Liker = liker.Liker;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> OppdaterLikerIkke(Sporsmal likerIkke)
        {
            try
            {
                var endreObjekt = await _db.Sporsmalene.FindAsync(likerIkke.Id);
                if (endreObjekt.Id != likerIkke.Id)
                {
                    var idSjekk = _db.Sporsmalene.Find(likerIkke.Id);
                    if (idSjekk == null)
                    {
                        var nyRad = new Sporsmalene();
                        nyRad.Id = likerIkke.Id;
                        endreObjekt.Id = likerIkke.Id;
                    }
                    else
                    {
                        endreObjekt.Id = likerIkke.Id;
                    }
                }
                endreObjekt.LikerIkke = likerIkke.LikerIkke;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
