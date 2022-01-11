using Microsoft.AspNetCore.Mvc;
using SweetnSaltyBusiness;
using SweetnSaltyModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetnSaltyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SweetnSaltyController : ControllerBase
    {
        private readonly ISweetnSaltyBusinessClass _businessClass;
        //constructor
        public SweetnSaltyController(ISweetnSaltyBusinessClass ISweetnSaltyBusinessClass)
        {
            this._businessClass = ISweetnSaltyBusinessClass;
        }


        [HttpPost]
        [Route("postaflavor/{flavor}")]
        public async Task<ActionResult<Flavor>> PostFlavor(string flavor)
        {
            //call the nusiness layer and send the string
            Flavor f = await this._businessClass.PostFlavor(flavor);
            if (f != null)
            {
                return Created($"http://5001/sweetnsalty/postaflavor/{f.FlavorID}", f);
            }
            else return BadRequest();
        }

        [HttpPost]
        [Route("postaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> PostPerson(string fname, string lname/*, string flavor*/)
        {
            Person pf = await this._businessClass.PostPerson(fname, lname/*, flavor*/);
            
            if (pf != null)
            {
                return Created($"http://5001/sweetnsalty/postaperson/{pf.PersonID}", pf);
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route("getaperson/{fname}/{lname}")]
        public async Task<ActionResult<Person>> GetPerson(string fname, string lname)
        {
            Task<Person> tsk = this._businessClass.GetPerson(fname, lname);// get the Task that is the reference to the thing you are waiting for

            Person p1 = await tsk;
            if (p1 == null) return NotFound();
            else return Ok(p1);
            
        }


        [HttpGet]
        [Route("getapersonandflavors/{id}")]
        public async Task<ActionResult<Person>> GetPersonAndFlavors(int id)
        {
            //throw new NotImplementedException();
            Task<Person> p = this._businessClass.GetPersonAndFlavors(id);
            Person PerFlav = await p;
            if (p == null) return NotFound();
            else return Ok(p);
        }

        [HttpGet]
        [Route("getlistofflavors")]
        public async Task<ActionResult<List<Flavor>>> GetAllFlavors()
        {
            
            Task<List<Flavor>> lf = this._businessClass.GetAllFlavors();
            List<Flavor> flavors = await lf;
            if (flavors == null) return NotFound();
            else return Ok(flavors);

        }


    }
}
