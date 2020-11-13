using IndividuellOppg3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividuellOppg3.DAL
{
    public interface IRepository
    {
        Task<bool> LagreSpm(Sporsmal innSpm);
        Task<List<Sporsmal>> HentAlle();
        Task<bool> OppdaterLiker(Sporsmal liker);
        Task<bool> OppdaterLikerIkke(Sporsmal likerIkke);
    }
}
