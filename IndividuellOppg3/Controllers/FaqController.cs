using IndividuellOppg3.DAL;
using IndividuellOppg3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IndividuellOppg3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //Bruker ikke routing enn så lenge, derfor er det over kommentert ut
    public class FaqController : ControllerBase
    {
        private IRepository _db;

        public FaqController(IRepository db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> LagreSpm(Sporsmal innSpm)
        {
            bool OK = await _db.LagreSpm(innSpm);
            Console.Write("kommer hit 2");
            if (!OK)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
       public async Task<ActionResult> HentAlle()
       {
        List<Sporsmal> alleSporsmalene = await _db.HentAlle();
        return Ok(alleSporsmalene);
       }

        [HttpPut]
        public async Task<ActionResult> OppdaterLiker(Sporsmal liker)
        {
            bool returOK = await _db.OppdaterLiker(liker);
            if(!returOK)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> OppdaterLikerIkke(Sporsmal likerIkke)
        {
            bool returOK = await _db.OppdaterLikerIkke(likerIkke);
            if (!returOK)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
